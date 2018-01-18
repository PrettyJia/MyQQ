using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ.Modles
{
    /// <summary>
    /// 好友关系
    /// </summary>
    public class Friends
    {
        private int _Id;
        private int _HostId;
        private int _FriendId;

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

        public int HostId
        {
            get
            {
                return _HostId;
            }

            set
            {
                _HostId = value;
            }
        }

        public int FriendId
        {
            get
            {
                return _FriendId;
            }

            set
            {
                _FriendId = value;
            }
        }
    }
}
