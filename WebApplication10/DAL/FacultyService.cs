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
    public class FacultyService
    {

        private string connectionString;

        public List<Models.Faculty> GetFacultyList()
        {
            List<Models.Faculty> faculties = new List<Models.Faculty>();
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                faculties = conn.Query<Models.Faculty>("Select Fid,Fname,Subject,Subcode from faculty").ToList();
            }
            return faculties;
        }
        public Models.Faculty GetDetails(int id)
        {
            Models.Faculty objfacultyservicemodel = new Models.Faculty();
            Models.Faculty faculties = new Models.Faculty();
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                objfacultyservicemodel = conn.Query<Models.Faculty>("Select * from faculty where Fid='"+id+"'").SingleOrDefault();
            }
            return objfacultyservicemodel;
        }
        public int AddFaculty(Models.Faculty objfacultyservicemodel)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "Insert Into faculty(Fname,Subject,Subcode,Email,Address,Phoneno) Values('" + objfacultyservicemodel.Fname + "','" + objfacultyservicemodel.Subject + "','" + objfacultyservicemodel.Subcode + "','" + objfacultyservicemodel.Email+ "','" + objfacultyservicemodel.Address + "','" + objfacultyservicemodel.Phoneno + "')";
            
                int i = conn.Execute(sqlQuery);
                return i;
            }
        }
        public int DeleteFaculty(int id)
        {

            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "delete from faculty where Fid='" + id + "'";
                int i = conn.Execute(sqlQuery);
                return i;

            }

        }
        public Models.Faculty Search(int id)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            Models.Faculty objfacultyservicemodel = new Models.Faculty();
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "select * from faculty where Fid='" + id + "'";
                objfacultyservicemodel = conn.Query<Models.Faculty>(sqlQuery).SingleOrDefault();
            }
            return objfacultyservicemodel;
        }
        public int UpdateFaculty(Models.Faculty objfacultyservicesmodel)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                string sqlQuery = "UPDATE faculty SET Fname = '" + objfacultyservicesmodel.Fname + "',Subject='" + objfacultyservicesmodel.Subject + "',Subcode='" + objfacultyservicesmodel.Subcode + "',Email='" + objfacultyservicesmodel.Email + "',Address='" + objfacultyservicesmodel.Address + "',Phoneno='" + objfacultyservicesmodel.Phoneno + "' where Fid='" + objfacultyservicesmodel.Fid + "'";
                int i = conn.Execute(sqlQuery);
                return i;

            }

        }
        public List<Models.Faculty> Search1(string s)
        {
            
            List<Models.Faculty> faculties = new List<Models.Faculty>();
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                
                    faculties = conn.Query<Models.Faculty>("Select Fid,Fname,Subject,Subcode from faculty where Fname like '"+@s+"'").ToList();
    
            }
            return faculties;
        }
        public List<Models.Faculty> List()
        {
            List<Models.Faculty> faculties = new List<Models.Faculty>();
            string connectionstring = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (var conn = new MySqlConnection(connectionstring))
            {
                    faculties = conn.Query<Models.Faculty>("Select Fid,Fname,Subject,Subcode from faculty ").ToList();
            }
            return faculties;
        }
    }
}