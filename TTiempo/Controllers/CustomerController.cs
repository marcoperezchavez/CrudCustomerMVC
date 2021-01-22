using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TTiempo.Models.ViewModels;
using TTiempo.Repositories.Interfaces;

namespace TTiempo.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <summary>
        ///  GET: All Customer
        /// </summary>
        /// <returns>Return a <see cref="List{ListCustomerViewModel}"/> to the view</returns>
        public ActionResult Index()
        {
            return View(_customerRepository.GetAllCustomers());
        }
        /// <summary>
        /// Load the page Nuevo
        /// </summary>
        /// <returns></returns>
        public ActionResult Nuevo()
        {
            return View();
        }
        /// <summary>
        /// Add new Customer in the database
        /// </summary>
        /// <param name="customerVM"> is saved in the database</param>
        /// <returns>Redirect to Customer Page</returns>
        [HttpPost]
        public ActionResult Nuevo(CustomerViewModel customerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerRepository.AddCustomer(customerVM);
                    return Redirect("/Customer");
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }
        /// <summary>
        /// Load the page edit with Customer information
        /// </summary>
        /// <param name="id"> necessary to get an specific Customer</param>
        /// <returns>to Edit page with the Customer selected</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                return View(_customerRepository.GetEditCustomer(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Edit un Customer with edited information
        /// </summary>
        /// <param name="customerVM">Object to will be updated</param>
        /// <returns>Redirect to Customer Page</returns>
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerRepository.EditCustomer(customerVM);
                    return Redirect("/Customer");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }
        /// <summary>
        /// Delete specific Customer in the database
        /// </summary>
        /// <param name="id">necessary to delete specific Customer</param>
        /// <returns>Json with information to manipulate in the view</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
                return Json(new { success = true, responseText = "Deleted" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}