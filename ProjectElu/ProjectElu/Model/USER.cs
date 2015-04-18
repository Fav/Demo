using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectElu
{
    /// <summary>
    /// class:  瑙掕壊
    /// author: huqi
    /// time:   2015年4月18日
    /// </summary>
    public class USER:BaseDomain
    {
        string _ID;   //瑙掕壊搴忓彿
        string _USERNAME;   //瑙掕壊鎻忚堪
        string _PASSWORD;   //瑙掕壊鎻忚堪
        int? _ROLETYPE;   //瑙掕壊鎻忚堪
        string _UNIT;   //瑙掕壊鎻忚堪

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
        }
        public int? ROLETYPE
        {
            get { return _ROLETYPE; }
            set { _ROLETYPE = value; }
        }
        public string UNIT
        {
            get { return _UNIT; }
            set { _UNIT = value; }
        }
    }
}
