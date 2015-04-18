using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectElu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pri = new Random(new Guid().GetHashCode()).Next(100);
            ////插入
            //BaseDA.Insert<PRODUCT>(new PRODUCT()
            //{
            //    ID = pri.ToString(),
            //    UNIT = "sdg",
            //    INSTRUMENT = "a s",
            //    //SignDate = DateTime.Now,
            //    //UpdateDate = DateTime.Now
            //});
            //BaseDA.Insert<USER>(new USER (){ ID="asdf "});
            for (int i = 10; i < 15; i++)
            {
                BaseDA.Insert<ROLE>(new ROLE() { ROLEID = i, DESCRIPE = "管理员" });
            }
            ////查单条记录
            //var model = BaseDA.Get<PRODUCT>( pri);
            //ShowProduct(model);

            //Response.Write("<hr/>");

            ////修改记录
            //if (model != null)
            //{
            //    model.INSTRUMENT = (new Random().Next(0, 99999999)).ToString().PadLeft(10, '0');
            //    int updateResult = BaseDA.Update<PRODUCT>(model);
            //    Response.Write("update影响行数:" + updateResult + "<br/><hr/>");
            //}

            ////查列表
            //var products = BaseDA.QueryForList<PRODUCT>();

            //foreach (var pro in products)
            //{
            //    ShowProduct(pro);
            //}

            //Response.Write("<hr/>");

            ////删除记录
            //int deleteResult = BaseDA.Delete("PRODUCT", pri);
            //Response.Write("delete影响行数:" + deleteResult + "<br/><hr/>");

        }

        void ShowProduct(PRODUCT pro)
        {
            if (pro == null) return;
            Response.Write(string.Format("{0}&nbsp;,&nbsp;{1}&nbsp;,&nbsp;{2}&nbsp;,&nbsp;{3}&nbsp;,&nbsp;{4}<br/>",
                pro.ID, pro.NAME, pro.UNIT, pro.PHONE, pro.STARTTIME));
        }
    }
    public class Response 
    {
        public static void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}
