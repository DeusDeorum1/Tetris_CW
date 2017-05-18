using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tetris_CW
{
    public partial class loadForm : Form
    {
        public Form mform;
        public DataGridView grd;
        public string saveDir = @"C:\Users\dimak\Documents\Tetris\Saves\";
        public string saveEx = ".txt";
        public loadForm(Form mainForm, DataGridView dt)
        {
            InitializeComponent();
            mform = mainForm;
            grd = dt;
            string[] savesF;
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }
            else
            {
                savesF = new string[Directory.GetFiles(saveDir).Length];
                for (int i = 0; i < Directory.GetFiles(saveDir).Length; i++)
                {
                    DirectoryInfo dir = new DirectoryInfo(saveDir);
                    string time = dir.GetFileSystemInfos()[i].CreationTime.ToShortDateString();
                    time = time + "\t" + dir.GetFileSystemInfos()[i].CreationTime.ToShortTimeString();
                    savesF[i] = Directory.GetFiles(saveDir)[i].ToString();
                    listBox1.Items.Add(savesF[i].Split('\\')[savesF[i].Split('\\').Length-1].Split('.')[0] + "\t" + time);
                    
                    
                }
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream temp = File.Open(saveDir + listBox1.SelectedItem.ToString().Split('\t')[0] + saveEx, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader strr = new StreamReader(temp);
            string s;
            string[] sTemp;
            int j = 0;
            while (strr.Peek() > -1)
            {
                
                s = strr.ReadLine();
                sTemp = s.Split('\t');
                for (int i = 0; i < sTemp.Length-1; i++)
                {
                    if (sTemp[i]=="B")
                    {
                        grd.Rows[j].Cells[i].Style.BackColor = Color.Black;
                    }
                    else
                    {
                        grd.Rows[j].Cells[i].Style.BackColor = Color.White;
                    }
                    
                }
                j++;
            }
            strr.Close();
            temp.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.SelectedItem.Delete();
            File.Delete(saveDir + listBox1.SelectedItem.ToString().Split('\t')[0] + saveEx);
            listBox1.Items.Remove(listBox1.SelectedIndex);
            listBox1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}
