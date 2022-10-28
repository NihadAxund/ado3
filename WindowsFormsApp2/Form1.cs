using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
             var array = File.ReadAllText(path).ToCharArray();
            // if (readText.Length <= 0) return false;
            //  FileStream fs = new FileStream(paht2,FileMode.OpenOrCreate,FileAccess.Write);
            //   FileStream f = new FileStream(paht2, FileMode.OpenOrCreate);
            int num = array.Length / 100;
        //    int num2 = array.Length;
           // MessageBox.Show(num.ToString(), num2.ToString());
            using (StreamWriter writer = new StreamWriter(path2,false))
            {
                for (int i = 0; i < array.Length; i++)
                {
                   writer.Write(array[i]);
                    if (num>=i)
                    {
                        num += num;
                        progressBar1.Value++;
                    }
                   
                }
                progressBar1.Value = 100;

            }
          
            return true;

        }


        //private void PrintButton_Click(object sender, EventArgs e)
        //{
        //    PrintDialog printDlg = new PrintDialog();
        //    PrintDocument printDoc = new PrintDocument();
        //    printDoc.DocumentName = "Print Document";
        //    printDlg.Document = printDoc;
        //    printDlg.AllowSelection = true;
        //    printDlg.AllowSomePages = true;
        //    //Call ShowDialog  
        //    if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
        //}
        private void Starting()
        {
            if (ReadLine(path1, path2))
            {
                MessageBox.Show("close");
                Close();
            }
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
                        if (Check())
                        {
                            Thread thread = new Thread(Starting);
                            thread.Start();
                        };
                        ///

               
                        //
                        //PrintDialog pd = new PrintDialog();
                        //pd.PrinterSettings = new PrinterSettings();
                        //if (DialogResult.OK == pd.ShowDialog(this))
                        //{
                        //    // Print the file to the printer.
                        //    // RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ofd.FileName);
                        //}
                        //string path = "C:\\Users\\nihad\\OneDrive\\Masaüstü\\nihads.pdf";
                        //PrintDialog printDlg = new PrintDialog();
                        //PrintDocument printDoc = new PrintDocument();
                        //printDoc.DocumentName = path;
                        ////printDoc.DocumentName = "Print Document";
                        //printDlg.Document = printDoc;
                        //printDlg.AllowSelection = true;
                        //printDlg.AllowSomePages = true;
                        ////Call ShowDialog  
                        //if (printDlg.ShowDialog() == DialogResult.OK) printDoc.Print();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
