using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;

using System.IO.Ports;
using System.Threading;
using ToastNotification;

namespace TmShuttle
{
    public partial class FrmMannualMode : Form
    {


        private bool SerialRecFlag;
        public byte[] SerialRecBuf = new byte[0xff];
        private bool BtnSendFlag;
        KryptonCheckButton callerButton;
        DAL.ClassesDAL dal;

        public FrmMannualMode()
        {
            InitializeComponent();
            dal = new DAL.ClassesDAL();

            setText2Buttons();
           
        }

        private void setText2Buttons()
        {
            DataTable dt = new TmShuttle.DAL.ClassesDAL().GetList("").Tables[0];
            for (int i = 0; i < GlobaConfigInstance.Instance.Count;i++ )
            {
                foreach (Control checkButton in kryptonNavigator1.Pages[i].Controls[2].Controls)
                {
                    if (checkButton is KryptonCheckButton)
                    {
                        KryptonCheckButton thisButton = checkButton as KryptonCheckButton;
                        DataRow[] drs = dt.Select("relay_id='" + thisButton.TabIndex + "' and box_id='主机" + (i + 1) + "'");
                        if (drs.Length > 0)
                        {
                            thisButton.Text = string.Format("({0}) {1}", thisButton.TabIndex, drs[0]["class_name"].ToString());
                        }
                    }
                }
            }
        }


        private void MannualMode_Load(object sender, EventArgs e)
        {
            OpenRelys();
        }

        public void OpenRelys()
        {
            openSerial();
            readState();
            this.timer1.Start();
            this.backgroundWorker1.RunWorkerAsync();
        }

        public void openSerial()
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
            catch(Exception ex)
            {
                //MessageBox.Show("打开失败！" + ex.Message);
                NotificationManager.Show(this, "打开失败！" + ex.Message,
                                Color.Gold, 1000);
                return;
            }
        }

