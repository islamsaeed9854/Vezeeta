﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Vezzeta
{
    public partial class AdminForm1 : Form
    {
        string ordb = "data source=orcl; user id=scott; password=scott;";
        OracleConnection conn;
        public string email;
        public string id;

        public AdminForm1()
        {
            InitializeComponent();

        }

        private void AdminForm1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void medicines_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select user_id_ from Users_ where email_=:email_";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email_", email);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            dr.Close();



            this.Close();
            AdminForm2_Medicines_ form2 = new AdminForm2_Medicines_();
            form2.email = email;
            form2.id_ = id;
            form2.Show();
        }

       

        private void info_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select user_id_ from Users_ where email_=:email_";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("email_", email);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = dr[0].ToString();
            }
            dr.Close();



            this.Close();
            AdminForm3_Info_ form3 = new AdminForm3_Info_();
            form3.email = email;
            form3.id_ = id;
            form3.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } 
        
        private void AdminForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void homeClic(object sender, EventArgs e)
        {
            this.Close();
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
