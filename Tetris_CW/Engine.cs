using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;

namespace Tetris_CW
{
    public class Engine
    {
        public Figures fg;
        public DataGridView grd;
        public static int R;
        public Label scoreL;
        public Color brush = Color.Black; 
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
        public void chngRotation(int x, int y, string figure, bool abort)
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
                    R = 3;
                    break;
                case 1:
                    R--;
                    break;
                case 2:
                    R--;
                    break;
                case 3:
                    R--;
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
        public void drawNext(DataGridView nfG,string nextFigure)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    nfG.Rows[j].Cells[i].Style.BackColor = Color.White;
                }
            }
            switch (nextFigure)
            {
                case "hat":
                    fg.hat(0, 0, nfG, "Top", brush);
                    break;
                case "stripe":
                    fg.stripe(0, 0, nfG, "Top", brush);
                    break;
                case "sapog":
                    fg.sapog(0, 0, nfG, "Top", brush);
                    break;
                case "square":
                    fg.square(0, 0, nfG, "Top", brush);
                    break;
                default:
                    break;
            }
        }
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
                    if ((grd.Rows[i].Cells[j].Style.BackColor == Color.Black) && (!found))
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
                    for (int k = i; k > index - 1; k--)
                    {
                        for (int h = 0; h < 14; h++)
                        {
                            grd.Rows[k].Cells[h].Style.BackColor = grd.Rows[k - 1].Cells[h].Style.BackColor;
                        }
                    }

                }

            }
            if (index <= 1)
            {
                for (int q = 4; q < 10; q++)
                {
                    grd.Rows[7].Cells[q].Style.BackColor = Color.Aquamarine;
                }
                grd.Rows[7].Cells[4].Value = "L"; Thread.Sleep(400);
                grd.Rows[7].Cells[5].Value = "O"; Thread.Sleep(400);
                grd.Rows[7].Cells[6].Value = "O"; Thread.Sleep(400);
                grd.Rows[7].Cells[7].Value = "S"; Thread.Sleep(400);
                grd.Rows[7].Cells[8].Value = "E"; Thread.Sleep(400);
                grd.Rows[7].Cells[9].Value = "R"; Thread.Sleep(400);
                Thread.Sleep(4000);
                resetGrid();
                updateTable();
            }
            return scr;
        }

        //Метод для увеличения скорости игры
        public int addSpeed(bool refresh)
        {
            if (refresh)
            {
                if (Form1.speed < 200)
                {
                    //Form1.speed = Form1.speed - 100;
                    return (Form1.speed/2);
                }
                return Form1.speed;
            }
            else
            {
                return Form1.speed = 1000;
            }
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
                    tetrisApp.SetValue("saveDir", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Tetris\Saves\");
                    Form1.saveDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\Tetris\Saves\";
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

        //Поиск информации имени игрока в реестре и доабвление стандартного игрока "Player", если её нет
        public static void detectCurrPlayers(bool refresh)
        {
            RegistryKey currUser = Registry.CurrentUser;
            RegistryKey soft = currUser.OpenSubKey("Software", true);
            RegistryKey tetrisApp = soft.CreateSubKey("MyTetris");
            if (!refresh)
            {
                if (tetrisApp.GetValue("playerName") == null)
                {
                    tetrisApp.SetValue("playerName", "Player");
                    Form1.playerName = "Player";
                }
                else
                {
                    Form1.playerName = tetrisApp.GetValue("playerName").ToString();
                }
            }
            else
            {
                tetrisApp.SetValue("playerName", Form1.playerName);
            }
            tetrisApp.Close();
            soft.Close();
            currUser.Close();
        }
        //Метод для сериализации таблицы лидеров
        public static void serialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Player>));
            if (!Directory.Exists(Environment.CurrentDirectory + @"\res\"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + @"\res\");
            }
            FileStream writer = new FileStream(Environment.CurrentDirectory + @"\res\table.xml", FileMode.Create);
            xml.Serialize(writer, leaderboardForm.players);
            xml = null; 
            writer.Close();
        }
        //Метод для десериализации таблицы лидеров
        public static void deserialize()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Player>));
            if (Directory.Exists(Environment.CurrentDirectory + @"\res\"))
            {
                FileStream reader = new FileStream(Environment.CurrentDirectory + @"\res\table.xml", FileMode.OpenOrCreate);
                leaderboardForm.players = (List<Player>)xml.Deserialize(reader);
                xml = null;
                reader.Close();
            }
        }
        //Метод для обновления имени текущего игрока на главной форме 'Form1'
        public static void updatePlayerName(Form1 form)
        {
            form.playerNameLabel.Text = Form1.playerName;
        }
        //Метод для обновления информации в таблице лидеров
        public static void updateTable()
        {
            if (leaderboardForm.players.Count() < 7)
            {
                leaderboardForm.players.Add(new Player { Name = Form1.playerName, Score = Form1.score });
                leaderboardForm.players.Sort();
                leaderboardForm.players.Reverse();

            }
            else
            {
                foreach (Player pl in leaderboardForm.players)
                {
                    if (pl.Score < Form1.score)
                    {
                        int ind = leaderboardForm.players.FindIndex(x => x.Score == pl.Score);
                        leaderboardForm.players.Insert(ind, new Player { Name = Form1.playerName, Score = Form1.score });
                        leaderboardForm.players.RemoveAt(leaderboardForm.players.Count() - 1);
                        leaderboardForm.players.Sort();
                        leaderboardForm.players.Reverse();
                        break;
                    }
                }
            }
        }
        /*public static void updateTable(string name)
        {
            if (leaderboardForm.players.Count() < 7)
            {
                leaderboardForm.players.Add(new Player { Name = name, Score = Form1.score });
                leaderboardForm.players.Sort();
            }
            else
            {
                if (leaderboardForm.players.Exists(x => x.Name == Form1.playerName))
                {
                    foreach (Player pl in leaderboardForm.players)
                    {
                        if (pl)
                        {

                        }
                    }
                    //leaderboardForm.players.FindIndex(,x => x.Name == Form1.playerName)
                }
            }
        }*/
    }
}
