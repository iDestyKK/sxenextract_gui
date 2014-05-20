using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sxenextract_gui
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Use Windows Theme style
            SetWindowTheme(listView_explorer.Handle, "explorer", null);
            SetWindowTheme(treeView_explorer.Handle, "explorer", null);
        }

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, String pszSubAppName, String pszSubIdList);

        static string song_name = "";
        static string song_author = "";
        static string song_year = "";
        static string song_length = "";
        static string song_genre = "";
        static string song_album = "";
        static string song_comment = "";
        static string gfile = "";

        public class Files
        {
            public Files(string a, int b, long c, int d)
            {
                filename = a;
                size = b;
                pos = c;
                type = d;
            }
            public Files()
            {
                filename = "";
                size = 0;
                pos = 0;
                type = 0;
            }
            public string filename;
            public int size;
            public long pos;
            public int type;
        }

        static List<Files> filedata = new List<Files>();
        static List<string> groups = new List<string>();

        void OpenSXENArchive(string filename)
        {
            FileStream fp = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //EXTREMELY UNORTHODOX HEADER CHECK
            if (fp.ReadByte() == 0x44 &&
                fp.ReadByte() == 0x45 &&
                fp.ReadByte() == 0x52 &&
                fp.ReadByte() == 0x50 &&
                fp.ReadByte() == 0x47 &&
                fp.ReadByte() == 0x5F &&
                fp.ReadByte() == 0x53 &&
                fp.ReadByte() == 0x4F &&
                fp.ReadByte() == 0x4E &&
                fp.ReadByte() == 0x47 &&
                fp.ReadByte() == 0x50 &&
                fp.ReadByte() == 0x41 &&
                fp.ReadByte() == 0x4B) //DERPG_SONGPAK
            {
                gfile = filename;
                int version = (fp.ReadByte() << 8) + fp.ReadByte();
                switch (version)
                {
                    case 1:
                        openSXEN_v01(fp);
                        break;
                    case 2:
                        openSXEN_v02(fp);
                        break;
                }
                fp.Close(); //We are done here.

                //Update the ListView.
                listView_explorer.Items.Clear();
                treeView_explorer.Nodes.Clear();
                ListViewGroup[] group = new ListViewGroup[groups.Count()];
                treeView_explorer.Nodes.Add("main", Path.GetFileName(filename));

                //Categories go first.
                for (int i = 0; i < groups.Count(); i++)
                {
                    //Add the group to the ListView
                    group[i] = new ListViewGroup(groups[i], groups[i]);
                    listView_explorer.Groups.Add(group[i]);

                    //Add the group to the TreeView
                    TreeNode gnode = new TreeNode(groups[i]);
                    treeView_explorer.Nodes["main"].Nodes.Add(gnode);
                }

                //Now it is the file's turn.
                for (int i = 0; i < filedata.Count(); i++)
                {
                    string p = Path.GetExtension(filedata[i].filename);
                    ListViewItem item = new ListViewItem(filedata[i].filename);
                    item.SubItems.Add(p.Substring(1, p.Length - 1).ToUpper() + " File");
                    item.SubItems.Add(ByteSimplify(filedata[i].size));
                    item.Group = group[filedata[i].type];
                    listView_explorer.Items.Add(item);

                    //listView_explorer.Items.Add(filedata[i].filename).SubItems.AddRange(new string[] { p.Substring(1, p.Length - 1).ToUpper() + " File", ByteSimplify(filedata[i].size) });
                }
                treeView_explorer.ExpandAll();
            }
        }

        string ByteSimplify(int size)
        {
            string[] bytetypes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" }; //To be outdated in 2160年
            int count = 0;
            while (size > 1024)
            {
                size /= 1024;
                count += 1;
            }
            return size.ToString() + " " + bytetypes[count];
        }
        
        void openSXEN_v01(FileStream fp)
        {
            while (fp.Position < fp.Length)
            {
                switch (fp.ReadByte())
                {
                    case 0x00:
                        //File
                        filedata.Add(new Files(readString(fp), VLQ_to_int(fp), fp.Position, groups.Count - 1));
                        fp.Seek(filedata[filedata.Count - 1].size, SeekOrigin.Current);
                        break;
                    case 0xFF:
                        //Marker
                        groups.Add(readString(fp));
                        break;
                }
            }
        }

        int VLQ_to_int(FileStream fp)
        {
            int total = 0;
            string bits = "";
            int b;
            do {
                b = fp.ReadByte();
                string seq = "";
                for (int i = 0; i < 7; i++)
                    seq = Convert.ToInt32((b & (1 << i)) != 0).ToString() + seq;
                bits = bits + seq;
            } while ((b & (1 << 7)) != 0);
            for (int i = 0; i < bits.Length; i++)
                total += Convert.ToInt32(Math.Pow((double)2, Convert.ToDouble(bits.Length - (i + 1))) * Convert.ToDouble(bits[i] != '0'));
            return total;
        }

        void openSXEN_v02(FileStream fp)
        {
            //Read Strings
            song_name    = readString(fp);
            song_author  = readString(fp);
            song_year    = readString(fp);
            song_length  = readString(fp);
            song_genre   = readString(fp);
            song_album   = readString(fp);
            song_comment = readString(fp);

            //The rest is the same as the previous version.
            openSXEN_v01(fp);
        }

        string readString(FileStream fp)
        {
            string str = "";
            int length = fp.ReadByte();
            for (int i = 0; i < length; i++)
                str += Convert.ToChar(fp.ReadByte());
            return str;
        }

        private void menuItem_open_Click(object sender, EventArgs e)
        {
            DialogResult fs = openFileDialog_sxen.ShowDialog();
            if (fs == DialogResult.OK)
                if (File.Exists(openFileDialog_sxen.FileName))
                    OpenSXENArchive(openFileDialog_sxen.FileName);
        }

        private void menuItem_extractAll_Click(object sender, EventArgs e)
        {
            DialogResult fs = folderBrowserDialog.ShowDialog();
            if (fs == DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                FileStream fp = new FileStream(gfile, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < filedata.Count(); i++)
                {
                    //BEGIN WRITING FILE.
                    fp.Seek(filedata[i].pos, SeekOrigin.Begin);
                    FileStream np = new FileStream(path + "\\" + filedata[i].filename, FileMode.OpenOrCreate, FileAccess.Write);
                    for (int a = 0; a < filedata[i].size; a++)
                        np.WriteByte(Convert.ToByte(fp.ReadByte()));
                    np.Close();
                }
                fp.Close();
            }
        }

        private void menuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
