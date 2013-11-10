using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TmShuttle.DAL;
using TmShuttle.Model;

namespace TmShuttle
{
    public partial class FrmClassGrade : Form
    {
        ClassesDAL dal = null;

        public DataGridView DataGrid
        {
            get { return this.gv_Classes; }
        }

        public FrmClassGrade()
        {
            InitializeComponent();
            dal = new ClassesDAL();
            gv_Classes.AutoGenerateColumns = false;
            LoadData();
        }

        public void LoadData()
        {
            gv_Classes.DataSource = null;
            gv_Classes.DataSource = dal.GetList("").Tables[0];
        }

        public void EditRingBellData()
        {
            DataTable table = gv_Classes.DataSource as DataTable;
            foreach (DataRow dr in table.Rows)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    Classes classes = new Classes();
                    classes.class_name = dr["class_name"] + "";
                    classes.grade = dr["grade"] + "";
                    classes.relay_id = dr["relay_id"] + "";
                    dal.Update(classes);
                }
            }
        }

        private void gv_Classes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gv_Classes.ColumnCount - 2)
            {
                FrmEditClasses ｆrmEditClasses;
                ｆrmEditClasses = new FrmEditClasses();
                ｆrmEditClasses.Owner = this;
                ｆrmEditClasses.ShowDialog();
            }
        }
    }
}
