using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAMa.Models
{
    public class Userdata
    {
        public string Username { get; set; }
        public int Identity { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Userdata(string username, int identity, string firstname, string lastname)
        { this.Username = username; this.Identity = identity; this.Firstname = firstname; this.Lastname = lastname; }

        public Userdata()
        {
        }

        public string UserInfo
        {
            get
            {
                return $"{Username} {Firstname} {Lastname} ";
            }
        }
    }
    public class CourseData
    {
        public string Name { get; set; }
        public Int16 CreditPoints { get; set; }       
        public CourseData(string name, Int16 creditpoints)
            { this.Name = name; this.CreditPoints = creditpoints; }
        public CourseData()
        {
        }     
    }
    public class GradeData
    {
        public string Name { get; set; }
        public Int16 CreditPoints { get; set; }
        public Int16 Grade { get; set; }

        public DateTime Date;
        public GradeData(string name, Int16 creditpoints, Int16 grade, DateTime date)
        {
            this.Name = name; this.CreditPoints = creditpoints; this.Grade = grade; this.Date = date;

        }
        public GradeData()
        {
        }

    }
}
