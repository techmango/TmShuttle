using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToastNotification;

namespace TmShuttle
{
    public partial class FrmGlobalConfig : Form
    {
        public FrmGlobalConfig()
        {
            InitializeComponent();

            cboSerialNum1.SelectedIndex = (int)(GlobaConfigInstance.Instance[0].SerialNum - 1);
            cboBaudrate1.Text = GlobaConfigInstance.Instance[0].Baud.ToString();
            cboPresentAddr1.Text = GlobaConfigInstance.Instance[0].Addr.ToString();

            cboSerialNum2.SelectedIndex = (int)(GlobaConfigInstance.Instance[1].SerialNum - 1);
            cboBaudrate2.Text = GlobaConfigInstance.Instance[1].Baud.ToString();
            cboPresentAddr2.Text = GlobaConfigInstance.Instance[1].Addr.ToString();

            cboSerialNum3.SelectedIndex = (int)(GlobaConfigInstance.Instance[2].SerialNum - 1);
            cboBaudrate3.Text = GlobaConfigInstance.Instance[2].Baud.ToString();
            cboPresentAddr3.Text = GlobaConfigInstance.Instance[2].Addr.ToString();

            cboSerialNum4.SelectedIndex = (int)(GlobaConfigInstance.Instance[3].SerialNum - 1);
            cboBaudrate4.Text = GlobaConfigInstance.Instance[3].Baud.ToString();
            cboPresentAddr4.Text = GlobaConfigInstance.Instance[3].Addr.ToString();

            //if (GlobaConfigInstance.Instance[0].SerialPort.IsOpen)
            //{
            //    btnOpenSerial1.Text = "关闭串口";
            //}
            //if (GlobaConfigInstance.Instance[1].SerialPort.IsOpen)
            //{
            //    btnOpenSerial2.Text = "关闭串口";
            //}
            //if (GlobaConfigInstance.Instance[2].SerialPort.IsOpen)
            //{
            //    btnOpenSerial3.Text = "关闭串口";
            //}
            //if (GlobaConfigInstance.Instance[3].SerialPort.IsOpen)
            //{
            //    btnOpenSerial3.Text = "关闭串口";
            //}
        }

        private void OpenSerial(Button currentButton, System.IO.Ports.SerialPort serialPort)
        {
            if (currentButton.Text == "打开串口")
            {
                try
                {
                    if ((!serialPort.IsOpen))
                    {
                        serialPort.Open();
                        serialPort.DiscardInBuffer();
                        serialPort.DiscardOutBuffer();
                    }
                   
                    currentButton.Text = "关闭串口";
                }
                catch(Exception ex)
                {
                    NotificationManager.Show(this, "打开失败！" + ex.Message,
                                Color.Gold, 1000);
                    return;
                }
            }
            else if (currentButton.Text == "关闭串口")
            {
                try
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }

                    currentButton.Text = "打开串口";
                    //}
                }
                catch(Exception ex)
                {
                    NotificationManager.Show(this, "打开失败！" + ex.Message,
                                Color.Gold, 1000);
                    return;
                }
            }
        }

        private void GlobalConfig_Load(object sender, EventArgs e)
        {

        }

        private void FrmGlobalConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (GlobaConfig config in GlobaConfigInstance.Instance)
            {
                if (config.SerialPort.IsOpen)
                {
                    config.SerialPort.Close();
                }
            }
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort("COM" + (cboSerialNum1.SelectedIndex + 1), int.Parse(cboBaudrate1.Text));
            OpenSerial(sender as Button, serialPort);
        }

        private void btnOpenSerial2_Click(object sender, EventArgs e)
        {
            System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort("COM" + (cboSerialNum2.SelectedIndex + 1), int.Parse(cboBaudrate2.Text));
            OpenSerial(sender as Button, serialPort);
        }

        private void btnOpenSerial3_Click(object sender, EventArgs e)
        {
            System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort("COM" + (cboSerialNum3.SelectedIndex + 1), int.Parse(cboBaudrate3.Text));
            OpenSerial(sender as Button, serialPort);
        }

        private void btnOpenSerial4_Click(object sender, EventArgs e)
        {
            System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort("COM" + (cboSerialNum4.SelectedIndex + 1), int.Parse(cboBaudrate4.Text));
            OpenSerial(sender as Button, serialPort);
        }

        private void btn_SaveBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobaConfigInstance.Instance[0].SerialPort.IsOpen)
                {
                    GlobaConfigInstance.Instance[0].SerialPort.Close();
                    btnOpenSerial1.Text = "打开串口";
                }
                GlobaConfigInstance.Instance[0].Addr = byte.Parse(cboPresentAddr1.SelectedItem.ToString());
                GlobaConfigInstance.Instance[0].SerialNum = Convert.ToUInt32(cboSerialNum1.SelectedIndex + 1);
                GlobaConfigInstance.Instance[0].Baud = Convert.ToUInt32(cboBaudrate1.Text);
            }
            catch (Exception ex)
            {
                NotificationManager.Show(this, "打开失败！" + ex.Message,
                               Color.Gold, 1000);
            }
            
        }     

        private void btn_SaveBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobaConfigInstance.Instance[1].SerialPort.IsOpen)
                {
                    GlobaConfigInstance.Instance[1].SerialPort.Close();
                    btnOpenSerial2.Text = "打开串口";
                }
                GlobaConfigInstance.Instance[1].Addr = byte.Parse(cboPresentAddr2.SelectedItem.ToString());
                GlobaConfigInstance.Instance[1].SerialNum = Convert.ToUInt32(cboSerialNum2.SelectedIndex + 1);
                GlobaConfigInstance.Instance[1].Baud = Convert.ToUInt32(cboBaudrate2.Text);
            }
            catch (Exception ex)
            {
                NotificationManager.Show(this, "打开失败！" + ex.Message,
                               Color.Gold, 1000);
            }
        }

        private void btn_SaveBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobaConfigInstance.Instance[2].SerialPort.IsOpen)
                {
                    GlobaConfigInstance.Instance[2].SerialPort.Close();
                    btnOpenSerial3.Text = "打开串口";
                }
                GlobaConfigInstance.Instance[2].Addr = byte.Parse(cboPresentAddr3.SelectedItem.ToString());
                GlobaConfigInstance.Instance[2].SerialNum = Convert.ToUInt32(cboSerialNum3.SelectedIndex + 1);
                GlobaConfigInstance.Instance[2].Baud = Convert.ToUInt32(cboBaudrate3.Text);
            }
            catch (Exception ex)
            {
                NotificationManager.Show(this, "打开失败！" + ex.Message,
                               Color.Gold, 1000);
            }
        }

        private void btn_SaveBox4_Click(object sender, EventArgs e)
        {
            try
            {
                if (GlobaConfigInstance.Instance[0].SerialPort.IsOpen)
                {
                    GlobaConfigInstance.Instance[0].SerialPort.Close();
                    btnOpenSerial4.Text = "打开串口";
                }
                GlobaConfigInstance.Instance[3].Addr = byte.Parse(cboPresentAddr4.SelectedItem.ToString());
                GlobaConfigInstance.Instance[3].SerialNum = Convert.ToUInt32(cboSerialNum4.SelectedIndex + 1);
                GlobaConfigInstance.Instance[3].Baud = Convert.ToUInt32(cboBaudrate4.Text);
            }
            catch (Exception ex)
            {
                NotificationManager.Show(this, "打开失败！" + ex.Message,
                               Color.Gold, 1000);
            }
        }
    }
}
