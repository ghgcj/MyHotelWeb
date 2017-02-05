using Hotel.IDAL;
using System.Data.Objects;
using System.Runtime.Remoting.Messaging;
using Hotel.Model;

namespace Hotel.DAL {
    public class ObjectContextFactory : IObjectContextFactory {
        /// <summary>
        /// 实现"上下文"线程内唯一
        /// </summary>
        /// <returns>上下文</returns>
        public ObjectContext GetCurrentObjectContext() {
            var context = CallContext.GetData(typeof(ObjectContextFactory).FullName) as ObjectContext;

            if (context == null) {
                context = new CZBKHotelDBEntities();
                CallContext.SetData(typeof(ObjectContextFactory).FullName, context);
            }
            return context;
        }
    }
}
