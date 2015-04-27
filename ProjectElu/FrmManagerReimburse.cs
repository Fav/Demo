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
    public partial class FrmManagerReimburse : FrmDock
    {
        public FrmManagerReimburse()
        {
            InitializeComponent();
        }
        DateTime dtLine = DateTime.Now;
        private void RefreshFrm()
        {
            USER user = CommonMethod.g_User;
            QueryCollection qc = new QueryCollection();
            if (user.ROLETYPE == 1)
            {
                qc.AddQueryParam("UNIT", user.UNIT);
            }
            qc.AddQueryParam("STARTTIME", dtLine);
            IList<PRODUCT> lst = BaseDA.QueryForList<PRODUCT>(CommonMethod.PrepareQuery(qc.QueryParams), "query_ByTime");
            if (lst == null)
            {
                return;
            }
            dataGridView1.DataSource = lst;
            CommonMethod.ChangeHead(dataGridView1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string strYear = toolStripTextBox1.Text;
            if (string.IsNullOrEmpty(strYear))
            {
                CommonMethod.OutLog("请输入年限");
                return;
            }
            int year = 0;
            try
            {
                year = Int32.Parse(strYear);
            }
            catch (Exception)
            {
                CommonMethod.OutLog("输入有误，请重新输入");
                toolStripTextBox1.Text = "";
                return;
            }
            dtLine = DateTime.Now.AddYears(-year);
            RefreshFrm();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确认删除该设备信息?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.No)
                    return;
                int index = dataGridView1.CurrentRow.Index;
                IList<PRODUCT> lstProduct = dataGridView1.DataSource as IList<PRODUCT>;
                if (lstProduct == null || index < 0)
                    return;
                if (lstProduct.Count < index)
                    return;
                PRODUCT pro = lstProduct[index];
                BaseDA.Delete<PRODUCT>(pro);
                RefreshFrm();

            }
            catch (Exception ex)
            { }
        }
    }
}
