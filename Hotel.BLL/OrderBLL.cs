using Hotel.Model;
using Hotel.IBBL;
using Hotel.IDAL;

namespace Hotel.BLL {
    public class OrderBLL : BaseBLL<Order>, IBaseBLL<Order> {
        //返回基类需要的类型
        protected override IBaseDAL<Order> GetRepository() {
            return DBSessions.OrderDAL;
        }
    }
}
