using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class TeacherModel:PeopleModel
    {
        public String Status;

        public TeacherModel(int Id, String FirstName,
            String SurName, String LastName): base(Id, FirstName, SurName, LastName) {
            try
            {
                OleDbConnection connection = new OleDbConnection(
                    ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT Status FROM Teachers WHERE ID=" + Id, connection);
                Status = command.ExecuteScalar().ToString();
                connection.Close();

                if (Status == null)
                    Status = "?";
            }
            catch
            {
                Status = "?";
            }
        }

        public static TeacherModel getTeacherModel(int Id)
        {
            TeacherModel model = null;

            OleDbConnection connection = new OleDbConnection(
                ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT Id_User FROM Teachers WHERE ID=" + Id, connection);
            Id = (int)command.ExecuteScalar();
            connection.Close();

            model = (TeacherModel)UserModel.getUserModel(Id).People;

            return model;
        }
    }
}