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
            RefreshFrm();
            btnUserManager.Visible = CommonMethod.g_User.ROLETYPE == 0;
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddRecord frm = new FrmAddRecord();
            if (frm.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
                return;
            BaseDA.Insert<PRODUCT>(frm.Product);
            RefreshFrm();
        }

        private void btnWipeOut_Click(object sender, EventArgs e)
        {
            int year = (int)numericUpDown1.Value;
            DateTime dt = DateTime.Now;
            DateTime dtLine = dt.AddYears(-year);
            FrmWipeOut frm = new FrmWipeOut(dtLine);
            frm.ShowDialog();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            FrmUserManager frm = new FrmUserManager();
            frm.Show();
        }

        private void btnPWManager_Click(object sender, EventArgs e)
        {
            FrmChangePW frm = new FrmChangePW(CommonMethod.g_User.USERNAME, CommonMethod.g_User.PASSWORD);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            CommonMethod.g_User.PASSWORD = frm.NewPW;
            BaseDA.Update<USER>(CommonMethod.g_User);
            CommonMethod.OutLog("修改密码成功");
        }

    }
}
