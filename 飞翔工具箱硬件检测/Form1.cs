using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace 飞翔工具箱硬件检测
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String OSInf,CPUInf,MBInf,MEMInf,VIDEOInf,DISKInf;
            OSInf = hardwareCheck.OSInfo();
            CPUInf = hardwareCheck.CpuInfo();
            MBInf = hardwareCheck.MotherBoardInfo();
            MEMInf = hardwareCheck.MemoryInfo();
            VIDEOInf = hardwareCheck.GetGraphics();
            DISKInf = hardwareCheck.GetDisk();
            
            label3.Text = CPUInf;
            label4.Text = MBInf;
            label6.Text = MEMInf;
            label8.Text = VIDEOInf;
            label10.Text = DISKInf;
            label14.Text = OSInf;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCpy();
        }

        private void FormCpy()
        {
            string sPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+"\\";
            string sFileName = "";
            Random rnd = new Random();
            int width = 0;
            int heigh = 0;
            width = this.Size.Width;
            heigh = this.Size.Height;
            Bitmap bmp = new Bitmap(width, heigh);
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            sFileName = sPath + DateTime.Now.ToString("yyyyMMddHHmmss_") + ass.GetName().Name + "_"  + rnd.Next(999) + ".jpg";
            this.DrawToBitmap(bmp, new Rectangle(0, 0, width, heigh));
            bmp.Save(sFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v0.1 alpha\nDeveloped by flymyd\nE-mail：qq2663797538@gmail.com", "About me", MessageBoxButtons.OK);
        }
    }
}
