using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Microsoft.Win32;

namespace Tetris_CW
{
    public class Engine
    {
        public Figures fg;
        public DataGridView grd;
        public static int R;
        public Label scoreL;

        //Конструктор
        public Engine(Figures  game, DataGridView a, int r, Label sL)
        {
            fg = game;
            grd = a;
            R = r;
            scoreL = sL;
        }
        //Проверка возможности сдвинуть фигуру
        public bool checkMove(int x, int y, string figure, string direction)
        {
            bool f = true;
            try
            {
                switch (direction)
                {
                    //Проверка движения влево
                    case "left"://checked
                        y--;
                        if (y >= 0)
                        {
                            switch (figure)
                            {
                                //Проверка возможность подвинуть влево "шляпу"
                                case "hat"://checked
                                    switch (rotationDetect())
                                    {
                                        case "Top"://checked
                                            if (grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }
                                            break;
                                        case "Right"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Left"://checked
                                            if (grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Bottom"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        default:
                                            f = false;
                                            break;
                                    }
                                    break;
                                //Проверка возможность подвинуть влево линию
                                case "stripe"://checked
                                    switch (rotationDetect())
                                    {
                                        case "Top"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 3].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Right"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Left"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Bottom"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 3].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        default:
                                            f = false;
                                            break;
                                    }
                                    break;
                                //Проверка возможность подвинуть влево сапог
                                case "sapog"://checked
                                    switch (rotationDetect())
                                    {
                                        case "Top"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Right"://checked
                                            if (grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Left"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Bottom"://checked
                                            if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        default:
                                            f = false;
                                            break;
                                    }
                                    break;
                                //Проверка возможность подвинуть влево квадрат
                                case "square"://checked
                                    if (grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                        grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black)
                                    {
                                        f = false;
                                    }
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    case "right"://checked
                        y++;
                        int rb = 14;
                        if (y <= rb)
                        {
                            switch (figure)
                            {
                                //Проверка возможность подвинуть вправо "шляпу"
                                case "hat"://checked
                                    switch (rotationDetect())
                                    {
                                        case "Top"://checked
                                            if ((y + 3 > rb) ||
                                                grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y + 2].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Right"://checked
                                            if ((y + 1 > rb) ||
                                                grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Left"://checked
                                            if ((y + 1 > rb) ||
                                                grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Bottom"://checked
                                            if ((y + 3 > rb) ||
                                                grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        default:
                                            f = false;
                                            break;
                                    }
                                    break;
                                //Проверка возможность подвинуть вправо линию
                                case "stripe"://checked
                                    switch (rotationDetect())
                                    {
                                        case "Top"://checked
                                            if ((y > rb) ||
                                                grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 3].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Right"://checked
                                            if ((y + 3 > rb) ||
                                                grd.Rows[x].Cells[y + 3].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Left"://checked
                                            if ((y + 3 > rb) ||
                                                grd.Rows[x].Cells[y + 3].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Bottom"://checked
                                            if ((y > rb) ||
                                                grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 3].Cells[y].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        default:
                                            f = false;
                                            break;
                                    }
                                    break;
                                //Проверка возможность подвинуть вправо сапог
                                case "sapog"://checked
                                    switch (rotationDetect())
                                    {
                                        case "Top"://checked
                                            if ((y + 1 > rb) ||
                                                grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Right"://checked
                                            if ((y + 2 > rb) ||
                                                grd.Rows[x + 1].Cells[y + 2].Style.BackColor == Color.Black ||
                                                grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Left"://checked
                                            if ((y + 2 > rb) ||
                                                grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                                grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        case "Bottom"://checked
                                            if ((y + 1 > rb) ||
                                                grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                                grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                            {
                                                f = false;
                                            }

                                            break;
                                        default:
                                            f = false;
                                            break;
                                    }
                                    break;
                                //Проверка возможность подвинуть вправо квадрат
                                case "square"://checked
                                    if ((y + 1 > rb) ||
                                        grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                        grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black)
                                    {
                                        f = false;
                                    }
                                    else
                                    {
                                        f = true;
                                    }
                                    break;
                            }
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    case "down"://checked
                        x++;
                        switch (figure)
                        {
                            //Проверка возможность подвинуть вниз "шляпу"
                            case "hat"://checked
                                switch (rotationDetect())
                                {
                                    case "Top"://checked
                                        if ((x + 1 > 17) ||
                                            grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 1].Cells[y + 2].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }
                                        break;
                                    case "Right"://checked
                                        if ((x + 2 > 17) ||
                                            grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black || (x + 2 == 17))
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Left"://checked
                                        if ((x + 2 > 17) ||
                                            grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Bottom"://checked
                                        if ((x + 1 > 17) ||
                                            grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    default:
                                        f = false;
                                        break;
                                }
                                break;
                            //Проверка возможность подвинуть вниз линию
                            case "stripe"://checked
                                switch (rotationDetect())
                                {
                                    case "Top"://checked
                                        if ((x + 3 > 17) ||
                                            grd.Rows[x + 3].Cells[y].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Right"://checked
                                        if ((x > 17) ||
                                            grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 3].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Left"://checked
                                        if ((x > 17) ||
                                            grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 3].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Bottom"://checked
                                        if ((x + 3 > 17) ||
                                            grd.Rows[x + 3].Cells[y].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    default:
                                        f = false;
                                        break;
                                }
                                break;
                            //Проверка возможность подвинуть вниз сапог
                            case "sapog"://checked
                                switch (rotationDetect())
                                {
                                    case "Top"://Checked
                                        if ((x + 2 > 17) ||
                                            grd.Rows[x + 2].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Right"://Checked
                                        if ((x + 1 > 17) ||
                                            grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 1].Cells[y + 2].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Left"://Checked
                                        if ((x + 1 > 17) ||
                                            grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 1].Style.BackColor == Color.Black ||
                                            grd.Rows[x].Cells[y + 2].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    case "Bottom"://Checked
                                        if ((x + 2 > 17) ||
                                            grd.Rows[x].Cells[y].Style.BackColor == Color.Black ||
                                            grd.Rows[x + 2].Cells[y + 1].Style.BackColor == Color.Black)
                                        {
                                            f = false;
                                        }

                                        break;
                                    default:
                                        f = false;
                                        break;
                                }
                                break;
                            //Проверка возможность подвинуть вниз квадрат
                            case "square"://Checked
                                if ((x + 1 > 17) ||
                                    grd.Rows[x + 1].Cells[y + 1].Style.BackColor == Color.Black ||
                                    grd.Rows[x + 1].Cells[y].Style.BackColor == Color.Black)
                                {
                                    f = false;
                                }

                                break;
                        }
                        break;
                    default:

                        break;
                }

            }
            catch (Exception)
            {
                f = false;

            }
            return f;
        }
        //Определение ориентации фигуры
        public string rotationDetect()
        {
            switch (R)
            {
                case 0:
                    return "Top";
                case 1:
                    return "Right";
                case 2:
                    return "Bottom";
                case 3:
                    return "Left";
                default:
                    return "";
            }
        }
        //Первичная отрисовка
        public void Draw(int x, int y, string figure)
        {
            switch (figure)
            {
                case "hat":
                    fg.hat(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "stripe":
                    fg.stripe(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "sapog":
                    fg.sapog(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "square":
                    fg.square(x, y, grd, rotationDetect(), Color.Black);
                    break;
                default:
                    break;
            }
        }
        //Смещение вниз
        public void MoveDown(int x, int y, string figure)
        {
            switch (figure)
            {
                case "hat":
                    fg.hat(x, y, grd, rotationDetect(), Color.White);
                    fg.hat(x + 1, y, grd, rotationDetect(), Color.Black);
                    break;
                case "stripe":
                    fg.stripe(x, y, grd, rotationDetect(), Color.White);
                    fg.stripe(x + 1, y, grd, rotationDetect(), Color.Black);
                    break;
                case "sapog":
                    fg.sapog(x, y, grd, rotationDetect(), Color.White);
                    fg.sapog(x + 1, y, grd, rotationDetect(), Color.Black);
                    break;
                case "square":
                    fg.square(x, y, grd, rotationDetect(), Color.White);
                    fg.square(x + 1, y, grd, rotationDetect(), Color.Black);
                    break;
                default:
                    break;
            }
        }
        //Откат в случае неверного перемещения вниз
        public void Abort(int x, int y, string figure)
        {
            switch (figure)
            {
                case "hat":
                    fg.hat(x, y, grd, rotationDetect(), Color.White);
                    fg.hat(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "stripe":
                    fg.stripe(x, y, grd, rotationDetect(), Color.White);
                    fg.stripe(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "sapog":
                    fg.sapog(x, y, grd, rotationDetect(), Color.White);
                    fg.sapog(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "square":
                    fg.square(x, y, grd, rotationDetect(), Color.White);
                    fg.square(x, y, grd, rotationDetect(), Color.Black);
                    break;
                default:
                    break;
            }
        }
        //Смещение влево
        public void MoveLeft(int x, int y, string figure)
        {
            switch (figure)
            {
                case "hat":
                    fg.hat(x, y, grd, rotationDetect(), Color.White);
                    fg.hat(x, y-1, grd, rotationDetect(), Color.Black);
                    break;
                case "stripe":
                    fg.stripe(x, y, grd, rotationDetect(), Color.White);
                    fg.stripe(x, y-1, grd, rotationDetect(), Color.Black);
                    break;
                case "sapog":
                    fg.sapog(x, y, grd, rotationDetect(), Color.White);
                    fg.sapog(x, y-1, grd, rotationDetect(), Color.Black);
                    break;
                case "square":
                    fg.square(x, y, grd, rotationDetect(), Color.White);
                    fg.square(x, y-1, grd, rotationDetect(), Color.Black);
                    break;
                default:
                    break;
            }
        }
        //Смещение вправо
        public void MoveRight(int x, int y, string figure)
        {
            switch (figure)
            {
                case "hat":
                    fg.hat(x, y, grd, rotationDetect(), Color.White);
                    fg.hat(x, y+1, grd, rotationDetect(), Color.Black);
                    break;
                case "stripe":
                    fg.stripe(x, y, grd, rotationDetect(), Color.White);
                    fg.stripe(x, y+1, grd, rotationDetect(), Color.Black);
                    break;
                case "sapog":
                    fg.sapog(x, y, grd, rotationDetect(), Color.White);
                    fg.sapog(x, y+1, grd, rotationDetect(), Color.Black);
                    break;
                case "square":
                    fg.square(x, y, grd, rotationDetect(), Color.White);
                    fg.square(x, y+1, grd, rotationDetect(), Color.Black);
                    break;
                default:
                    break;
            }
        }
        //Смена ориентации фигуры
        public void chngRotation(int x, int y, string figure)
        {
            switch (figure)
            {
                case "hat":
                    fg.hat(x, y, grd, rotationDetect(), Color.White);
                    break;
                case "stripe":
                    fg.stripe(x, y, grd, rotationDetect(), Color.White);
                    break;
                case "sapog":
                    fg.sapog(x, y, grd, rotationDetect(), Color.White);
                    break;
                case "square":
                    fg.square(x, y, grd, rotationDetect(), Color.White);
                    break;
                default:
                    break;
            }
            switch (R)
            {
                case 0:
                    R++;
                    break;
                case 1:
                    R++;
                    break;
                case 2:
                    R++;
                    break;
                case 3:
                    R = 0;
                    break;
                default:
                    break;
            }
            switch (figure)
            {
                case "hat":  
                    fg.hat(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "stripe":
                    fg.stripe(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "sapog":
                    fg.sapog(x, y, grd, rotationDetect(), Color.Black);
                    break;
                case "square":
                    fg.square(x, y, grd, rotationDetect(), Color.Black);
                    break;
                default:
                    break;
            }
        }
        //Смена фигуры
        public string changeFigure()
        {
            Random rnd = new Random();
            switch (rnd.Next(0,100)%4)
            {
                case 0:
                    return "sapog";
                case 1:
                    return "hat";
                case 2:
                    return "stripe";
                case 3:
                    return "square";
                default:
                    return "square";
            }
        }
        /*drawing next figure
        public void drawNext(string nextFigure)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            switch (nextFigure)
            {
                case "hat":
                    checkBox1.Checked = true;
                    checkBox2.Checked = true;
                    checkBox3.Checked = true;
                    checkBox5.Checked = true;
                    break;
                case "stripe":
                    checkBox2.Checked = true;
                    checkBox5.Checked = true;
                    checkBox8.Checked = true;
                    checkBox11.Checked = true;
                    break;
                case "sapog":
                    checkBox2.Checked = true;
                    checkBox5.Checked = true;
                    checkBox8.Checked = true;
                    checkBox11.Checked = true;
                    checkBox12.Checked = true;
                    break;
                case "square":
                    checkBox5.Checked = true;
                    checkBox6.Checked = true;
                    checkBox8.Checked = true;
                    checkBox9.Checked = true;

                    break;
                default:
                    break;
            }
        }*/
        public void resetGrid()
        {
            for (int i = 0; i < 17; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    grd.Rows[i].Cells[j].Style.BackColor = Color.White;
                    grd.Rows[i].Cells[j].Value = "";
                }
            }
        }
        //Ведение счёта
        public int scoreCount()
        {
            bool f;
            bool found = false;
            int scr = 0;
            int index = 10;
            for (int i = 0; i < 17; i++)
            {
                f = true;
                
                for (int j = 0; j < 14; j++)
                {
                    if ((grd.Rows[i].Cells[j].Style.BackColor == Color.Black)&&(!found))
                    {
                        index = i;
                        found = true;
                    }
                    if (grd.Rows[i].Cells[j].Style.BackColor == Color.White)
                    {
                        f = false;
                    }
                }
                if (f)
                {
                    scr = scr + 10;
                    for (int h = 0; h < 14; h++)
                    {
                        grd.Rows[i].Cells[h].Style.BackColor = Color.White;
                    }
                    for (int k = i; k > index-1; k--)
                    {
                        for (int h = 0; h < 14; h++)
                        {
                            grd.Rows[k].Cells[h].Style.BackColor = grd.Rows[k - 1].Cells[h].Style.BackColor;
                        }
                    }
                    
                }
                if (index <= 1)
                {
                    for (int q = 4; q < 10; q++)
                    {
                        grd.Rows[7].Cells[q].Style.BackColor = Color.Aquamarine;
                    }
                    grd.Rows[7].Cells[4].Value = "L";
                    grd.Rows[7].Cells[5].Value = "O";
                    grd.Rows[7].Cells[6].Value = "O";
                    grd.Rows[7].Cells[7].Value = "S";
                    grd.Rows[7].Cells[8].Value = "E";
                    grd.Rows[7].Cells[9].Value = "R";
                    Thread.Sleep(1500);
                    resetGrid();
                }
            }
            return scr;
        }
        //Поиск информации по папке сохранений в реестре и доабвление таковой, если её нет
        public static void detectSaveDir(bool refresh)
        {
            RegistryKey currUser = Registry.CurrentUser;
            RegistryKey soft = currUser.OpenSubKey("Software",true);
            RegistryKey tetrisApp = soft.CreateSubKey("MyTetris");
            if (!refresh)
            {
                if (tetrisApp.GetValue("saveDir") == null)
                {
                    tetrisApp.SetValue("saveDir", @"C:\Users\dimak\Documents\Tetris\Saves\");
                    Form1.saveDir = @"C:\Users\dimak\Documents\Tetris\Saves\";
                }
                else
                {
                    Form1.saveDir = tetrisApp.GetValue("saveDir").ToString();
                }
            }
            else
            {
                tetrisApp.SetValue("saveDir", Form1.saveDir);
            }
            tetrisApp.Close();
            soft.Close();
            currUser.Close();
        }
    }
}
