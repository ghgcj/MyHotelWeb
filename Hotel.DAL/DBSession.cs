using Hotel.IDAL;
using System.Data.Objects;

namespace Hotel.DAL {
    public class DBSession : IDBSession {
        private ICustomerDAL _customerDAL;
        public ICustomerDAL CustomerDAL {
            get { return _customerDAL ?? (_customerDAL = new CustomerDAL()); }
        }

        private IOrderDAL _orderDAL;
        public IOrderDAL OrderDAL {
            get { return _orderDAL ?? (_orderDAL = new OrderDAL()); }
        }

        private IObjectContextFactory _objContextFactory;
        public IObjectContextFactory ObjContextFactory {
            get { return _objContextFactory ?? (_objContextFactory = new ObjectContextFactory()); }
        }

        private ObjectContext _objContext;
        public ObjectContext ObjContext {
            get { return _objContext ?? (_objContext = ObjContextFactory.GetCurrentObjectContext()); }
        }

        public int SaveChanges() {
            return ObjContext.SaveChanges();
        }
    }
}
