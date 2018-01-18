using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ.Modles
{
    public class MessageType
    {
        private int _Id          ;
        private string _MessageType;

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }
    }
}
