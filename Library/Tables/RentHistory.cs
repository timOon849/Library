using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Tables
{
    public class RentHistory
    {
        [Key]
        public int ID_History { get; set; }
        
        [DataType(DataType.Date)]
        public required DateTime Date_Start { get; set; }
        public DateTime? Date_End { get; set; }
        public int Srok {  get; set; }
        [ForeignKey ("Book")] 
        public int ID_Book { get; set; }
        public Book Book { get; set; }

        [ForeignKey("Readers")]
        public int ID_Reader { get; set; }
        public Readers Readers { get; set; }
    }
}
