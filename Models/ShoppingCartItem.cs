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

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
     
        public int Count { get; set; }  

        public int Quantity { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
         public string ShoppingCartId { get; set; }
 

        public ApplicationUser ApplicatonUser;
    }
}
