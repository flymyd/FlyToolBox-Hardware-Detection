using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Management;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace 飞翔工具箱硬件检测
{
    internal enum WmiType
    {
        Win32_Processor,
        Win32_PhysicalMemory,
        Win32_OperatingSystem,
        Win32_DiskDrive,
        Win32_BaseBoard,
        Win32_VideoController
    }
    public class hardwareCheck
    {
        static Dictionary<string, ManagementObjectCollection> WmiDict = new Dictionary<string, ManagementObjectCollection>();

        static hardwareCheck()
        {
            var names = Enum.GetNames(typeof(WmiType));
            foreach (string name in names)
            {
                WmiDict.Add(name, new ManagementObjectSearcher("SELECT * FROM " + name).Get());
            }
        }

        //获取操作系统信息
        public static string OSInfo()
        {
            StringBuilder sr = new StringBuilder();
            var query = WmiDict[WmiType.Win32_OperatingSystem.ToString()];
            foreach (var obj in query)
            {
                sr.Append(obj["Caption"] + " ");
                sr.Append(obj["OSArchitecture"]);
            }
            return sr.ToString();
        }

        //获取CPU信息
        public static string CpuInfo()
        {
            StringBuilder sr = new StringBuilder();
            var query = WmiDict[WmiType.Win32_Processor.ToString()];
            foreach (var obj in query)
            {
                sr.Append(obj["Manufacturer"] + "  ");
                sr.Append(obj["Name"]);
            }
            return sr.ToString();
        }

        //获取主板信息
        public static string MotherBoardInfo()
        {
            StringBuilder sr = new StringBuilder();
            var query = WmiDict[WmiType.Win32_BaseBoard.ToString()];
            foreach (var obj in query)
            {
                sr.Append(obj["ManuFacturer"] + " ");
                sr.Append(obj["Product"] + " ");
                sr.Append(obj["Version"]);
            }
            return sr.ToString();
        }

        //获取内存信息
        public static string MemoryInfo()
        {
            StringBuilder sr = new StringBuilder();
            long capacity = 0;
            var query = WmiDict[WmiType.Win32_PhysicalMemory.ToString()];
            int index = 1;
            foreach (var obj in query)
            {
                capacity += Convert.ToInt64(obj["Capacity"]);
            }
            sr.Append("总物理内存：");
            sr.Append(capacity / 1024 / 1024 / 1024 + "GB  ");
            sr.Append("频率：");
            foreach (var obj in query)
            {
                sr.Append(obj["Speed"] + "Mhz  ");
                index++;
            }
            return sr.ToString();
        }

        //获取显卡信息
        public static string GetGraphics()
        {
            StringBuilder sr = new StringBuilder();
            long capacity = 0;
            var query = WmiDict[WmiType.Win32_VideoController.ToString()];
            int index = 1;
            foreach (var obj in query)
            {
                capacity = Convert.ToInt64(obj["AdapterRAM"]);
                sr.Append("显卡" + index + "：");
                sr.Append(obj["Caption"] + " ");
                sr.Append("显存" + index + "：");
                sr.Append(capacity / 1024 / 1024 + "MB ");
                index++;
            }

            return sr.ToString();
        }

        //获取硬盘信息
        public static string GetDisk()
        {
            StringBuilder sr = new StringBuilder();
            long capacity = 0;
            var query = WmiDict[WmiType.Win32_DiskDrive.ToString()];
            int index = 1;
            foreach (var obj in query)
            {
                capacity = Convert.ToInt64(obj["Size"]);
                sr.Append("磁盘" + index + "：");
                sr.Append(obj["Model"] + " ");
                sr.Append("容量" + "：");
                sr.Append(capacity / 1000 / 1000 / 1000 + "GB ");
                sr.Append("\n");
                index++;
            }
            return sr.ToString();
        }

    }
}