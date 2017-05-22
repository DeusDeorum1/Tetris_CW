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
        //public string saveDir = @"C:\Users\dimak\Documents\Tetris\Saves\";
        public string saveEx = ".sv";
        public loadForm(Form mainForm, DataGridView dt)
        {
            InitializeComponent();
            mform = mainForm;
            grd = dt;
            string[] savesF;
            if (!Directory.Exists(Form1.saveDir))
            {
                Directory.CreateDirectory(Form1.saveDir);
            }
            else
            {
                savesF = new string[Directory.GetFiles(Form1.saveDir).Length];
                for (int i = 0; i < Directory.GetFiles(Form1.saveDir).Length; i++)
                {
                    DirectoryInfo dir = new DirectoryInfo(Form1.saveDir);
                    string time = dir.GetFileSystemInfos()[i].CreationTime.ToShortDateString();
                    time = time + "\t" + dir.GetFileSystemInfos()[i].CreationTime.ToShortTimeString();
                    savesF[i] = Directory.GetFiles(Form1.saveDir)[i].ToString();
                    if (savesF[i].Split('\\')[savesF[i].Split('\\').Length-1].Split('.')[1]=="sv")
                    {
                        listBox1.Items.Add(savesF[i].Split('\\')[savesF[i].Split('\\').Length - 1].Split('.')[0] + "\t\t" + time);
                    }


                }
                
            }
            
        }
        //Кнопка для загрузки сохранения
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                FileStream temp = File.Open(Form1.saveDir + "\\" + listBox1.SelectedItem.ToString().Split('\t')[0] + saveEx, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader strr = new StreamReader(temp);
                string s;
                string[] sTemp;
                int j = 0;
                while (strr.Peek() > -1)
                {

                    s = strr.ReadLine();
                    sTemp = s.Split('\t');

                    for (int i = 0; i < sTemp.Length - 1; i++)
                    {
                        if ((i > 13))
                        {
                            Form1.tX = int.Parse(sTemp[sTemp.Length - 5]);
                            Form1.tY = int.Parse(sTemp[sTemp.Length - 4]);
                            Form1.currentFigure = sTemp[sTemp.Length - 3];
                            Engine.R = int.Parse(sTemp[sTemp.Length - 2]);
                        }
                        else
                        {
                            if (sTemp[i] == "B")
                            {
                                grd.Rows[j].Cells[i].Style.BackColor = Color.Black;
                            }
                            else
                            {
                                grd.Rows[j].Cells[i].Style.BackColor = Color.White;
                            }

                        }
                    }
                    j++;
                }
                strr.Close();
                temp.Close();
                this.Close();
            }
        }
        //Кнопка для удаления сохранения
        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.SelectedItem.Delete();
            File.Delete(Form1.saveDir + "\\" + listBox1.SelectedItem.ToString().Split('\t')[0] + saveEx);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.SelectedItem.ToString();
            this.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Form1.saveDir = folderBrowserDialog1.SelectedPath + "\\";
                listBox1.Items.Clear();
                string[] savesF;
                if (!Directory.Exists(Form1.saveDir))
                {
                    Directory.CreateDirectory(Form1.saveDir);
                }
                else
                {
                    savesF = new string[Directory.GetFiles(Form1.saveDir).Length];
                    for (int i = 0; i < Directory.GetFiles(Form1.saveDir).Length; i++)
                    {
                        DirectoryInfo dir = new DirectoryInfo(Form1.saveDir);
                        string time = dir.GetFileSystemInfos()[i].CreationTime.ToShortDateString();
                        time = time + "\t" + dir.GetFileSystemInfos()[i].CreationTime.ToShortTimeString();
                        savesF[i] = Directory.GetFiles(Form1.saveDir)[i].ToString();
                        if (savesF[i].Split('\\')[savesF[i].Split('\\').Length - 1].Split('.')[1] == "sv")
                        {
                            listBox1.Items.Add(savesF[i].Split('\\')[savesF[i].Split('\\').Length - 1].Split('.')[0] + "\t\t" + time);
                        }
                    }
                }
                Engine.detectSaveDir(true);
            }
        }
    }
}
