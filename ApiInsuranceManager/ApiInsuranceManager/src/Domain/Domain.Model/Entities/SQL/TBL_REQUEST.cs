using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities.SQL
{
    public class TBL_REQUEST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Request { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime FinishDate { get; set; }

        [Required]
        public int Id_Person { get; set; }
        [Required]
        public int Id_Insurance_Type { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public Int64 FinalCost { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Id_Insurance_Type")]
        public TBL_INSURANCE_TYPE InsuranceType { get; set; }

        [ForeignKey("Id_Person")]
        public TBL_PERSON Person { get; set; }
    }
}
