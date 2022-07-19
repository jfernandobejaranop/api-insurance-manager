using Domain.Model.Entities.SQL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model.Entities.SQL
{
    public class TBL_VEHICLE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Vehicle { get; set; }
        public int Id_Person { get; set; }
        public int Id_Line { get; set; }
        public int Model { get; set; }
        public string Carriage { get; set; }

        [ForeignKey("Id_Line")]
        public TBL_LINE Line {get; set;}

        [ForeignKey("Id_Person")]
        public TBL_PERSON Person { get; set; }
    }
}
