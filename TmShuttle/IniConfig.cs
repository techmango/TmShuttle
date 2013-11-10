using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.ComponentModel;

namespace TmShuttle
{
    public class IniConfig
    {
        [DllImport("kernel32")]
        static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        static string sPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ConfigFile"];

        protected string SECTION = "BaseInfo";

        public IniConfig() { }

        public IniConfig(string section)
        {
            SECTION = section;

        }
        public IniConfig(string fileName, string section)
        {
            SECTION = section;
        }

        public string ReadValue(string key)
        {
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            GetPrivateProfileString(SECTION, key, "", temp, 255, sPath);
            return temp.ToString();
        }

        public void WriteValue(string key, string value)
        {
            WritePrivateProfileString(SECTION, key, value, sPath);
        }
    }

    public static class GlobaConfigInstance
    {
        private static readonly List<GlobaConfig> _Instance = new List<GlobaConfig>();

        static GlobaConfigInstance()
        {
            _Instance.Add(new GlobaConfig("SECTION1"));
            _Instance.Add(new GlobaConfig("SECTION2"));
            _Instance.Add(new GlobaConfig("SECTION3"));
            _Instance.Add(new GlobaConfig("SECTION4"));
        }

        public static List<GlobaConfig> Instance
        {
            get
            {

                return _Instance;
            }
        }
    }

    public class GlobaConfig : IniConfig
    {
        SerialPort _SerialPort;

        public SerialPort SerialPort
        {
            get
            {
                return _SerialPort;
            }
            set { _SerialPort = value; }
        }

        bool _IsValid = true;

        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }

        public GlobaConfig(string section)
        {
            base.SECTION = section;
            this._SerialPort = new SerialPort();
            this._SerialPort.ReadTimeout = 100;
            this._SerialPort.WriteTimeout = 100;
            this._SerialPort.PortName = "COM" + this.SerialNum;
            this._SerialPort.BaudRate = (int)this.Baud;

        }

        private byte _Addr = 1;
        public byte Addr
        {
            get
            {
                if (!string.IsNullOrEmpty(ReadValue("Addr")))
                {
                    _Addr = byte.Parse(ReadValue("Addr"));
                }
                return _Addr;
            }
            set
            {
                _Addr = value;
                WriteValue("Addr", value.ToString());
            }
        }


        private uint _SerialNum = 1;
        public uint SerialNum
        {
            get
            {
                if (!string.IsNullOrEmpty(ReadValue("SerialNum")))
                {
                    _SerialNum = uint.Parse(ReadValue("SerialNum"));
                }
                return _SerialNum;
            }
            set
            {
                _SerialNum = value;
                this._SerialPort.PortName = "COM" + value;
                WriteValue("SerialNum", value.ToString());
            }
        }

        private uint _Baud = 1;
        public uint Baud
        {
            get
            {
                if (!string.IsNullOrEmpty(ReadValue("Baud")))
                {
                    _Baud = uint.Parse(ReadValue("Baud"));
                }
                return _Baud;
            }
            set
            {
                _Baud = value;
                this._SerialPort.BaudRate = (int)value;
                WriteValue("Baud", value.ToString());
            }
        }
    }
}
