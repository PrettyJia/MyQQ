using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ.Modles
{
    /// <summary>
    /// 血型
    /// </summary>
    public class BloodType
    {
        private int _Id;
        private String _BloodType;

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

        public string BloodType
        {
            get
            {
                return _BloodType;
            }

            set
            {
                _BloodType = value;
            }
        }
    }
}
