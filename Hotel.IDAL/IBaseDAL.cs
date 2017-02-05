using System;
using System.Collections.Generic;
using System.Data.Objects;

namespace Hotel.IDAL {
    public interface IBaseDAL<T> where T : class,new() {
        //线程内唯一ObjectContext
        IObjectContextFactory ObjContextFactory { get; }
        ObjectContext ObjContext { get; }
        ObjectSet<T> Obj { get; }


        //删除实体
        void DeleteEntity(T entity);
        void DeleteEntity(int id);

        //更新实体
        void UpdateEntity(T entity);

        //添加实体
        void AddEntity(T entity);

        //按条件查找所有实体
        IList<T> FindEntities<K>(Func<T, bool> lanmbdaWhere, Func<T, K> lanmbdaOrder, bool isASC);
        //按条件查找一页实体
        IList<T> FindEntities<K>(Func<T, bool> lanmbdaWhere, Func<T, K> lanmbdaOrder, bool isASC, int pageIndex, int pageSize, out int pageCount);

        T GetFirst(Func<T, bool> lanmbdaWhere);
        T GetSingle(Func<T, bool> lanmbdaWhere);
    }
}
