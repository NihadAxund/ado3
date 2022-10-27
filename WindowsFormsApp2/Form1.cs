using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string path1 { get; set; }
        string path2 { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private bool Check()
        {
            return From_label.Text.Length > 0 && To_label.Text.Length>0;
        }
        private bool ReadLine(string path,string paht2)
        {
            string readText = File.ReadAllText(path);
            if (readText.Length <= 0) return false;
            FileStream fs = new FileStream(paht2,FileMode.OpenOrCreate,FileAccess.ReadWrite);
            //StreamWriter file1 = new StreamWriter(fs);
            var array = readText.ToCharArray();
            fs.Write()
         //   for (int i = 0; i < array.Length; i++)
            //{
                // MessageBox.Show(array[i].ToString());
               // file1.WriteLine("a");
                //file1.Write(array[i]);
            //}
            fs.Close();

            return true;

        }
        public void Btn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                switch (btn.Tag)
                {
                    case "1":
                        OpenFileDialog theDialog = new OpenFileDialog();
                        theDialog.Title = "Open Text File";
                        theDialog.Filter = "TXT files|*.txt";
                        
                        if (theDialog.ShowDialog() == DialogResult.OK)
                        {
                            //  From_label.AutoSize = false;
                            path1 = theDialog.FileName;
                            From_label.Text = theDialog.FileName;
                        }
                        break;
                    case "2":
                       // MessageBox.Show("2");
                        OpenFileDialog theDialog2 = new OpenFileDialog();
                        theDialog2.Title = "Open Text File";
                        theDialog2.Filter = "TXT files|*.txt";

                        if (theDialog2.ShowDialog() == DialogResult.OK)
                        {
                            path2 = theDialog2.FileName;
                            To_label.Text = theDialog2.FileName;
                        }
                        break;
                    case "3":
                        if (Check()) {
                           // MessageBox.Show("3");
                            ReadLine(path1, path2);
                        };
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
