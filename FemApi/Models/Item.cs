using System.ComponentModel.DataAnnotations;

namespace FemApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Range(0.1, double.MaxValue)]
        public double Price { get; set; }

        //[Required/*, MinLength(180)*/]
        public string Image {  get; set; }
    }
}
