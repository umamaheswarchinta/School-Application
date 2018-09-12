using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using WebApplication10.Models;


namespace WebApplication10.DAL
{
    public class Student
    {
        private string server = "localhost";
        private string database = "database5";
        private string uid = "root";
        private string password = "Umamahesh@1";
        private string connectionString;

        public int AddStudent(Models.Student objstudentmodel)
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string query = "insert into student values('"+objstudentmodel.Sid+"','"+objstudentmodel.Sname+"','"+objstudentmodel.Class+"' )";
            MySqlCommand cmd = new MySqlCommand(query,con);
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        public int DeleteStudent(int id)
        {
            connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string query = "delete from student where Sid='"+id+"'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public Models.Student Search(int id)
         {
            connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string query = "select * from student where Sid='"+id+"'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            Models.Student objstudentmodel = new Models.Student();
            if (dr.HasRows)
            {
                if(dr.Read())
                {
                    objstudentmodel.Sid = Convert.ToInt32(dr[0]);
                    objstudentmodel.Sname = dr[1].ToString();
                    objstudentmodel.Class = dr[2].ToString();
                }
            }
            return objstudentmodel;
        }
        public int Edit(Models.Student objstudentmodel)
        {
            string server = "localhost";
            string database = "database5";
            string uid = "root";
            string password = "Umamahesh@1";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string query = "UPDATE student SET Sname = '"+objstudentmodel.Sname+"',Class='"+objstudentmodel.Class+"' where Sid='"+objstudentmodel.Sid+"'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<Models.Student> Display()
        {
            connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            string query = "select * from student";
            MySqlCommand cmd = new MySqlCommand(query, con);
            List<Models.Student> result = new List<Models.Student>();
            MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                Models.Student objstudentmodel = new Models.Student();
                objstudentmodel.Sid = Convert.ToInt32(dr["Sid"]);
                objstudentmodel.Sname = dr["Sname"].ToString();
                objstudentmodel.Class = dr["Class"].ToString();
                result.Add(objstudentmodel);
            }
            con.Close();
            return result;
        }

    }
}