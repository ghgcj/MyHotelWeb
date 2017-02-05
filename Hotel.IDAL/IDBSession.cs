using System.Data.Objects;

namespace Hotel.IDAL {
    public interface IDBSession {
        ICustomerDAL CustomerDAL { get; }
        IOrderDAL OrderDAL { get; }

        IObjectContextFactory ObjContextFactory { get; }
        ObjectContext ObjContext { get; }
        //实现批量操作数据库
        int SaveChanges();
    }
}
