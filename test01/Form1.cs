using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using AppExtend1;

namespace test01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            //richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.Focus();
            Blowfish bf = new Blowfish();
            Byte[] aa = new Byte[8] {49,50,51,52,53,54,55,56 };
            Byte[] bb = bf.EncryptByte(aa, 8);
            richTextBox1.AppendText(bb.ToString());
            Blowfish cf = new Blowfish();
            Byte[] cc = cf.DecryptByte(bb, 24);
            richTextBox1.AppendText(aa.ToString());
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            richTextBox1.AppendText("123ABCD" + "\r\n");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string filename = "检测报告" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv";
            FileStream fs = new FileStream(filename, FileMode.Create);
            
            StreamWriter sw = new StreamWriter(fs,Encoding.UTF8);
            sw.WriteLine(filename);
            sw.WriteLine("检测值, 下限, 上限, 判断结果");
            Random rrr=new Random();
            for(int i=0;i<10;i++)
            {
                 sw.WriteLine(rrr.NextDouble().ToString()+"," + rrr.NextDouble().ToString()+"," + rrr.NextDouble().ToString()+"," + rrr.NextDouble().ToString());
            }
            sw.Close();
            fs.Close();
            string ss;
            ss = "共检测了10个点，其中5个异常，总体检测判断本电路板不合格";
            ss += "检测报告见：" + Environment.CurrentDirectory + "\\" + filename;
            richTextBox1.Text = ss;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*Byte[] bb=BitConverter.GetBytes(24);
            foreach (Byte b in bb)
                richTextBox1.AppendText(b.ToString("X2"));
            richTextBox1.AppendText("\r\n");
            int aa = BitConverter.ToInt32(bb, 0);
            richTextBox1.AppendText(aa.ToString());
            */
            byte[] bb = { 0xFF, 0xA2, 0x44, 1, 0, 0, 0, 1 };
            byte[] cc = { 0xFF, 0xA2 };
            Array.Reverse(cc);
            Int32 dd=BitConverter.ToInt16(cc,0);
            //richTextBox1.AppendText(dd.ToString());
            string ss = BitConverter.ToString(bb);
            richTextBox1.AppendText(ss);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strall = File.ReadAllText("aaa.txt");
            //string rgstr = GetMidStr(strall, "@00RD00", "*\r");
            string[] strSperator = { "*\r","@00" };
            string[] strarr = strall.Split(strSperator,System.StringSplitOptions.RemoveEmptyEntries);
            foreach(string s in strarr)
                richTextBox1.AppendText(s+"\r\n");
        }
        public string GetValue(string str, string s, string e)//正则表达式，取s ,e中间的字符串，好像不行
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }
        private string GetMidStr(string TxtStr, string FirstStr, string SecondStr)
        {
            if (FirstStr.IndexOf(SecondStr, 0) != -1)
                return "";
            int FirstSite = TxtStr.IndexOf(FirstStr, 0);
            int SecondSite = TxtStr.IndexOf(SecondStr, FirstSite + 1);
            if (FirstSite == -1 || SecondSite == -1)
                return "";
            return TxtStr.Substring(FirstSite + FirstStr.Length, SecondSite - FirstSite - FirstStr.Length);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            double[] num = new double[20];
            Series series = chart1.Series[0];
            for (int i = 0; i < 20; i++)
            {
                int valuey = rd.Next(20, 100);
                DataPoint point = new DataPoint((i + 1), valuey);
                series.Points.Add(point);
            }
            chart1.Titles[0].Text = "max:"+200.ToString()+"   min:100";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //AppExtend1.IniFile.WriteIniOneItem("test01.ini", "reginfo", "ABCD0924");
            string s = IniFile.GetIniOneValue("test01.ini", "reginfo");
            richTextBox1.AppendText(s);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<int> m_iniValuesList = new List<int>() { 1, 2, 3, 4, 5, 6 };

            int idex = m_iniValuesList.LastIndexOf(6);
            List<int> listTmp = m_iniValuesList.GetRange(idex + 1, m_iniValuesList.Count - idex - 1);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string s = "1000025100008";
            richTextBox1.AppendText(s.Substring(0, 7)+"\r\n");
            richTextBox1.AppendText(s.Substring(7, 6));
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            richTextBox1.AppendText(e.KeyChar.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(@".\img\");
            richTextBox1.Text = "aaaa";
        }
    }
}
