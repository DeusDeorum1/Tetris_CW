using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Tetris_CW
{
    public class Figures
    {
        
        public void sapog(int x, int y, DataGridView a, string Rotate, Color brush)
        {
            switch (Rotate)
            {
                case "Top":
                    a.Rows[x].Cells[y].Style.BackColor = brush;             //   *
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;         //   *
                    a.Rows[x + 2].Cells[y].Style.BackColor = brush;         //  **
                    a.Rows[x + 2].Cells[y + 1].Style.BackColor = brush;
                    break;
                case "Right":
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;          //    *
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush;      //  ***
                    a.Rows[x + 1].Cells[y + 2].Style.BackColor = brush;      //
                    a.Rows[x].Cells[y + 2].Style.BackColor = brush;
                    break;
                case "Left":
                    a.Rows[x].Cells[y].Style.BackColor = brush;         //  ***
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;     //  *
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;     //  
                    a.Rows[x].Cells[y + 2].Style.BackColor = brush;
                    break;
                case "Bottom":
                    a.Rows[x].Cells[y].Style.BackColor = brush;         //  **
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;     //   *
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush; //   *
                    a.Rows[x + 2].Cells[y + 1].Style.BackColor = brush;
                    break;
                default:
                    break;
            }
        }
        public void stripe(int x, int y, DataGridView a, string Rotate, Color brush)
        {
            switch (Rotate)
            {
                case "Top":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 2].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 3].Cells[y].Style.BackColor = brush;
                    break;
                case "Right":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 2].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 3].Style.BackColor = brush;
                    break;
                case "Left":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 2].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 3].Style.BackColor = brush;
                    break;
                case "Bottom":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 2].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 3].Cells[y].Style.BackColor = brush;
                    break;
                default:
                    break;
            }
        }
        public void square(int x, int y, DataGridView a, string Rotate, Color brush)
        {
            switch (Rotate)
            {
                case "Top":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    break;
                case "Right":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    break;
                case "Left":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    break;
                case "Bottom":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    break;
                default:
                    break;
            }
        }
        public void hat(int x, int y, DataGridView a, string Rotate, Color brush)
        {
            switch (Rotate)
            {
                case "Bottom":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 2].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y+1].Style.BackColor = brush;
                    break;
                case "Right":
                    a.Rows[x].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 2].Cells[y].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush;
                    break;
                case "Left":
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 2].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x + 1].Cells[y].Style.BackColor = brush;
                    break;
                case "Top":
                    a.Rows[x+1].Cells[y].Style.BackColor = brush;
                    a.Rows[x+1].Cells[y + 1].Style.BackColor = brush;
                    a.Rows[x+1].Cells[y + 2].Style.BackColor = brush;
                    a.Rows[x].Cells[y + 1].Style.BackColor = brush;
                    break;
                default:
                    break;
            }
        }
    }
}