        private void SendOpenDemand(byte port)
        {
            byte[] buffer = new byte[20];
            byte[] buffer2 = new byte[2];
            buffer[0] = GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr;
            buffer[1] = 5;
            buffer[2] = 0;
            buffer[3] = port;
            buffer[4] = 0xff;
            buffer[5] = 0;
            A101.GetCRC(buffer, 6, buffer2);
            buffer[6] = buffer2[0];
            buffer[7] = buffer2[1];
            if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen)
            {
                this.SerialSendFrame(buffer, 0, 8);
            }
            else
            {
                //MessageBox.Show("亲，你要先打开串口哦！");
            }
        }


        private void SendCloseDemand(byte port)
        {
            byte[] buffer = new byte[20];
            byte[] buffer2 = new byte[2];
            buffer[0] = GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr;
            buffer[1] = 5;
            buffer[2] = 0;
            buffer[3] = port;
            buffer[4] = 0;
            buffer[5] = 0;
            A101.GetCRC(buffer, 6, buffer2);
            buffer[6] = buffer2[0];
            buffer[7] = buffer2[1];
            if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen)
            {
                this.SerialSendFrame(buffer, 0, 8);
            }
            else
            {
                //MessageBox.Show("亲，你要先打开串口哦！");
            }
        }



        private void relay_Click(object sender, EventArgs e)
        {
            click2Check(sender);
        }

        private void click2Check(object sender)
        {
            KryptonCheckButton checkButton = (KryptonCheckButton)sender;
            checkButton.Enabled = false;
            if (checkButton.Tag.ToString() == "断开")
            {
                SendOpenDemand((byte)checkButton.TabIndex);
            }
            else
            {
                SendCloseDemand((byte)checkButton.TabIndex);
            }
            autoCheckByClickState();
        }

        

        private void btnOpenAll_Click(object sender, EventArgs e)
        {
            Serial_Write_A101_RelayAll(GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr, 0);
            disableAllButtons(true);
        }
        
        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            Serial_Write_A101_RelayAll(GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr, 1);
            disableAllButtons(false);
        }

        private void disableAllButtons(bool isOpenAll)
        {
            //disable button first
            foreach (Control control in this.kryptonNavigator1.SelectedPage.Controls[2].Controls)
            {
                KryptonCheckButton button = control as KryptonCheckButton;
                button.Enabled = false;
            }
            this.kryptonNavigator1.SelectedPage.Controls[0].Enabled = !(this.kryptonNavigator1.SelectedPage.Controls[1].Enabled = isOpenAll);
        }

        /// <summary>
        /// 0关闭所有继电器 1打开所有继电器
        /// </summary>
        private void Serial_Write_A101_RelayAll(byte addr, byte state)
        {
            byte[] buf = new byte[100];
            byte[] crcbuf = new byte[2];
            byte[] recbuf = new byte[100];

            buf[0] = addr;	//地址
            buf[1] = 0x0f;	//功能码

            buf[2] = 0x00;	//起始位高字节
            buf[3] = 0x00;	//起始位低字节

            buf[4] = 0x00;
            buf[5] = 0x10;	 //输出数量为16

            buf[6] = 0x02;		//字节计数

            if (state == 0)
            {
                buf[7] = 0x00;
                buf[8] = 0x00;		//关闭所有继电器
            }
            else
            {
                buf[7] = 0xff;
                buf[8] = 0xff;		//打开所有继电器
            }

            A101.GetCRC(buf, 9, crcbuf);
            buf[9] = crcbuf[0];
            buf[10] = crcbuf[1];
            this.SerialSendFrame(buf, 0, 11);
        }

        private void SerialSendFrame(byte[] buf, int startaddr, int endaddr)
        {
            try
            {
                GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.Write(buf, startaddr, endaddr);
            }
            catch (Exception ex)
            {
                NotificationManager.Show(this, "主机" + (kryptonNavigator1.SelectedIndex + 1) + "出现异常：" + ex.Message,
                                Color.Gold, 1000);
            }
        }


        private UInt32 GetRegBit(UInt32 Reg, byte Mask)//取寄存器某位状态
        {
            return (Reg >> Mask) & 0x01;
        }

        private void readState()
        {
            byte[] buffer = new byte[20];
            byte[] buffer2 = new byte[2];
            int num = 0;
            num = 1;
            buffer[0] = (byte)num;
            buffer[1] = 0x10;
            buffer[2] = 0;
            buffer[3] = 8;
            buffer[4] = 0;
            buffer[5] = 1;
            buffer[6] = 2;
            buffer[7] = 0;
            buffer[8] = 1;
            A101.GetCRC(buffer, 9, buffer2);
            buffer[9] = buffer2[0];
            buffer[10] = buffer2[1];
            foreach (GlobaConfig config in GlobaConfigInstance.Instance)
            {
                if (config.SerialPort.IsOpen)
                {
                    this.SerialSendFrame(buffer, 0, 11);
                }
                else
                {
                    //MessageBox.Show("亲，你要先打开串口哦！");
                }
            }
            this.timer2.Start();
        }

        /// <summary>
        /// 根据统计按钮列表的checked个数，自动设置“闭合所有”或“断开所有”的checked
        /// </summary>
        void autoCheckByClickState()
        {
            int countCheck = 0, countUnCheck = 0;
            foreach (Control checkButton in this.kryptonNavigator1.SelectedPage.Controls[0].Controls)
            {
                if (checkButton is KryptonCheckButton)
                {
                    KryptonCheckButton currentButton = (KryptonCheckButton)checkButton;
                    if (currentButton.Checked == true)
                    {
                        countCheck++;
                    }
                    else
                    {
                        countUnCheck++;
                    }
                }
            }
            if (countCheck == 16)
            {
                this.kryptonNavigator1.SelectedPage.Controls[0].BackColor = Color.Red ;
            }
            else
            {
                this.kryptonNavigator1.SelectedPage.Controls[0].BackColor = Color.Gray;
            }
            if (countUnCheck == 16)
            {
                this.kryptonNavigator1.SelectedPage.Controls[0].BackColor = Color.Red;
            }
            else
            {
                this.kryptonNavigator1.SelectedPage.Controls[0].BackColor = Color.Red;
            }
        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {
            callerButton = (sender as KryptonContextMenu).Caller as KryptonCheckButton;
        }

        private void kryptonContextMenuItem1_Click(object sender, EventArgs e)
        {
           // Model.Classes class = dal.get
            string inputClassName = KryptonInputBox.Show("请输入新的名称");
            dal.UpdateByRelayId(inputClassName, callerButton.TabIndex.ToString(), kryptonNavigator1.SelectedIndex + 1);
            this.setText2Buttons();
        }

        private void FrmMannualMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeRelays();
        }

        private static void closeRelays()
        {
            foreach (GlobaConfig config in GlobaConfigInstance.Instance)
            {
                try
                {
                    config.SerialPort.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] buffer;
            while (true)
            {
                try
                {

                    if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen)
                    {
                        int bytesToRead = GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.BytesToRead;
                        buffer = new byte[0xff];
                        if (bytesToRead > 0)
                        {
                            int num2;
                            bytesToRead = 0x45;
                            GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.Read(buffer, 0, bytesToRead);
                            bool isValid = A101.ValidCRC(buffer, (byte)bytesToRead);
                            System.Diagnostics.Debug.WriteLine("isValid: " + isValid);
                            if (isValid)
                            {
                                for (num2 = 0; num2 < bytesToRead; num2++)
                                {
                                    this.SerialRecBuf[num2] = buffer[num2];
                                }

                                this.SerialRecFlag = true;
                            }
                            else
                                this.SerialRecFlag = false;

                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex);
                }
                Thread.Sleep(1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.SerialRecFlag)
            {
                this.SerialRecFlag = false;
                if (((this.SerialRecBuf[0] == GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr) && (this.SerialRecBuf[1] == 5)) && (this.SerialRecBuf[4] == 0))
                {
                    this.BtnSendFlag = false;
                    if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen)
                    {
                        Control[] controls = this.kryptonNavigator1.SelectedPage.Controls.Find("btnRelay" + kryptonNavigator1.SelectedIndex + this.SerialRecBuf[3], true);
                        if (controls.Length > 0)
                        {
                            KryptonCheckButton button = controls[0] as KryptonCheckButton;
                            button.Checked = false;
                            button.Tag = "断开";
                            button.Enabled = true;
                        }
                    }
                }
                else if (((this.SerialRecBuf[0] == GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr) && (this.SerialRecBuf[1] == 5)) && (this.SerialRecBuf[4] == 0xff))
                {
                    this.BtnSendFlag = false;

                    if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen)
                    {
                        Control[] controls = this.kryptonNavigator1.SelectedPage.Controls.Find("btnRelay" + kryptonNavigator1.SelectedIndex + this.SerialRecBuf[3], true);
                        if (controls.Length > 0)
                        {
                            KryptonCheckButton button = controls[0] as KryptonCheckButton;
                            button.Checked = true;
                            button.Tag = "闭合";
                            button.Enabled = true;
                        }
                    }
                }
                else if (((this.SerialRecBuf[0] == GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr) && (this.SerialRecBuf[1] == 1)) && (this.SerialRecBuf[2] == 4))
                {
                    uint[] numArray = new uint[4];
                    uint resource = 0;
                    numArray[0] = this.SerialRecBuf[3];
                    numArray[1] = this.SerialRecBuf[4];
                    numArray[2] = this.SerialRecBuf[5];
                    numArray[3] = this.SerialRecBuf[6];
                    resource = (((numArray[3] << 0x18) | (numArray[2] << 0x10)) | (numArray[1] << 8)) | numArray[0];

                    if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen)
                    {
                        foreach (Control control in this.kryptonNavigator1.SelectedPage.Controls[2].Controls)
                        {
                            KryptonCheckButton button = control as KryptonCheckButton;
                            if (this.GetRegBit(resource, (byte)control.TabIndex) == 0)
                            {
                                button.Checked = false;
                                button.Tag = "断开";
                            }
                            else
                            {
                                button.Checked = true;
                                button.Tag = "闭合";
                            }
                            button.Enabled = true;
                        }
                    }
                    //for (int i = 0; i < GlobaConfigInstance.Instance.Count; i++)
                    //{
                    //    if (GlobaConfigInstance.Instance[i].SerialPort.IsOpen)
                    //    {
                    //        foreach (Control control in this.kryptonNavigator1.Pages[i].Controls[2].Controls)
                    //        {
                    //            KryptonCheckButton button = control as KryptonCheckButton;
                    //            if (this.GetRegBit(resource, (byte)control.TabIndex) == 0)
                    //            {
                    //                button.Checked = false;
                    //                button.Tag = "断开";
                    //            }
                    //            else
                    //            {
                    //                button.Checked = true;
                    //                button.Tag = "闭合";
                    //            }
                    //            button.Enabled = true;
                    //        }
                    //    }
                    //}
                }

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!this.BtnSendFlag)
            {
                byte[] buffer = new byte[20];
                byte[] buffer2 = new byte[2];
                buffer[0] = GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].Addr;
                buffer[1] = 1;
                buffer[2] = 0;
                buffer[3] = 0;
                buffer[4] = 0;
                buffer[5] = 0x1c;
                A101.GetCRC(buffer, 6, buffer2);
                buffer[6] = buffer2[0];
                buffer[7] = buffer2[1];
                System.Diagnostics.Debug.WriteLine(kryptonNavigator1.SelectedIndex + ":" + GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen);
                if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.IsOpen)
                {
                    this.SerialSendFrame(buffer, 0, 8);
                    this.timer1.Start();
                }
                else
                {
                    if (GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].IsValid == true)
                    {
                        GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].IsValid = false;
                        try
                        {
                            GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].SerialPort.Open();
                            //修復退出的線程
                            //this.timer1 = new System.Windows.Forms.Timer();
                            this.timer1.Start();
                        }
                        catch (Exception ex)
                        {
                            NotificationManager.Show(this, "主机" + (kryptonNavigator1.SelectedIndex + 1) + "出现异常：" + ex.Message, 
                                Color.Gold, 1000);
                            //MessageBox.Show("主机" + (kryptonNavigator1.SelectedIndex + 1) + "出现异常：" + ex.Message);
                        }
                    }
                }
            }
        }

        private void kryptonNavigator1_SelectedPageChanged(object sender, EventArgs e)
        {
            GlobaConfigInstance.Instance[kryptonNavigator1.SelectedIndex].IsValid = true;
        }

        private void FrmMannualMode_Leave(object sender, EventArgs e)
        {
            closeRelays();
        }

        private void kryptonPanel1_Leave(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void FrmMannualMode_Deactivate(object sender, EventArgs e)
        {
            timer1.Stop();
            backgroundWorker1.CancelAsync();
        }

        private void FrmMannualMode_Load(object sender, EventArgs e)
        {
            OpenRelys();
        }

        


    }




}
