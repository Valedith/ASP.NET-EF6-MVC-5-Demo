using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_Restaurant.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string RecipeName { get; set; }
        public int Quantity { get; set; }
        public bool isAvailable { get; set; }
        
        [Display(Name = "Register Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegisterDate { get; set; }
    }
}