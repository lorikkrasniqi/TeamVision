using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VisionStore.Areas.Identity.Data;

namespace VisionStore.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }


        
        public Products Products { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public int ProductId { get; set; }

     
        public int Count { get; set; }  

        public int Quantity { get; set; }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public string ApplicationUserId { get; set; }

         public string ShoppingCartId { get; set; }
 

        public ApplicationUser ApplicatonUser;
    }
}
