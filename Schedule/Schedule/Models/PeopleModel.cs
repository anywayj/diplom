using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class PeopleModel
    {

        public int Id { get; set; }
        public String FirstName { get; set; }
        public String SurName { get; set; }
        public String LastName { get; set; }


        public PeopleModel(int Id, String FirstName, String SurName, String LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.SurName = SurName;
            this.LastName = LastName;
        }
    }
}