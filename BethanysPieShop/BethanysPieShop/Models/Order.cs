﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace BethanysPieShop.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        public List<OrderDetail>? OrderDetails { get; set; }
        
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage ="Please enter the last name")]
        [Display(Name ="Last Name")]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required(ErrorMessage ="Please enter the address")]
        [Display(Name ="Address Line 1")]
        [StringLength(100)]
        public string? AddressLine1 { get; set; }
        [Display(Name ="Address Line 2")]
        public string? AddressLine2 { get; set;}

        [Required(ErrorMessage ="Please enter the zipcode")]
        [Display(Name ="ZipCode")]
        [StringLength(10,MinimumLength =4)]
        public string? ZipCode { get; set; }

        [Required(ErrorMessage ="Please Enter your city")]
        [Display(Name ="City")]
        [StringLength(50)]
        public string? City { get; set; }

        [Required(ErrorMessage = "Please Enter your state")]
        [Display(Name = "State")]
        [StringLength(50)]
        public string? State { get; set; }

        [Required(ErrorMessage = "Please Enter your Country")]
        [Display(Name = "Country")]
        [StringLength(50)]
        public string? Country { get; set; }

        [Required(ErrorMessage = "Please Enter your phone number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(25)]
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType (DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string? Email { get; set; }
        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindNever]
        public DateTime OrderPlaced { get; set; }

    }
}
