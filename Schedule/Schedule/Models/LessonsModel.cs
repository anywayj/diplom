using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class LessonModel
    {
        public int Id { get; set; }
        public String GroupName { get; set; }
        public String Name { get; set; }
        public int Day { get; set; }
        public int NumLesson { get; set; }
        public List<TeacherModel> Teachers { get; set; }

        public LessonModel(int Id)
        {
            this.Id = Id;

            OleDbConnection connection = new OleDbConnection(
                    ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Lessons WHERE ID=" + Id, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupName = GroupModel.getGroupName(reader.GetInt32(1));
                Name = reader.GetString(2);
                Day = reader.GetInt32(3);
                NumLesson = reader.GetInt32(4);
            }
            reader.Close();

            Teachers = new List<TeacherModel>();
            command.CommandText = "SELECT Id_Teacher FROM Teachers_For_Lessons WHERE Id_Lessons="+Id;
            reader = command.ExecuteReader();
            while (reader.Read())
                Teachers.Add(TeacherModel.getTeacherModel(reader.GetInt32(0)));
            reader.Close();
            connection.Close();

        }

        public LessonModel(int Id,TeacherModel teacher)
        {
            this.Id = Id;

            OleDbConnection connection = new OleDbConnection(
                    ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
            connection.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Lessons WHERE ID=" + Id, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GroupName = GroupModel.getGroupName(reader.GetInt32(1));
                Name = reader.GetString(2);
                Day = reader.GetInt32(3);
                NumLesson = reader.GetInt32(4);
            }
            reader.Close();

            Teachers = new List<TeacherModel>();
            Teachers.Add(teacher);

        }

        public static List<LessonModel> getListLessons(GroupModel modelGroup)
        {
            List<LessonModel> list = new List<LessonModel>();
            try
            {
                OleDbConnection connection = new OleDbConnection(
                        ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT ID FROM Lessons WHERE Id_Group=" + modelGroup.Id, connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(new LessonModel(reader.GetInt32(0)));
                reader.Close();
                connection.Close();
            }
            catch(Exception e)
            {
                Stack.AddData(e.Message + "\n" + e.StackTrace + "\n");
            }

            return list;
        }

        public static List<LessonModel> getListLessons(TeacherModel teacher)
        {
            List<LessonModel> list = new List<LessonModel>();
            try
            {
                OleDbConnection connection = new OleDbConnection(
                        ConfigurationManager.ConnectionStrings["mainDB"].ConnectionString);
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT Id_Lessons FROM Teachers_For_Lessons " +
                    "WHERE Id_Teacher="
                    + teacher.Id, connection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    list.Add(new LessonModel(reader.GetInt32(0),teacher));
                reader.Close();
                connection.Close();

                for(int i=0;i<list.Count;i++)
                    for(int j=list.Count-1;j>i;j--)
                        if(list[i].Day == list[j].Day && 
                            list[i].NumLesson == list[j].NumLesson)
                        {
                            list[i].GroupName += ", " + list[j].GroupName;
                            list.RemoveAt(j);
                        }
            }
            catch (Exception e)
            {
                Stack.AddData(e.Message + "\n" + e.StackTrace + "\n");
            }

            return list;
        }
    }
}