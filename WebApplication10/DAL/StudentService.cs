using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using WebApplication10.Models;
using Dapper;

namespace WebApplication10.DAL
{
    public class StudentService
    {
        
        private string connectionString;

        public List<Models.Student> GetStudentList()
        {
            List<Models.Student> students = new List<Models.Student>();
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                students = conn.Query<Models.Student>("Select * from student").ToList();
            }
            return students;
        }
        public int AddStudent(Models.Student objstudentservicemodel)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "Insert Into student(Sname,Class) Values('" + objstudentservicemodel.Sname + "','" + objstudentservicemodel.Class + "')";
                int i = conn.Execute(sqlQuery);
                return i;

            }
        }
        public int DeleteStudent(int id) {

            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "delete from student where Sid='" + id + "'";
                int i = conn.Execute(sqlQuery);
                return i;

            }

        }
        public Models.Student Search(int id)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            Models.Student objstudentservicemodel = new Models.Student();
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "select * from student where Sid='"+id+"'";
                objstudentservicemodel = conn.Query<Models.Student>(sqlQuery).SingleOrDefault();
            }
            return objstudentservicemodel;
        }
        public int UpdateStudent(Models.Student objstudentservicesmodel)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "UPDATE student SET Sname = '" + objstudentservicesmodel.Sname + "',Class='" +objstudentservicesmodel.Class + "' where Sid='" + objstudentservicesmodel.Sid + "'";
                int i = conn.Execute(sqlQuery);
                return i;

            }

        }




    }
}