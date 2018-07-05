using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<LessonModel> Lessons { get; set; }

        public GroupModel(int Id)
        {
            this.Id = Id;


            try
            {
                OleDbConnection connection = new OleDbConnection(
                    ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT Name FROM Groups WHERE ID=" + Id, connection);
                Name = command.ExecuteScalar().ToString();
                connection.Close();
            }
            catch
            {
                Name = "?";
            }

            Lessons = LessonModel.getListLessons(this);
        }

        public static String getGroupName(int Id)
        {
            String Name;
            try
            {
                OleDbConnection connection = new OleDbConnection(
                    ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT Name FROM Groups WHERE ID=" + Id, connection);
                Name = command.ExecuteScalar().ToString();
                connection.Close();
            }
            catch
            {
                Name = "?";
            }

            return Name;
        }

    }
}