using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Tables
{
    public class Book
    {
        [Key]
        public int ID_Book {  get; set; }

        public required string Name { get; set; }
        public string? Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime YearOfIzd { get; set; }
        public string? Description { get; set; }

        [ForeignKey ("Zhanr")]
        public int ID_Zhanr { get; set; }
        public Zhanr Zhanr { get; set; }
    }
}
