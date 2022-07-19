using Domain.Model.Entities.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities.SQL
{
    public class TBL_PERSON
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Identification { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "smalldatetime")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "int")]
        public int Id_Eps { get; set; }

        [ForeignKey("Id_Eps")]
        public TBL_EPS Eps { get; set; }    
    }
}
