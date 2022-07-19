using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entities.SQL
{
    public class TBL_INSURANCE_VALUES
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Insurance_Values { get; set; }
        public int Id_Insurance_Type { get; set; }

        [Required]
        [Column(TypeName = "numeric")]
        public Int64 BaseValue { get; set; }

        [ForeignKey("Id_Insurance_Type")]
        public TBL_INSURANCE_TYPE InsuranceType { get; set; }
    }
}
