using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ProjectElu
{
/// <summary>
/// class:  角色
/// author: huqi
/// time:   2015年4月18日
/// </summary>
public class ROLE : BaseDomain
	{
		int? _ROLEID;   //角色序号
		string _DESCRIPE;   //角色描述

		 public int? ROLEID
		{
			 get { return _ROLEID; }
			 set { _ROLEID = value; }
		}
		 public string DESCRIPE
		{
			 get { return _DESCRIPE; }
			 set { _DESCRIPE = value; }
		}
	}
}
