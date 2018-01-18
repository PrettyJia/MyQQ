using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ.Modles
{
    /// <summary>
    /// 好友添加类型
    /// </summary>
    public class FriendshipPolicy
    {
        private int _Id;
        private string _Friendship;

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

        public string Friendship
        {
            get
            {
                return _Friendship;
            }

            set
            {
                _Friendship = value;
            }
        }
    }
}
