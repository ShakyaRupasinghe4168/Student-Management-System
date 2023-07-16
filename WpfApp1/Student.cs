using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Student
    {

        [Key]
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string Name { get; set; }
        public string Batch { get; set; }
        public string Department { get; set; }
        public string Subject1 { get; set; }
        public string Subject2 { get; set; }
        public string Subject3 { get; set; }

        public string GPA { get; set; }




    }
}

