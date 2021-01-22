using System.Collections.Generic;
using TTiempo.Models.ViewModels;

namespace TTiempo.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        List<ListCustomerViewModel> GetAllCustomers();
        void AddCustomer(CustomerViewModel customerVM);
        CustomerViewModel GetEditCustomer(int id);
        void EditCustomer(CustomerViewModel customerVM);
        void DeleteCustomer(int id);
    }
}
