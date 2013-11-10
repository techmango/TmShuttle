using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;
using TmShuttle.DAL;
using TmShuttle.Model;
using ToastNotification;

namespace TmShuttle
{
    public partial class FrmAutoMode : Form
    {

        MP3 mp3Player;
        RingBellDAL dal = null;
        DateTime currentTime;
        //正在播放曲目ID
        int runningID = 0;

        public DataGridView DataGrid
        {
            get { return this.gv_RingBell; }
        }

        DataRowState dataRowState = DataRowState.Added;

        public DataRowState DataRowState
        {
            get { return dataRowState; }
        }

        public FrmAutoMode()
        {
            InitializeComponent();
            mp3Player = new MP3();
            dal = new RingBellDAL();
            currentTime = DateTime.Now;
            gv_RingBell.AutoGenerateColumns = false;
            gv_RingBell.DataSource = dal.GetList("").Tables[0];
            timer_BgMusic.Start();
        }

        private void openSerial()
        {
            try
            {
                foreach (GlobaConfig config in GlobaConfigInstance.Instance)
                {
                    if ((!config.SerialPort.IsOpen))
                    {
                        config.SerialPort.Open();
                        config.SerialPort.DiscardInBuffer();
                        config.SerialPort.DiscardOutBuffer();
                    }
                }
            }
            catch (Exception ex)
            {
                NotificationManager.Show(this, "打开失败！" + ex.Message,
                                Color.Gold, 1000);
                //MessageBox.Show("打开失败！" + ex.Message);
                return;
            }
        }

        private void gv_RingBell_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gv_RingBell.ColumnCount - 2)
            {
                dataRowState = System.Data.DataRowState.Modified;
                FrmEditRingBell frmEditRingBell;
                frmEditRingBell = new FrmEditRingBell();
                frmEditRingBell.Owner = this;
                frmEditRingBell.ShowDialog();
            }
            else if (e.ColumnIndex == gv_RingBell.ColumnCount - 1)
            {
                if (gv_RingBell.CurrentRow != null) 
                {
                    DataRowView drv = gv_RingBell.CurrentRow.DataBoundItem as DataRowView;
                    if (MessageBox.Show("确认要 删除 名称为“" + drv.Row["Alias"] + "”记录么？", "确认删除", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        dal.Delete(int.Parse(drv.Row["ID"].ToString()));
                        drv.Row.Delete();
                    }
                }
            }
        }

