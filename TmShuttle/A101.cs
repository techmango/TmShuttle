using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace TmShuttle
{
    static class A101
    {
        /**************************************************************************
        ** 函数名称:Net_Write_A101_RelayBit
        ** 功能描述: 网络继电器写位
        ** 输　入: addr：485地址  relaybit：继电器位0~15   state：0关闭继电器 1打开继电器
        ** 输　出: true:成功   false：失败
        ** 全局变量: 无
        *****************************************************************************/
        static public bool Net_Write_A101_RelayBit(byte addr, byte relaybit, byte state)
        {
            byte[] buf = new byte[100];
            byte[] crcbuf = new byte[2];
            byte[] recbuf = new byte[100];




            buf[0] = addr;	//地址
            buf[1] = 0x05;	//功能码

            buf[2] = 0x00;	//起始位 0~15
            buf[3] = relaybit;	//起始位 0~15
            if (state == 0)
            {
                buf[4] = 0x00;		// 控制命令高位	ff00 打开继电器
                buf[5] = 0x00;		// 控制命令低位	 0000 关闭继电器
            }
            else
            {
                buf[4] = 0xff;		// 控制命令高位	ff00 打开继电器
                buf[5] = 0x00;		// 控制命令低位	 0000 关闭继电器
            }
            GetCRC(buf, 6, crcbuf);
            buf[6] = crcbuf[0];
            buf[7] = crcbuf[1];
            //Net.NetSend(buf, 8);

            //Net.NetRecv(recbuf, 8, 3000);
            if (ValidCRC(recbuf, 8) && recbuf[0] == addr && recbuf[1] == 0x05 && recbuf[3] == relaybit)
            {
                return true;
            }
            else return false;



        }
        /**************************************************************************
        ** 函数名称:Net_Write_A101_RelayAll
        ** 功能描述: 网络继电器写所有继电器端口
        ** 输　入: addr：485地址   state：0关闭所有继电器 1打开所有继电器
        ** 输　出: true:成功   false：失败
        ** 全局变量: 无
        *****************************************************************************/
        static public bool Net_Write_A101_RelayAll(byte addr, byte state)
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

            GetCRC(buf, 9, crcbuf);
            buf[9] = crcbuf[0];
            buf[10] = crcbuf[1];
            //Net.NetSend(buf, 11);

            //Net.NetRecv(recbuf, 8, 3000);
            if (ValidCRC(recbuf, 8) && recbuf[0] == addr && recbuf[1] == 0x0f)
            {
                return true;
            }
            else return false;
        }
        /**************************************************************************
        ** 函数名称:Net_Read_A101_RelayAll
        ** 功能描述: 读取所有继电器状态
        ** 输　入: addr：485地址   
        ** 输　出: 16位继电器状态(0到0xffff),返回0xffffffff表示读取失败
        ** 全局变量: 无
        *****************************************************************************/
        static public UInt32 Net_Read_A101_RelayAll(byte addr)
        {
            byte[] buf = new byte[100];
            byte[] crcbuf = new byte[2];
            byte[] recbuf = new byte[100];

            UInt32 state = 0;
            buf[0] = addr;	//地址
            buf[1] = 0x01;	//功能码

            buf[2] = 0x00;	//起始位高字节
            buf[3] = 0x00;	//起始位低字节

            buf[4] = 0x00;
            buf[5] = 0x10;	 //输出数量为16


            GetCRC(buf, 6, crcbuf);
            buf[6] = crcbuf[0];
            buf[7] = crcbuf[1];
            //Net.NetSend(buf, 8);

            //Net.NetRecv(recbuf, 7, 3000);//设置读超时为3秒
            if (ValidCRC(recbuf, 7) && recbuf[0] == addr && recbuf[1] == 0x01)
            {

                state = recbuf[4];
                state <<= 8;
                state |= recbuf[3];
                return state;
            }
            else
            {
                return 0xffffffff;
            }
        }
        /*****************************************************
        *函数名称:GetCRC
        *输    入:send_tab		需要CRC校验数组
                  strlen		需要CRC校验数组长度
		          CRC_tab		生成的CRC校验数组
        *输    出:无
        *功    能:CRC校验
        *示    例:
        UINT8 buf[3]={0x01,0x02,0x03}
        UINT8 crcbuf[2] = {0};
        GetCRC(buf,3,crcbuf);
        ******************************************************/
        static public void GetCRC(byte[] send_tab, byte strlen, byte[] CRC_tab)  //strlen为校验数组的长度，CRC_tab生成长度为的CRC数组低位在前
        {
            UInt16 CRCfull = 0xffff;
            byte CRChigh = 0xff;
            byte CRClow = 0xff;
            byte CRCLSB;
            byte i, j;
            for (i = 0; i < strlen; i++)
            {
                CRCfull = (UInt16)(CRCfull ^ send_tab[i]);
                for (j = 0; j < 8; j++)
                {
                    CRCLSB = (byte)(CRCfull & 0x0001);
                    CRCfull = (UInt16)((CRCfull >> 1) & 0x7fff);
                    if (CRCLSB == 1)
                    {
                        CRCfull = (UInt16)(CRCfull ^ 0xa001);
                    }
                }

            }
            CRClow = (byte)((CRCfull) & 0xff);
            CRChigh = (byte)((CRCfull >> 8) & 0xFF);
            CRC_tab[0] = CRClow;
            CRC_tab[1] = CRChigh;
        }


        /*****************************************************
        *函数名称:ValidCRC
        *输    入:send_tab		需要CRC校验数组
                  strlen		需要CRC校验数组长度

        *输    出:校验正确：true  校验错误： false
        *功    能:验证接收数组的CRC校验是否正确
        *示    例:
        UINT8 buf[3]={0x01,0x02,0x03}
        BOOL state = ValidCRC(buf,3);
        ******************************************************/
        static public bool ValidCRC(byte[] send_tab, byte strlen)  //strlen为校验数组的长度，CRC_tab生成长度为的CRC数组低位在前
        {
            UInt16 CRCfull = 0xffff;

            byte CRChigh = 0xff;
            byte CRClow = 0xff;
            byte CRCLSB;
            byte i, j;
            if (strlen >= 2)
            {
                for (i = 0; i < strlen - 2; i++)
                {
                    CRCfull = (UInt16)(CRCfull ^ send_tab[i]);
                    for (j = 0; j < 8; j++)
                    {
                        CRCLSB = (byte)(CRCfull & 0x0001);
                        CRCfull = (UInt16)((CRCfull >> 1) & 0x7fff);
                        if (CRCLSB == 1)
                        {
                            CRCfull = (UInt16)(CRCfull ^ 0xa001);
                        }
                    }

                }
                CRClow = (byte)((CRCfull) & 0xff);
                CRChigh = (byte)((CRCfull >> 8) & 0xFF);

                if ((send_tab[strlen - 2] == CRClow) && (send_tab[strlen - 1] == CRChigh))
                    return true;
                else return false;
            }
            else return false;
        }
    }

    class SendData
    {
        public static void Send(SerialPort port)
        {
            try
            {
               
                string sendData = "";
                bool exitFlag = false;
                while (exitFlag == false)
                {
                    Console.WriteLine("要发送的数据:");
                    sendData = Console.ReadLine();
                    if (sendData.CompareTo("exit") == 0)
                        break;
                    else
                        port.WriteLine(sendData);
                }
                port.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
