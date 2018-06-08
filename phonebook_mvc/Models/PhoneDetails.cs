using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace phonebook_mvc.Models
{
    public class PhoneDetails
    {
        //public PhoneDetails()
        //{
        //    PhoneDetailsList = new SelectList(new List<string>()); // empty list of anything...
        //}

        public int ContactID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [Phone(ErrorMessage = "This Field is Required")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}