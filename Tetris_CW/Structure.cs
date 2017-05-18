using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_CW
{
    public class Structure
    {
        public string[] array { get; set; }
        public Structure()
        {

        } 
        public Structure(DataGridViewRow currentDataDridViewRow)
        {
            array = new string[14];
            
            
                for (int j = 0; j < 14; j++)
                {
                    array[j] = currentDataDridViewRow.Cells[j].Style.BackColor.ToString();
                }
            
        }
    }
}
