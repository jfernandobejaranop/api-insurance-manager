using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model.DTO
{
    public class Policy
    {
        public DateTime Date { get; set; }
        public DateTime FinishDate { get; set; }
        public int Id_Person { get; set; }
        public int Id_Insurance_Type { get; set; }
        [NotMapped]
        public Int64 FinalCost { get; set; }
        public bool IsActive { get; set; }
    }
}
