using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TTiempo.Models;
using TTiempo.Models.ViewModels;
using TTiempo.Repositories.Interfaces;

namespace TTiempo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<ListCustomerViewModel> GetAllCustomers()
        {
            using (ExerciseTiempoEntitiesv2 db = new ExerciseTiempoEntitiesv2())
            {
                return (from d in db.Get_All_Customers()
                       where d.IsEnabled == true
                       select new ListCustomerViewModel
                       {
                           Id = d.Id,
                           FirstName = d.FirstName,
                           LastName = d.LastName,
                           DateOfBirth = d.DateOfBirth,
                           IsEnabled = d.IsEnabled
                       }).ToList();
            }
        }

        public void AddCustomer(CustomerViewModel customerVM)
        {
            try
            {
                    using (ExerciseTiempoEntitiesv2 db = new ExerciseTiempoEntitiesv2())
                    {
                        var customer = new Customer()
                        {
                            FirstName = customerVM.FirstName,
                            LastName = customerVM.LastName,
                            DateOfBirth = customerVM.DateOfBirth,
                            IsEnabled = true
                        };
                        db.Customer.Add(customer);
                        db.SaveChanges();
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CustomerViewModel GetEditCustomer(int id)
        {
            CustomerViewModel editCustomer = new CustomerViewModel();
            using (ExerciseTiempoEntitiesv2 db = new ExerciseTiempoEntitiesv2())
            {
                var cust = db.Customer.Find(id);
                editCustomer.Id = cust.Id;
                editCustomer.FirstName = cust.FirstName;
                editCustomer.LastName = cust.LastName;
                editCustomer.DateOfBirth = cust.DateOfBirth;
                editCustomer.IsEnabled = cust.IsEnabled;
            }
            return editCustomer;
        }

        public void EditCustomer(CustomerViewModel customerVM)
        {
            using (ExerciseTiempoEntitiesv2 db = new ExerciseTiempoEntitiesv2())
            {
                var cust = db.Customer.Find(customerVM.Id);
                cust.FirstName = customerVM.FirstName;
                cust.LastName = customerVM.LastName;
                cust.DateOfBirth = customerVM.DateOfBirth;
                cust.IsEnabled = true;
                db.Entry(cust).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            using (ExerciseTiempoEntitiesv2 db = new ExerciseTiempoEntitiesv2())
            {
                var cust = db.Customer.Find(id);
                cust.IsEnabled = false;
                db.Entry(cust).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}