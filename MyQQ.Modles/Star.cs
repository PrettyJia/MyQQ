using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ.Modles
{
    /// <summary>
    /// 星座
    /// </summary>
    public class Star
    {
        private int _Id;
        private string _StarName;

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

        public string StarName
        {
            get
            {
                return _StarName;
            }

            set
            {
                _StarName = value;
            }
        }
    }
}
