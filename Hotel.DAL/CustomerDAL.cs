using System;
using Hotel.IDAL;
using Hotel.Model;

namespace Hotel.DAL {
    public class CustomerDAL : BaseDAL<Customer>, ICustomerDAL {
        /// <summary>
        /// 根据实体ID删除数据
        /// </summary>
        /// <param name="id"></param>
        public override void DeleteEntity(int id) {
            throw new NotImplementedException();
        }
    }
}
