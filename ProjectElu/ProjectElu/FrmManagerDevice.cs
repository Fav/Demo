using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ProjectElu
{
    public partial class FrmManagerDevice : FrmDock
    {
        public FrmManagerDevice()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmAddRecord frm = new FrmAddRecord();
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            BaseDA.Insert<PRODUCT>(frm.Product);
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

            IList<PRODUCT> lst = BaseDA.QueryForList<PRODUCT>(CommonMethod.PrepareQuery(qc.QueryParams));
            if (lst == null)
            {
                return;
            }
            dataGridView1.DataSource = lst;
            CommonMethod.ChangeHead(dataGridView1);
        }

        private void FrmManagerDevice_Load(object sender, EventArgs e)
        {
            RefreshFrm();
        }

    }
}
