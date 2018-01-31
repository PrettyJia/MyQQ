using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 飞行棋
{
    public class Util
    {
        public static void GenericSeat(int[] seats)
        {
            switch (seats.Length)
            {
                case 0:
                    seats[0] = 1;
                    seats[1] = 2;
                    seats[2] = 3;
                    seats[3] = 4;
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }
    }
}
