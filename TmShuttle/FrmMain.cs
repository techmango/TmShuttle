using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ComponentFactory.Krypton.Toolkit;


namespace TmShuttle
{
    public partial class FrmMain : KryptonForm
    {
        FrmClassGrade frmClassGrade;
        FrmMannualMode mannual;
        FrmAutoMode autoMode;
        FrmGlobalConfig globalConfig;

        public FrmMain()
        {
            InitializeComponent();
            this.LayoutMdi(MdiLayout.ArrangeIcons);
            this.lbl_SystemCaption.Text = ConfigurationManager.AppSettings["SystemCaption"];

            mannual = new FrmMannualMode();
            mannual.TopLevel = false;
            mannual.Show();
            mannual.WindowState = FormWindowState.Maximized;
            mannual.Parent = kryptonPage1;

            autoMode = new FrmAutoMode();
            autoMode.TopLevel = false;
            autoMode.Show();
            autoMode.Parent = kryptonPage2;

            globalConfig = new FrmGlobalConfig();
            globalConfig.TopLevel = false;
            globalConfig.Show();
            globalConfig.Parent = kryptonPage3;
            webBrowser1.Url = new Uri(Environment.CurrentDirectory + @"\clock.swf");
            webBrowser1.Url = new Uri(@"C:\Users\Administrator\Desktop\10701707zs\makepic.swf");

            frmClassGrade = new FrmClassGrade();
            frmClassGrade.TopLevel = false;
            frmClassGrade.Show();
            frmClassGrade.LoadData();
            frmClassGrade.Parent = kryptonPage4;

            kryptonNavigator1.SelectedIndex = 0;
        }

        private void btn_AutoMode_Click(object sender, EventArgs e)
        {
            //service.Stop();
        }

        private void kryptonNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            //if (kryptonNavigator1.SelectedIndex == 0)
            //{
            //    mannual.Show();
            //    autoMode.Hide();
            //    globalConfig.Hide();
            //    frmClassGrade.Hide();
            //    frmClassGrade.LoadData();
            //}
            //else if (kryptonNavigator1.SelectedIndex == 1)
            //{
            //    mannual.Hide();
            //    autoMode.Show();
            //    globalConfig.Hide();
            //    frmClassGrade.Hide();
            //}
            //else if (kryptonNavigator1.SelectedIndex == 2)
            //{
            //    mannual.Hide();
            //    autoMode.Hide();
            //    globalConfig.Show();
            //    frmClassGrade.Hide();
            //}
            //else if (kryptonNavigator1.SelectedIndex == 3)
            //{
            //    mannual.Hide();
            //    autoMode.Hide();
            //    globalConfig.Hide();
            //    frmClassGrade.Show();
            //}
        }

       

    }


}
