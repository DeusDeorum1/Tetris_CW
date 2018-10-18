using System;
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
        public static int r = 0;        //Переменная для хранения кода ориентации фигуры
        public int startX = 0;          // |Переменные для хранения 
        public int startY = 3;          // |стартовой позиции фигур
        public static int tX = 0;              // |Переменные для хранения 
        public static int tY = 3;              // |текущей позиции фигур
        public static string currentFigure = "square";     // Переменная для хранения текущей фигуры
        public string tempFigure;                   // Переменная для хранения слеующей фигуры
        public static int score;                           // Переменная для хранения счёта
        public static string playerName;            // Переменная для имени текущего игрока
        public static Figures game = new Figures(); // Создание объекта фигур
        public static Engine eng;                   // | Создание объекта "движка" игры, контролирующего 
                                                    // | изменения игрового поля
        public Thread tickerThread;                 // Создание нового фонового потока
        public int savesCount = 0;
        public static int speed = 1000;
        public Player[] lst;
        public static string saveDir;
        public string saveEx = ".sv";
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            tickerThread = new Thread(ticker);
            tickerThread.IsBackground = true;
            for (int i = 0; i < 17; i++)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1.ClearSelection();
            eng = new Engine(game, dataGridView1,r, scoreLabel);
            eng.resetGrid();
            Engine.detectSaveDir(false);
            Engine.detectCurrPlayers(false);
            Engine.deserialize();
            playerNameLabel.Text = playerName;
            currentFigure = eng.changeFigure();
            Thread.Sleep(100);
            tempFigure = eng.changeFigure();
            nextFigureGrid.Rows.Add();
            nextFigureGrid.Rows.Add();
            nextFigureGrid.Rows.Add();
            nextFigureGrid.Rows.Add();
            nextFigureGrid.ClearSelection();
            //eng.drawNext(nextFigureGrid, tempFigure);
        }
        //Кнопка для запуска/паузы игры
        private void play_Click(object sender, EventArgs e)
        {
            
            if (!started)
            {
                if (!paused)
                {
                    tickerThread.Start();
                    eng.Draw(tX, tY, currentFigure);
                    started = true;
                    paused = false;
                    play.Refresh();
                    play.Text = "PAUSE";
                    dataGridView1.Select();
                    eng.drawNext(nextFigureGrid, tempFigure);

                }
                else
                {
                    tickerThread.Resume();
                    started = true;
                    paused = false;
                    play.Refresh();
                    play.Text = "PAUSE";
                    play.Refresh();
                    dataGridView1.Select();
                    eng.drawNext(nextFigureGrid, tempFigure);

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
        #region trash
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        #endregion
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
                catch(Exception)
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
                Thread.Sleep(speed);
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
                        this.Invoke(new Action(() => { speed = eng.addSpeed(false); }));
                        this.Invoke(new Action(() => { scoreLabel.Text = score.ToString(); }));
                        eng.drawNext(nextFigureGrid, tempFigure);
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
                    //leaderboardForm.players.Add(new Player { Name = playerName, Score = score });
                    this.Invoke(new Action(() => { scoreLabel.Text = score.ToString(); }));
                    eng.drawNext(nextFigureGrid, tempFigure);
                }
            } while (true);
        }
        //Кнопка для создания файла сохранения
        private void saveButton_Click(object sender, EventArgs e)
        {
            //C:\Users\dimak\Documents\Tetris\Saves\*.xml

            /*FileStream saveStream = new FileStream(@"C:\Users\dimak\Documents\Tetris\Saves\save" + savesCount + ".xml", FileMode.Create);
            XmlSerializer Ser = new XmlSerializer(typeof(Structure));
            for (int i = 0; i < 17; i++)
            {
                Structure str = new Structure(dataGridView1.Rows[i]);
                lst[i] = str;
            }
            Ser.Serialize(saveStream, lst);
            saveStream.Close();*/
            if (started)
            {
                play.PerformClick();
            }
            Engine.updateTable();
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
            FileStream temp = File.OpenWrite(saveDir + @"Save_" + q + saveEx);
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
                if (i==0)
                {
                    str.Write(tX + "\t" + tY + "\t" + currentFigure + "\t" + Engine.R + "\t");
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
            if (started)
            {
                play.PerformClick();
            }
            loadForm loadF = new loadForm(this, dataGridView1);
            loadF.Show();
        }
        //Кнопка для открытия таблицы лидеров
        private void liderboardButton_Click(object sender, EventArgs e)
        {
            if (started)
            {
                play.PerformClick();
            }
            //Engine.updateTable();
            leaderboardForm liderF = new leaderboardForm(this);
            liderF.Show();
        }
        //Кнопка для начала новой игры
        private void newGameButton_Click(object sender, EventArgs e)
        {
            if (started)
            {
                play.PerformClick();
            }
            eng.resetGrid();
            tX = startX;
            tY = startY;
            Engine.updateTable();
            currentFigure = eng.changeFigure();
            tempFigure = eng.changeFigure();
            score = 0;
            scoreLabel.Text = "0";
            speed = eng.addSpeed(true);
        }
        //Сериализация и обновление в реестре информации о последнем игроке
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Engine.updateTable();
            Engine.serialize();
            Engine.detectCurrPlayers(true);
        }
    }
}

