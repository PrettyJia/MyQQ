using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ.Modles
{
    public class Messages
    {
        private int _Id;
        private int _FromUserId;
        private int _ToUserId;
        private string _Message;
        private int _MessageTypeId;
        private int _MessageState;
        private DateTime _MessageTime;

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

        public int FromUserId
        {
            get
            {
                return _FromUserId;
            }

            set
            {
                _FromUserId = value;
            }
        }

        public int ToUserId
        {
            get
            {
                return _ToUserId;
            }

            set
            {
                _ToUserId = value;
            }
        }

        public string Message
        {
            get
            {
                return _Message;
            }

            set
            {
                _Message = value;
            }
        }

        public int MessageTypeId
        {
            get
            {
                return _MessageTypeId;
            }

            set
            {
                _MessageTypeId = value;
            }
        }

        public int MessageState
        {
            get
            {
                return _MessageState;
            }

            set
            {
                _MessageState = value;
            }
        }

        public DateTime MessageTime
        {
            get
            {
                return _MessageTime;
            }

            set
            {
                _MessageTime = value;
            }
        }
    }
}
