using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo_Api.Domain.Entities
{

    [Table("product")]
    public record Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]

        public int id { get; init; }
        [Column("ProductName")]
        [MaxLength(100)]
        public string? PoductName { get; init; }

        [Column("ProductCode")]
        [MaxLength(10)]
        public string? PoductCode { get; init; }


        [Column("Price",TypeName ="decimal(7,2)")]
        public Decimal Price { get; init; }
    }
}
