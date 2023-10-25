using System.ComponentModel.DataAnnotations;

namespace KitapMVCInveonOrnek.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string KitapAdi { get; set; }
        public double Fiyat { get; set; }
        public int SayfaSayisi { get; set; }
    }
}
