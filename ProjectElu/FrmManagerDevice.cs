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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                IList<PRODUCT> lstProduct = dataGridView1.DataSource as IList<PRODUCT>;
                if (lstProduct == null || index < 0)
                    return;
                if(lstProduct.Count < index)
                    return ;
                PRODUCT pro = lstProduct[index];

                FrmAddRecord frm = new FrmAddRecord();
                frm.Product = pro;
                frm.Init();
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                int bUpdate = BaseDA.Update<PRODUCT>(frm.Product);
                RefreshFrm();

            }
            catch(Exception ex)
            { }
        }

        //修改设备
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentRow.Index;
                IList<PRODUCT> lstProduct = dataGridView1.DataSource as IList<PRODUCT>;
                if (lstProduct == null || index < 0)
                    return;
                if (lstProduct.Count < index)
                    return;
                PRODUCT pro = lstProduct[index];

                FrmAddRecord frm = new FrmAddRecord();
                frm.Product = pro;
                frm.Init();
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;
                BaseDA.Update<PRODUCT>(frm.Product);
                RefreshFrm();

            }
            catch (Exception ex)
            { }
           
        }

        //删除设备
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
