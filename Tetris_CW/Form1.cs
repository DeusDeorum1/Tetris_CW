﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Tetris_CW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        #region Variables
        public bool started = false;    //Флаг для определения, была ли запущена игра
        public bool paused = false;     //Флаг для определения, была ли игра  поставлена на пузу
        public int r = 0;               //Переменная для хранения кода ориентации фигуры
        public int startX = 0;          // |Переменные для хранения 
        public int startY = 3;          // |стартовой позиции фигур
        public int tX = 0;              // |Переменные для хранения 
        public int tY = 3;              // |текущей позиции фигур
        public string currentFigure = "square";     // Переменная для хранения текущей фигуры
        public string tempFigure;                   // Переменная для хранения слеующей фигуры
        public int score;                           // Переменная для хранения счёта
        public static Figures game = new Figures(); // Создание объекта фигур
        public static Engine eng;                   // | Создание объекта "движка" игры, контролирующего 
                                                    // | изменения игрового поля
        public Thread tickerThread;                 // Создание нового фонового потока
        public int savesCount = 0;
        public Structure[] lst;
        public string saveDir = @"C:\Users\dimak\Documents\Tetris\Saves\";
        public string saveEx = ".txt";
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            tickerThread = new Thread(ticker);
            for (int i = 0; i < 17; i++)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1.ClearSelection();
            eng = new Engine(game, dataGridView1,r);
            eng.resetGrid();
            currentFigure = eng.changeFigure();
            tempFigure = eng.changeFigure();            
        }

        //Кнопка для запуска/паузы игры
        private void play_Click(object sender, EventArgs e)
        {
            
            if (!started)
            {
                if (!paused)
                {
                    tickerThread.Start();
                    eng.Draw(startX, startY, currentFigure);
                    started = true;
                    paused = false;
                    play.Refresh();
                    play.Text = "PAUSE";
                    
                }
                else
                {
                    tickerThread.Resume();
                    started = true;
                    paused = false;
                    play.Refresh();
                    play.Text = "PAUSE";
                    play.Refresh();
                }
                
            }
            else
            {
                tickerThread.Suspend();
                started = false;
                paused = true;
                play.Text = "PLAY";
            }
            
        }

        
        //Кнопка для поворота фигуры
        private void button1_Click(object sender, EventArgs e)
        {
            eng.chngRotation(tX, tY, currentFigure);
            
        }
        //Кнопка для движения вниз
        private void button2_Click(object sender, EventArgs e)
        {
            eng.MoveDown(tX++, tY, currentFigure);
        }

        //#trash
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        //#endoftrash

        
        //Обработчик нажатий клавиш
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left)
            {
                if (eng.checkMove(tX,tY,currentFigure,"left"))
                {
                    eng.MoveLeft(tX, tY, currentFigure);
                    tY--;
                }
            }
            if (e.KeyData == Keys.Right)
            {
                if (eng.checkMove(tX, tY, currentFigure, "right"))
                {
                    eng.MoveRight(tX, tY, currentFigure);
                    tY++;
                }
               
            }
            if (e.KeyData == Keys.Down)
            {
                try
                {
                    if (eng.checkMove(tX, tY, currentFigure, "down"))
                    {
                        eng.MoveDown(tX, tY, currentFigure);
                        tX++;
                    }
                }
                catch
                {
                    tX--;
                    eng.MoveDown(tX, tY, currentFigure);
                }
            }
            if (e.KeyData == Keys.Space)
            {
                try
                {
                    eng.chngRotation(tX, tY, currentFigure);
                }
                catch
                {
                }
            }
            if (e.KeyData == Keys.G)
            {
                tX = startX;
                tY = startY;
                scoreLabel.Text = eng.scoreCount().ToString();
                currentFigure = eng.changeFigure();
                eng.Draw(startX, startY, currentFigure);
            }
            
        }


        #region trash
        private void dataGridView1_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 16)
            {
                
            }
        }

        private void dataGridView1_CellStyleContentChanged(object sender, DataGridViewCellStyleContentChangedEventArgs e)
        {
            //if (e.Ce== 16)
            //{
            //    tX = startX;
            //    tY = startY;
            //}
        }
        #endregion


        //метод фонового процесса обновления состояния поля 
        public void ticker()
        {
            do
            {
                Thread.Sleep(1000);
                try
                {
                    if (eng.checkMove(tX, tY, currentFigure, "down"))
                    {
                        eng.MoveDown(tX, tY, currentFigure);
                        tX++;
                    }
                    else
                    {
                        tX = startX;
                        tY = startY;
                        currentFigure = tempFigure;
                        tempFigure = eng.changeFigure();
                        score = score + eng.scoreCount();
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        eng.Abort(tX, tY, currentFigure);
                    }
                    catch (Exception)
                    {                    }
                    tX = startX;
                    tY = startY;
                    currentFigure = tempFigure;
                    tempFigure = eng.changeFigure();
                    score = score + eng.scoreCount();
                    //scoreLabel.Text = score.ToString();
                }
            } while (true);
        }


        //Кнопка для создания файла сохранения
        private void saveButton_Click(object sender, EventArgs e)
        {
            //C:\Users\dimak\Documents\Tetris\Saves\*.xml
            /*
            FileStream saveStream = new FileStream(@"C:\Users\dimak\Documents\Tetris\Saves\save" + savesCount + ".xml", FileMode.Create);
            XmlSerializer Ser = new XmlSerializer(typeof(Structure));
            for (int i = 0; i < 17; i++)
            {
                Structure str = new Structure(dataGridView1.Rows[i]);
                lst[i] = str;
            }
            Ser.Serialize(saveStream, lst);
            saveStream.Close();
            */
            int q = 0;
            if (Directory.Exists(saveDir))
            {
                foreach (var item in Directory.GetFiles(saveDir))
                {
                    if ((saveDir + "Save_" + q + saveEx).ToUpper() == item.ToUpper())
                    {
                        q++; 
                    }
                    else
                    {
                        break;
                    }
                }
                //int length = .Length - 1;
                //q = int.Parse(Directory.GetFiles(saveDir)[length].Split('\\')[length].Split('.')[0].Split('_')[1].ToString());
            }
            else
            {
                Directory.CreateDirectory(saveDir);
            }
            FileStream temp = File.OpenWrite(saveDir + "Save_" + q + saveEx);
            StreamWriter str = new StreamWriter(temp);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.Black)
                    {
                        str.Write("B" + "\t");
                    }
                    else
                    {
                        str.Write("W" + "\t");
                    }
                    
                }
                if (i != dataGridView1.Rows.Count - 1)
                {
                    str.WriteLine();
                }

            }
            str.Close();
            temp.Close();
            
        }
    
        //Кнопка для загрузки сохранения из файла
        private void loadButton_Click(object sender, EventArgs e)
        {
            loadForm loadF = new loadForm(this,dataGridView1);
            loadF.Show();
        }
    }
}
