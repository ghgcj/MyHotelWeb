using Hotel.Model;
using Hotel.IBBL;
using Hotel.IDAL;

namespace Hotel.BLL {
    public class CustomerBLL : BaseBLL<Customer>, IBaseBLL<Customer> {
        //返回基类需要的类型
        protected override IBaseDAL<Customer> GetRepository() {
            return DBSessions.CustomerDAL;
        }
    }
}
