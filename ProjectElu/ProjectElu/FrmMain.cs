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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            USER user = CommonMethod.g_User;
            QueryCollection qc = new QueryCollection();
            if (user.ROLETYPE == 1)
            {
                qc.AddQueryParam("UNIT", user.UNIT);
            }

            IList<PRODUCT> lst = BaseDA.QueryForList<PRODUCT>(CommonMethod.PrepareQuery( qc.QueryParams));
            if (lst == null)
            {
                return;
            }
            dataGridView1.DataSource = lst;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnWipeOut_Click(object sender, EventArgs e)
        {

        }
    }
}
