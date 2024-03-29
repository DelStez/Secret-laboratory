﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; // отвечает за работу с БД (соединение, запросы)
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;// содержит алгоритмы шифрования и хэширования
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordChecker
{
    public partial class PasswordAuthentication : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=data.mdb;";
        private OleDbConnection dBConnect;
        public PasswordAuthentication()
        {
            InitializeComponent();
            dBConnect = new OleDbConnection(connectString);
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }
        public static bool ByteArraysEqual(byte[] first, byte[] second)
        {
            if (first.ToArray().Equals(second.ToArray()))
                return true;
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void PasswordAuthentication_Load(object sender, EventArgs e)
        {
            dBConnect.Open();
        }

        private void PasswordAuthentication_FormClosing(object sender, FormClosingEventArgs e)
        {
            dBConnect.Close();
        }
    }
}