        public void EditRingBellData()
        {
            DataTable table = gv_RingBell.DataSource as DataTable;
            foreach (DataRow dr in table.Rows)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    RingBell ring = new RingBell();
                    ring.Alias = dr["Alias"] + "";
                    ring.Duaration = int.Parse(dr["Duaration"] + "");
                    ring.FileName = dr["FileName"] + "";
                    ring.FilePath = dr["FilePath"] + "";
                    ring.ID = int.Parse(dr["ID"] + "");
                    ring.RingTime = DateTime.Parse(dr["RingTime"] + "");
                    ring.RelaySwitchOn = int.Parse(dr["RelaySwitchOn"] + "");
                    ring.RelaySwitchOn2 = int.Parse(dr["RelaySwitchOn2"] + "");
                    ring.RelaySwitchOn3 = int.Parse(dr["RelaySwitchOn3"] + "");
                    ring.RelaySwitchOn4 = int.Parse(dr["RelaySwitchOn4"] + "");
                    ring.TimeKey = ring.RingTime.Hour + ":" + ring.RingTime.Minute + ":" + ring.RingTime.Second;
                    dal.Update(ring);

                }
                else if (dr.RowState == DataRowState.Added)
                {
                    RingBell ring = new RingBell();
                    ring.Alias = dr["Alias"] + "";
                    ring.Duaration = int.Parse(dr["Duaration"] + "");
                    ring.FileName = dr["FileName"] + "";
                    ring.FilePath = dr["FilePath"] + "";
                    ring.RingTime = DateTime.Parse(dr["RingTime"] + "");
                    ring.RelaySwitchOn = 14;
                    ring.TimeKey = ring.RingTime.Hour + ":" + ring.RingTime.Minute + ":" + ring.RingTime.Second;
                    dal.Add(ring);
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable table = gv_RingBell.DataSource as DataTable;
            foreach (DataRow dr in table.Rows)
            {
                if(dr.RowState == DataRowState.Modified)
                {
                    RingBell ring = new RingBell();
                    ring.Alias = dr["Alias"] + "";
                    ring.Duaration = int.Parse(dr["Duaration"] + "");
                    ring.FileName = dr["FileName"] + "";
                    ring.FilePath = dr["FilePath"] + "";
                    ring.ID = int.Parse(dr["ID"] + "");
                    ring.RingTime = DateTime.Parse(dr["RingTime"] + "");
                    ring.RelaySwitchOn = int.Parse(dr["RelaySwitchOn"] + "");
                    ring.TimeKey = ring.RingTime.Hour + ":" + ring.RingTime.Minute + ":" + ring.RingTime.Second;
                    dal.Update(ring);

                }
                else if (dr.RowState == DataRowState.Added)
                {
                    RingBell ring = new RingBell();
                    ring.Alias = dr["Alias"] + "";
                    ring.Duaration = int.Parse(dr["Duaration"] + "");
                    ring.FileName = dr["FileName"] + "";
                    ring.FilePath = dr["FilePath"] + "";
                    ring.RingTime = DateTime.Parse(dr["RingTime"] + "");
                    ring.RelaySwitchOn = 14;
                    ring.TimeKey = ring.RingTime.Hour + ":" + ring.RingTime.Minute + ":" + ring.RingTime.Second;
                    dal.Add(ring);
                }
            }
        }

