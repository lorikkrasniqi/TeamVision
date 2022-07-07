using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VisionStore.Data.Cart;
using VisionStore.Data.ViewModels;

namespace VisionStore.Models
{
    public class ProductDealsItem
    {
        [Key]
        public int Id { get; set; }


        public Products Products { get; set; }

        public int Count { get; set; }


        [Required(ErrorMessage = "You need to provide product's Price")]
        public double NewPrice { get; set; }

        public int Quantity { get; set; }

        public string ProductDealsId { get; set; }



    }
}
