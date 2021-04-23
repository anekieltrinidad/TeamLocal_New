using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TeamLocal.Models
{
    public class Business
    {
        

        [Key]
        public int BusinessID { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        [Display(Name = "Business Address")]
        public string BusinessAddress { get; set; }

        [Display(Name = "Contact Information")]
        public string ContactInfo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Overview { get; set; }

        [Display(Name = "Social Media Link")]
        public string SocialMedia { get; set; }

        public float Rating { get; set; }

        [Required(ErrorMessage = "Required")]
        public virtual CategoryBusiness Category { get; set; }

        public int? CategoryID { get; set; }
  

    }


    public class CategoryBusiness 
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }


}
