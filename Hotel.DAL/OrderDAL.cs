using System;
using Hotel.IDAL;
using Hotel.Model;

namespace Hotel.DAL {
    public class OrderDAL : BaseDAL<Order>, IOrderDAL {
        public override void DeleteEntity(int id) {
            throw new NotImplementedException();
        }
    }
}
