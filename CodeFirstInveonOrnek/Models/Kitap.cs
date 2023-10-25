using System.ComponentModel.DataAnnotations;

namespace CodeFirstInveonOrnek.Models
{
    public class Kitap
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string KitapAdi { get; set; }
        [Required]
        public double Fiyat { get; set; }
        [Required]
        public int SayfaSayisi { get; set; }
    }
}
