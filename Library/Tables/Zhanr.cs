using System.ComponentModel.DataAnnotations;

namespace Library.Tables
{
    public class Zhanr
    {
        [Key]
        public int ID_Zhanr { get; set; }
        
        public string? Name_Zhanr { get; set; }
    }
}
