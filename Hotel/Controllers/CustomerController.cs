using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Hotel.BLL;
using Hotel.IBBL;
using Hotel.Model;
using Hotel.Models;

namespace Hotel.Controllers {
    // demo
    public class CustomerController : Controller {
        private IBaseBLL<Customer> _customerService;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext) {
            if (_customerService == null) {
                _customerService = new CustomerBLL();
            }

            base.Initialize(requestContext);
        }

        //分页
        public ActionResult Index(int? pageIndex) {
            int pageCount;
            const int pageSize = 10;
            pageIndex = pageIndex ?? 1;

            var customers = _customerService.FindEntities(c => true, c => c.ID, true, pageIndex.Value, pageSize, out pageCount);
            var customerModel = ToModel(customers);

            return View(/*customerModel*/customerModel);
        }

        public ActionResult Edit(CustomerModel model) {

            return View();
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                Customer c = new Customer();
                c.Name = model.Name;
                c.Remark = model.ReMark;
                _customerService.AddEntity(c);
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Details(int id)
        {
            //var ls = _customerService.FindEntities(w=>w.ID==id,q=>q.ID,true);
            //if(ls!=null)
            //{
            //    Customer c = ls[0];
            //    return View(c);
            //}
            var item = _customerService.GetSingle(w => w.ID == id);
            if (item != null)
            {
                return View(item);
            }
            else
                return RedirectToAction("Index");
        }

        #region Private methods
        private static CustomerModel ToModel(Customer customer) {
            if (customer == null) {
                return new CustomerModel();
            }

            return new CustomerModel {
                Id = customer.ID,
                Name = customer.Name,
                ReMark = customer.Remark
            };
        }

        private static IList<CustomerModel> ToModel(IEnumerable<Customer> customers) {
            return (
                    customers == null ? Enumerable.Empty<CustomerModel>() : customers.Select(ToModel)
                   ).ToList();
        }
        #endregion

    }
}
