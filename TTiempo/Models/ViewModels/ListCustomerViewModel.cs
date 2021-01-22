using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TTiempo.Models.ViewModels
{
    public class ListCustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool? IsEnabled { get; set; }
    }
}