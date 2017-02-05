using Hotel.IDAL;
using System.Runtime.Remoting.Messaging;

namespace Hotel.DAL {
    public class DBSessionFactory : IDBSessionFactory {
        /// <summary>
        /// 创建DBSession(线程内唯一)
        /// </summary>
        /// <returns></returns>
        public IDBSession CreateDBSession() {
            //CallContext为线程池，只能限制本线程所有程序访问
            var dbSession = CallContext.GetData(typeof(DBSessionFactory).FullName) as IDBSession;
            if (dbSession == null) {
                dbSession = new DBSession();
                CallContext.SetData(typeof(DBSessionFactory).FullName, dbSession);
            }
            return dbSession;

        }
    }
}
