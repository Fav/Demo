using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectElu
{
/// <summary>
/// class:  浜у搧
/// author: huqi
/// time:   2015年4月18日
/// </summary>
    public class PRODUCT : BaseDomain
	{
		string _ID;   //guid
		string _NAME;   //鍚嶇О
		string _UNIT;   //鍗曚綅
		string _DEPARTMENT;   //閮ㄩ棬
		string _INSTRUMENT;   //浠櫒
		string _CONTACTS;   //鑱旂郴浜?
		string _PHONE;   //鐢佃瘽
		DateTime? _STARTTIME;   //寮€濮嬩娇鐢ㄦ椂闂?

		 public string UNIT
		{
			 get { return _UNIT; }
			 set { _UNIT = value; }
		}
		 public string DEPARTMENT
		{
			 get { return _DEPARTMENT; }
			 set { _DEPARTMENT = value; }
		}
		 public string INSTRUMENT
		{
			 get { return _INSTRUMENT; }
			 set { _INSTRUMENT = value; }
		}
		 public string CONTACTS
		{
			 get { return _CONTACTS; }
			 set { _CONTACTS = value; }
		}
		 public string PHONE
		{
			 get { return _PHONE; }
			 set { _PHONE = value; }
		}
		 public DateTime? STARTTIME
		{
			 get { return _STARTTIME; }
			 set { _STARTTIME = value; }
		}
         public string NAME
         {
             get { return _NAME; }
             set { _NAME = value; }
         }
         public string ID
         {
             get { return _ID; }
             set { _ID = value; }
         }
	}
}
