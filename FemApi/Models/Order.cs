using System.ComponentModel.DataAnnotations;

namespace FemApi.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        public DateTime OrderdAt { get; set; } = DateTime.Now;

        [Range(0.1, double.MaxValue)]
        public double TotalPrice { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

    }
}
