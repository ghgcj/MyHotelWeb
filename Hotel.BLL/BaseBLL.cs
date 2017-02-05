using System;
using System.Collections.Generic;
using Hotel.IDAL;
using Hotel.DAL;

namespace Hotel.BLL {
    public abstract class BaseBLL<T> where T : class,new() {
        #region 得到子类的类型(技巧： 取得DBSession的对象)

        //子类类型
        private IBaseDAL<T> _repository;
        public IBaseDAL<T> Repository {
            get { return _repository ?? (_repository = GetRepository()); }
        }

        protected abstract IBaseDAL<T> GetRepository();
        #endregion

        #region DBSession线程内唯一
        //DBSession(唯一)
        private IDBSession _dbSessions;
        public IDBSession DBSessions {
            get { return _dbSessions ?? (_dbSessions = DBSessionFactories.CreateDBSession()); }
        }

        //DBSession工厂
        private IDBSessionFactory _dbSessionFactories;
        public IDBSessionFactory DBSessionFactories {
            get { return _dbSessionFactories ?? (_dbSessionFactories = new DBSessionFactory()); }

        }
        #endregion


        public virtual void DeleteEntity(T entity)
        {
            Repository.DeleteEntity(entity);
            DBSessions.SaveChanges();
        }

        public virtual void DeleteEntity(int id)
        {
            Repository.DeleteEntity(id);
        }

        public virtual void UpdateEntity(T entity)
        {
            Repository.UpdateEntity(entity);
            DBSessions.SaveChanges();
        }

        public virtual void AddEntity(T entity)
        {
            Repository.AddEntity(entity);
            DBSessions.SaveChanges();
        }

        public virtual IList<T> FindEntities<K>(Func<T, bool> lanmbdaWhere, Func<T, K> lanmbdaOrder, bool isASC) {
            return Repository.FindEntities<K>(lanmbdaWhere, lanmbdaOrder, isASC);
        }

        public virtual IList<T> FindEntities<K>(Func<T, bool> lanmbdaWhere, Func<T, K> lanmbdaOrder, bool isASC, int pageIndex, int pageSize, out int pageCount) {
            return Repository.FindEntities<K>(lanmbdaWhere, lanmbdaOrder, isASC, pageIndex, pageSize, out pageCount);
        }

        public virtual T GetFirst(Func<T, bool> lanmbdaWhere) {
            return Repository.GetFirst(lanmbdaWhere);
        }

        public virtual T GetSingle(Func<T, bool> lanmbdaWhere)
        {
            return Repository.GetSingle(lanmbdaWhere);
        }
    }
}
