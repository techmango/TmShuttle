using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TmShuttle
{
    public class MP3
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x80)]
        private string durLength = "";
        private int ilong;
        public structMCI mc = new structMCI();
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        private string Name = "";
        [MarshalAs(UnmanagedType.LPTStr)]
        private string TemStr = "";

        private string GetCurrPath(string name)
        {
            if (name.Length < 1)
            {
                return "";
            }
            name = name.Trim();
            name = name.Substring(0, name.Length - 1);
            return name;
        }

        public void play()
        {
            this.TemStr = "";
            this.TemStr = this.TemStr.PadLeft(0x7f, Convert.ToChar(" "));
            APIClass.mciSendString(@"close temp_alias", null, 0, 0);
            //int ret = APIClass.mciSendString(@"open """ + this.TemStr + @""" alias temp_alias", null, 0, 0);
            int ret = APIClass.mciSendString(this.Name, null, 0, 0);
            //int ret = APIClass.mciSendString("play media", this.TemStr, this.TemStr.Length, 0);
            ret = APIClass.mciSendString("play temp_alias repeat", null, 0, 0);
            this.mc.state = State.mPlaying;
        }

        public void Puase()
        {
            this.TemStr = "";
            this.TemStr = this.TemStr.PadLeft(0x80, Convert.ToChar(" "));
            this.ilong = APIClass.mciSendString("pause media", this.TemStr, this.TemStr.Length, 0);
            this.mc.state = State.mPuase;
        }

        public void StopT()
        {
            this.TemStr = "";
            this.TemStr = this.TemStr.PadLeft(0x80, Convert.ToChar(" "));
            this.ilong = APIClass.mciSendString("close media", this.TemStr, 0x80, 0);
            this.ilong = APIClass.mciSendString("close all", this.TemStr, 0x80, 0);
            this.mc.state = State.mStop;
        }

        public int CurrentPosition
        {
            get
            {
                this.durLength = "";
                this.durLength = this.durLength.PadLeft(0x80, Convert.ToChar(" "));
                APIClass.mciSendString("status media position", this.durLength, this.durLength.Length, 0);
                this.mc.iPos = (int)(Convert.ToDouble(this.durLength) / 1000.0);
                return this.mc.iPos;
            }
        }

        public int Duration
        {
            get
            {
                this.durLength = "";
                this.durLength = this.durLength.PadLeft(0x80, Convert.ToChar(" "));
                APIClass.mciSendString("status media length", this.durLength, this.durLength.Length, 0);
                this.durLength = this.durLength.Trim();
                if (this.durLength == "")
                {
                    return 0;
                }
                return (int)(Convert.ToDouble(this.durLength) / 1000.0);
            }
        }

        public string FileName
        {
            get
            {
                return this.mc.iName;
            }
            set
            {
                try
                {
                    this.TemStr = "";
                    this.TemStr = this.TemStr.PadLeft(0x7f, Convert.ToChar(" "));
                    this.Name = this.Name.PadLeft(260, Convert.ToChar(" "));
                    this.mc.iName = value;
                    this.ilong = APIClass.GetShortPathName(this.mc.iName, this.Name, this.Name.Length);
                    this.Name = this.GetCurrPath(this.Name);
                    this.Name = string.Concat(new object[] { "open ", Convert.ToChar(0x22), this.Name, Convert.ToChar(0x22), " alias temp_alias" });
                    this.ilong = APIClass.mciSendString("close all", this.TemStr, this.TemStr.Length, 0);
                    this.ilong = APIClass.mciSendString(this.Name, this.TemStr, this.TemStr.Length, 0);
                    this.ilong = APIClass.mciSendString("set media time format milliseconds", this.TemStr, this.TemStr.Length, 0);
                    this.mc.state = State.mStop;
                }
                catch
                {
                }
            }
        }

        public enum State
        {
            mPlaying = 1,
            mPuase = 2,
            mStop = 3
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct structMCI
        {
            public bool bMut;
            public int iDur;
            public int iPos;
            public int iVol;
            public int iBal;
            public string iName;
            public MP3.State state;
        }
    }
}
