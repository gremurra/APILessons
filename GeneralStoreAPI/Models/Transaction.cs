using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStoreAPI.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        //foreign keys tie data tables together
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        //in a new transaction, able to point to product table..and say "id number" is now tied to this transaction
        //one-to-many relationship ... one product ID involved in multiple transactions
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateOfTransaction { get; set; }
    }
}