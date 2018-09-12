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
    public class Faculty
    {
       
            private string server = "localhost";
            private string database = "database5";
            private string uid = "root";
            private string password = "Umamahesh@1";
            private string connectionString;

            public int AddFaculty(Models.Faculty objfacultymodel)
            {
                connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                string query = "insert into faculty values('" + objfacultymodel.Fid + "','" + objfacultymodel.Fname + "','" + objfacultymodel.Subject + "' )";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            public int DeleteFaculty(int id)
            {
                connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                string query = "delete from faculty where Fid='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            public Models.Faculty Search(int id)
            {
                connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                string query = "select * from faculty where Fid='" + id + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                Models.Faculty objfacultymodel = new Models.Faculty();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        objfacultymodel.Fid = Convert.ToInt32(dr[0]);
                        objfacultymodel.Fname = dr[1].ToString();
                        objfacultymodel.Subject = dr[2].ToString();
                    }
                }
                return objfacultymodel;
            }
            public int Edit(Models.Faculty objfacultymodel)
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
                string query = "UPDATE faculty SET Fname = '" + objfacultymodel.Fname + "',Subject='" + objfacultymodel.Subject + "' where Fid='" + objfacultymodel.Fid + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            public List<Models.Faculty> Display()
            {
                connectionString = @"SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                MySqlConnection con = new MySqlConnection(connectionString);
                con.Open();
                string query = "select * from faculty";
                MySqlCommand cmd = new MySqlCommand(query, con);
                List<Models.Faculty> result = new List<Models.Faculty>();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Models.Faculty objfacultymodel = new Models.Faculty();
                    objfacultymodel.Fid = Convert.ToInt32(dr["Fid"]);
                    objfacultymodel.Fname = dr["Fname"].ToString();
                    objfacultymodel.Subject = dr["Subject"].ToString();
                    result.Add(objfacultymodel);
                }
                con.Close();
                return result;
            }

        
    }
}