using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class StudentModel:PeopleModel
    {
        public GroupModel Group { get; set; }

        public StudentModel(int Id, String FirstName, 
            String SurName, String LastName,int Id_Group) : base(Id, FirstName, SurName,LastName)
        {
            Group = new GroupModel(Id_Group);
        }
    }
}