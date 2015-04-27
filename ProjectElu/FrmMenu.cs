using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityLibrary.WinControls;
using WeifenLuo.WinFormsUI.Docking;

namespace ProjectElu
{
    public partial class FrmMenu : FrmDock
    {
        public  delegate void ItemClickHandle(OutlookBarBand band, OutlookBarItem item);
        public event ItemClickHandle ItemClickEvent;
        public FrmMenu()
        {
            InitializeComponent();
            InitializeOutlookbar();
        }
        OutlookBar outlookBar1 = null;
        private void InitializeOutlookbar()
        {
            outlookBar1 = new OutlookBar();

            #region 销售管理
            OutlookBarBand outlookShortcutsBand = new OutlookBarBand("设备管理");
            outlookShortcutsBand.SmallImageList = this.imageList;
            outlookShortcutsBand.LargeImageList = this.imageList;
            outlookShortcutsBand.Items.Add(new OutlookBarItem("设备管理", 1));
            outlookShortcutsBand.Items.Add(new OutlookBarItem("报废管理", 0));
            outlookShortcutsBand.Background = SystemColors.AppWorkspace;
            outlookShortcutsBand.TextColor = Color.White;
            outlookBar1.Bands.Add(outlookShortcutsBand);

            #endregion

            #region 产品库存管理
            if (CommonMethod.g_User.ROLETYPE == 0)
            {
                OutlookBarBand mystorageBand = new OutlookBarBand("用户管理");
                mystorageBand.SmallImageList = this.imageList;
                mystorageBand.LargeImageList = this.imageList;
                mystorageBand.Items.Add(new OutlookBarItem("用户管理", 2));
                mystorageBand.Background =SystemColors.AppWorkspace;
                mystorageBand.TextColor = Color.White;
                outlookBar1.Bands.Add(mystorageBand);
            }

            #endregion


            outlookBar1.Dock = DockStyle.Fill;
            outlookBar1.SetCurrentBand(0);
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);
            outlookBar1.ItemDropped += new OutlookBarItemDroppedHandler(OnOutlookBarItemDropped);

            //outlookBar1.FlatArrowButtons = true;
            this.panel1.Controls.AddRange(new Control[] { outlookBar1 });
        }

        private void OnOutlookBarItemDropped(OutlookBarBand band, OutlookBarItem item)
        {
            if (ItemClickEvent != null)
            {
                ItemClickEvent(band, item);
            }
        }

        private void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            if (ItemClickEvent != null)
            {
                ItemClickEvent(band, item);
            }
        }

    }
}
