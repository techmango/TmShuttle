using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TmShuttle
{
    public partial class FrmEditClasses : Form
    {
        FrmClassGrade frmClassGrade = null;
        public FrmEditClasses()
        {
            InitializeComponent();
        }

        private void btn_Confrm_Click(object sender, EventArgs e)
        {
            DataRow newRow = (frmClassGrade.DataGrid.CurrentRow.DataBoundItem as DataRowView).Row;
            newRow["class_name"] = txt_ClassName.Text.Trim();
            newRow["grade"] = cbox_Grade.SelectedItem;
            newRow["relay_id"] = nud_Relay.Value;
            newRow["box_id"] = cbox_Box.SelectedItem;
            //提交改动
            frmClassGrade.EditRingBellData();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEditClasses_Load(object sender, EventArgs e)
        {
            //form加载后从datarow获取数据填充到各个控件中
            frmClassGrade = this.Owner as FrmClassGrade;

            if (frmClassGrade.DataGrid.CurrentRow != null)
            {
                DataRowView drv = frmClassGrade.DataGrid.CurrentRow.DataBoundItem as DataRowView;
                txt_ClassName.Text = drv.Row["class_name"].ToString();
                nud_Relay.Value = int.Parse(drv.Row["relay_id"].ToString());
                cbox_Grade.SelectedText = drv.Row["grade"].ToString();
                cbox_Box.SelectedText = drv.Row["box_id"].ToString();
            }
        }
    }
}
