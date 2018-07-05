using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public String Status { get; set; }

        public PeopleModel People { get; set; }

        public UserModel(int Id,String Login,String Password,String Status)
        {
            this.Id = Id;
            this.Login = Login;
            this.Password = Password;
            this.Status = Status;
        }

        public static UserModel getUserModel(LoginModel model)
        {
            UserModel user = null;

            OleDbConnection connection = new OleDbConnection(
                ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Users WHERE Login='" + model.Login + "' " +
                "AND Password='" + model.Password + "'", connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = new UserModel(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2), reader.GetString(3));
                break;
            }
            reader.Close();
            connection.Close();

            if (user == null)
                return null;
            else
            {
                connection.Open();
                PeopleModel people = null;
                if (user.Status == "Student")
                {
                    command = new OleDbCommand("SELECT * FROM Students WHERE " +
                        "Id_User=" + user.Id, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        people = new StudentModel(reader.GetInt32(0),
                            reader.GetString(2), reader.GetString(3), reader.GetString(4),
                            reader.GetInt32(1));
                        break;
                    }
                    reader.Close();
                }
                if (user.Status == "Teacher")
                {
                    command = new OleDbCommand("SELECT * FROM Teachers WHERE " +
                       "Id_User=" + user.Id, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        people = new TeacherModel(reader.GetInt32(0),
                            reader.GetString(2), reader.GetString(3), reader.GetString(4));
                        break;
                    }
                    reader.Close();
                }
                connection.Close();

                user.People = people;

                if (people == null)
                    return null;
                else
                    return user;
            }
        }

        public static UserModel getUserModel(int User_Id)
        {
            UserModel user = null;

            OleDbConnection connection = new OleDbConnection(
                ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Users WHERE ID="+User_Id, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                user = new UserModel(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2), reader.GetString(3));
                break;
            }
            reader.Close();
            connection.Close();

            if (user == null)
                return null;
            else
            {
                connection.Open();
                PeopleModel people = null;
                if (user.Status == "Student")
                {
                    command = new OleDbCommand("SELECT * FROM Students WHERE " +
                        "Id_User=" + user.Id, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        people = new StudentModel(reader.GetInt32(0),
                            reader.GetString(2), reader.GetString(3), reader.GetString(4),
                            reader.GetInt32(1));
                        break;
                    }
                    reader.Close();
                }
                if (user.Status == "Teacher")
                {
                    command = new OleDbCommand("SELECT * FROM Teachers WHERE " +
                       "Id_User=" + user.Id, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        people = new TeacherModel(reader.GetInt32(0),
                            reader.GetString(2), reader.GetString(3), reader.GetString(4));
                        break;
                    }
                    reader.Close();
                }
                connection.Close();

                user.People = people;

                if (people == null)
                    return null;
                else
                    return user;
            }
        }
    }
}