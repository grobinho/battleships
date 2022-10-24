using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships
{
    public class Field
    {
        public int x, y;
        public int shipID;
        public int status;

        public Field(int xcord, int ycord)
        {
            x = xcord;
            y = ycord;
            shipID = -1;
            status = 0;
        }

        public void ClearField()
        {
            this.shipID = -1;
            this.status = 0;
        }
    }
}
