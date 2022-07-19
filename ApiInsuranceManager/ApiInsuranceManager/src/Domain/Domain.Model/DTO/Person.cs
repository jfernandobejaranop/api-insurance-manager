using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.DTO
{
    public class Person
    {
        public int Id_Person { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Identification { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int Id_Eps { get; set; }
    }
}