        private void timer_BgMusic_Tick(object sender, EventArgs e)
        {
            int duaration = 1;
            string timeKey = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            System.Diagnostics.Debug.WriteLine(timeKey);
            DataSet ds = dal.GetList("TimeKey='" + timeKey + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                currentTime = DateTime.Now;
                mp3Player = new MP3();
                runningID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                mp3Player.FileName = ds.Tables[0].Rows[0]["FilePath"].ToString();
                mp3Player.play();
                
                duaration = int.Parse(ds.Tables[0].Rows[0]["Duaration"].ToString());
                ToggleRelay(int.Parse(ds.Tables[0].Rows[0]["RelaySwitchOn"].ToString()), 0);
                ToggleRelay(int.Parse(ds.Tables[0].Rows[0]["RelaySwitchOn2"].ToString()), 1);
                ToggleRelay(int.Parse(ds.Tables[0].Rows[0]["RelaySwitchOn3"].ToString()), 2);
                ToggleRelay(int.Parse(ds.Tables[0].Rows[0]["RelaySwitchOn4"].ToString()),3);

                foreach (DataGridViewRow dvr in gv_RingBell.Rows)
                {
                    DataRow dr = (dvr.DataBoundItem as DataRowView).Row;
                    if (runningID == int.Parse(dr["ID"].ToString()))
                    {
                        dvr.DefaultCellStyle.BackColor = Color.Gold;
                        gv_RingBell.Refresh();
                        break;
                    }
                }
            }
            if (DateTime.Now.CompareTo(currentTime.AddMinutes(duaration)) >= 0 && DateTime.Now.CompareTo(currentTime.AddMinutes(duaration).AddSeconds(5)) <= 0)
            {
                foreach (DataGridViewRow dvr in gv_RingBell.Rows)
                {
                    DataRow dr = (dvr.DataBoundItem as DataRowView).Row;
                    if (runningID == int.Parse(dr["ID"].ToString()))
                    {
                        dvr.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                runningID = 0;
                mp3Player.StopT();
            }
        }

        private void ToggleRelay(int relaySwitchOn, int index)
        {
            if (!GlobaConfigInstance.Instance[index].SerialPort.IsOpen)
                return;
            string msg = string.Empty;
            foreach (int key in RelayTagMap.Maps.Keys)
            {
                byte port = (byte)(key - 1);
                //逻辑或计算得出relaySwitchOn里打开的端口号
                if ((RelayTagMap.Maps[key] | relaySwitchOn) == relaySwitchOn)
                {
                    SendOpenDemand(port, index);
                }
                else
                {
                    SendCloseDemand(port, index);
                }
                System.Threading.Thread.Sleep(300);
            }
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
            }
        }

        private void SendOpenDemand(byte port, int boxIndex)
        {
            byte[] buffer = new byte[20];
            byte[] buffer2 = new byte[2];
            buffer[0] = GlobaConfigInstance.Instance[boxIndex].Addr;
            buffer[1] = 5;
            buffer[2] = 0;
            buffer[3] = port;
            buffer[4] = 0xff;
            buffer[5] = 0;
            A101.GetCRC(buffer, 6, buffer2);
            buffer[6] = buffer2[0];
            buffer[7] = buffer2[1];
            if (GlobaConfigInstance.Instance[boxIndex].SerialPort.IsOpen)
            {
                this.SerialSendFrame(buffer, 0, 8, boxIndex);
            }
            else
            {
                //MessageBox.Show("亲，你要先打开串口哦！");
            }
        }

        private void SendCloseDemand(byte port, int boxIndex)
        {
            byte[] buffer = new byte[20];
            byte[] buffer2 = new byte[2];
            buffer[0] = GlobaConfigInstance.Instance[boxIndex].Addr;
            buffer[1] = 5;
            buffer[2] = 0;
            buffer[3] = port;
            buffer[4] = 0;
            buffer[5] = 0;
            A101.GetCRC(buffer, 6, buffer2);
            buffer[6] = buffer2[0];
            buffer[7] = buffer2[1];
            if (GlobaConfigInstance.Instance[boxIndex].SerialPort.IsOpen)
            {
                this.SerialSendFrame(buffer, 0, 8, boxIndex);
            }
            else
            {
                //MessageBox.Show("亲，你要先打开串口哦！");
            }
        }

        private void SerialSendFrame(byte[] buf, int startaddr, int endaddr, int boxIndex)
        {
            try
            {
                GlobaConfigInstance.Instance[boxIndex].SerialPort.Write(buf, startaddr, endaddr);
            }
            catch (Exception ex)
            {
                NotificationManager.Show(this, "主机" + (boxIndex + 1) + "出现异常：" + ex.Message,
                                Color.Black, 1000);
            }
        }

        private void FrmAutoMode_Load(object sender, EventArgs e)
        {
            openSerial();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            dataRowState = System.Data.DataRowState.Added;
            FrmEditRingBell frmEditRingBell;
            frmEditRingBell = new FrmEditRingBell();
            frmEditRingBell.Owner = this;
            frmEditRingBell.Show();
        }

    }

    public class RelayTagMap
    {
        static Dictionary<int, int> maps = new Dictionary<int, int>();

        public static Dictionary<int, int> Maps
        {
            get { return RelayTagMap.maps; }
            set { RelayTagMap.maps = value; }
        }
        static RelayTagMap()
        {
            maps.Add(1, 1);
            maps.Add(2, 2);
            maps.Add(3, 4);
            maps.Add(4, 8);
            maps.Add(5, 16);
            maps.Add(6, 32);
            maps.Add(7, 64);
            maps.Add(8, 128);
            maps.Add(9, 256);
            maps.Add(10, 512);
            maps.Add(11, 1024);
            maps.Add(12, 2048);
            maps.Add(13, 4096);
            maps.Add(14, 8192);
            maps.Add(15, 16384);
            maps.Add(16, 32768);
        }
    }
}
