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


namespace Decoding
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] de;
            StreamReader reader = new StreamReader("../../../../Coding.txt");
            string str = reader.ReadToEnd();
            StreamReader reader2 = new StreamReader("../../../../key.txt");
            string key = reader2.ReadToEnd();
            byte[] keys = Encoding.Default.GetBytes(key);
            SymmetricAlgorithm sa = TripleDES.Create();
            sa.Key = keys;
            sa.Mode = CipherMode.ECB;
            de = new Byte[str.Length];
            de = Encoding.Default.GetBytes(str);
            byte[] plainbytes = new Byte[de.Length];
            MemoryStream ms = new MemoryStream(de);
            CryptoStream cs = new CryptoStream(ms, sa.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(plainbytes, 0, de.Length);
            cs.Close();
            ms.Close();
            textBox1.Text = Encoding.Default.GetString(plainbytes);


        }
    }
}
