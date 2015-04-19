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
    public partial class FrmWipeOut : Form
    {
        DateTime dtLine;
        public FrmWipeOut(DateTime dt)
        {
            InitializeComponent();
            this.Text = CommonMethod.g_User.UNIT + "报销设备列表";
            dtLine = dt;
        }

        private void FrmWipeOut_Load(object sender, EventArgs e)
        {
            RefreshFrm();
        }
        private void RefreshFrm()
        {
            USER user = CommonMethod.g_User;
            QueryCollection qc = new QueryCollection();
            if (user.ROLETYPE == 1)
            {
                qc.AddQueryParam("UNIT", user.UNIT);
            }
            qc.AddQueryParam("startTime", dtLine);
            IList<PRODUCT> lst = BaseDA.QueryForList<PRODUCT>(CommonMethod.PrepareQuery(qc.QueryParams), "query_ByTime");
            if (lst == null)
            {
                return;
            }
            dataGridView1.DataSource = lst;
            CommonMethod.ChangeHead(dataGridView1);
        }
    }
}
