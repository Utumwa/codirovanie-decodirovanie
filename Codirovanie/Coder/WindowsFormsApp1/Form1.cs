using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            byte[] cipherbytes;
            StreamReader reader = new StreamReader("../../../../key.txt");
            string key = reader.ReadToEnd();
            reader.Close();
            byte[] keys = Encoding.Default.GetBytes(key);
            SymmetricAlgorithm sa = TripleDES.Create();
            sa.Key=keys;
            sa.Mode = CipherMode.ECB;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, sa.CreateEncryptor(), CryptoStreamMode.Write);
            byte[] plainbytes = Encoding.Default.GetBytes(textBox1.Text);
            cs.Write(plainbytes, 0, plainbytes.Length);
            cs.Close();
            cipherbytes = ms.ToArray();
            ms.Close();
            str = Encoding.Default.GetString(cipherbytes);
            StreamWriter write = new StreamWriter("../../../../Coding.txt");
            write.Write(str);
            write.Close();
        }
    }
}
