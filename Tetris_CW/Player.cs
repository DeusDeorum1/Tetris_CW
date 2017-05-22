using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_CW
{
    public class Player : IComparable
    {
        public string    Name { get; set; }
        public int       Score { get; set; }
        public Player(){        } 
        public override string ToString()
        {
            return Name + ":" + Score;
        }
        public int CompareTo(object o)
        {
            Player p = o as Player;
            if (p != null)
            {
                return this.Score.CompareTo(p.Score);
            }
            else
            {
                throw new Exception("Unable to compare objects!");
            }
        }
    }
}
