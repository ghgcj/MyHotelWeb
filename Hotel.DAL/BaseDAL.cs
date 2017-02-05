using System;
using System.Collections.Generic;
using System.Linq;
using Hotel.IDAL;
using System.Data.Objects;
using System.Data;

namespace Hotel.DAL {
    public abstract class BaseDAL<T> where T : class,new() {
        #region property
        //ObjectContext工厂
        private IObjectContextFactory _objConetxtFactory;
        public IObjectContextFactory ObjContextFactory {
            get { return _objConetxtFactory ?? (_objConetxtFactory = new ObjectContextFactory()); }
        }

        //ObjectContext(创建线程内唯一)
        private ObjectContext _objContext;
        public ObjectContext ObjContext {
            get { return _objContext ?? (_objContext = ObjContextFactory.GetCurrentObjectContext()); }
        }

        //ObjectSet<T>实体
        private ObjectSet<T> _obj;
        public ObjectSet<T> Obj {
            get { return _obj ?? (_obj = ObjContext.CreateObjectSet<T>()); }
        }
        #endregion

        #region methods
        public virtual void DeleteEntity(T entity) {
            Obj.Attach(entity);
            ObjContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
        }
        //按ID删，子类执行
        public abstract void DeleteEntity(int id);

        public void UpdateEntity(T entity) {
            Obj.Attach(entity);
            ObjContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }


        public void AddEntity(T entity) {
            Obj.Attach(entity);
            ObjContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Added);
        }

        public IList<T> FindEntities<K>(Func<T, bool> lanmbdaWhere, Func<T, K> lanmbdaOrder, bool isASC) {
            IQueryable<T> demo;
            if (isASC) {
                demo = Obj.Where<T>(lanmbdaWhere)
                        .OrderBy<T, K>(lanmbdaOrder)
                        .AsQueryable<T>();
            }
            else {
                demo = Obj.Where<T>(lanmbdaWhere)
                        .OrderByDescending<T, K>(lanmbdaOrder)
                        .AsQueryable<T>();
            }
            return demo.ToList();
        }

        public IList<T> FindEntities<K>(Func<T, bool> lanmbdaWhere, Func<T, K> lanmbdaOrder, bool isASC, int pageIndex, int pageSize, out int pageCount) {
            pageCount = Obj.Count<T>();
            IQueryable<T> demo;
            if (isASC) {
                demo = Obj.Where<T>(lanmbdaWhere)
                    .OrderBy<T, K>(lanmbdaOrder)
                    .Skip<T>((pageIndex - 1) * pageSize)
                    .Take<T>(pageSize)
                    .AsQueryable<T>();
            }
            else {
                demo = Obj.Where<T>(lanmbdaWhere)
                          .OrderByDescending<T, K>(lanmbdaOrder)
                          .Skip<T>((pageIndex - 1) * pageSize)
                          .Take<T>(pageSize)
                          .AsQueryable<T>();
            }
            return demo.ToList();
        }

        public T GetFirst(Func<T, bool> lanmbdaWhere)
        {
            try
            {
                return Obj.Where<T>(lanmbdaWhere).First();
            }
            catch
            {
                return null;
            }
        }
        public T GetSingle(Func<T, bool> lanmbdaWhere)
        {
            try
            {
                return Obj.Where<T>(lanmbdaWhere).Single();
            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
