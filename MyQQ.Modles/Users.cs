using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyQQ.Modles
{
    public class Users
    {
        private int _Id;
        private string _LoginPwd;
        private int _FriendshipPolicyId;
        private string _NickName;
        private int _FaceId;
        private string _Sex;
        private string _Age;
        private string _Name;
        private int _StarId;
        private int _BloodTypeId;

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

        public string LoginPwd
        {
            get
            {
                return _LoginPwd;
            }

            set
            {
                _LoginPwd = value;
            }
        }

        public int FriendshipPolicyId
        {
            get
            {
                return _FriendshipPolicyId;
            }

            set
            {
                _FriendshipPolicyId = value;
            }
        }

        public string NickName
        {
            get
            {
                return _NickName;
            }

            set
            {
                _NickName = value;
            }
        }

        public int FaceId
        {
            get
            {
                return _FaceId;
            }

            set
            {
                _FaceId = value;
            }
        }

        public string Sex
        {
            get
            {
                return _Sex;
            }

            set
            {
                _Sex = value;
            }
        }

        public string Age
        {
            get
            {
                return _Age;
            }

            set
            {
                _Age = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public int StarId
        {
            get
            {
                return _StarId;
            }

            set
            {
                _StarId = value;
            }
        }

        public int BloodTypeId
        {
            get
            {
                return _BloodTypeId;
            }

            set
            {
                _BloodTypeId = value;
            }
        }
    }
}
