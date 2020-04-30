﻿using DataAccess.Entities.Context.Interface;
using DataAccess.Repository.TrueMoney.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.TrueMoney
{
    public class CoreTemplateRepository <T> : ICoreTemplateRepository<T> where T : class
    {
        protected ICoreTemplateEntities Db;

        public CoreTemplateRepository(ICoreTemplateEntities dataContext)
        {
            Db = dataContext;
        }

        #region IRepository<T> Members

        public T Insert(T item)
        {
            Db.Set<T>().Add(item);
            Db.SaveChanges();
            return item;
        }

        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            var list = SearchFor(predicate).ToList();
            if (list != null)
            {
                foreach (T ctr in list)
                {
                    Db.Entry<T>(ctr).State = System.Data.Entity.EntityState.Deleted;
                }

                Db.SaveChanges();
                return true;
            }

            return false;
        }

        public T Update(T item, Expression<Func<T, bool>> predicate)
        {
            var record = SearchFor(predicate).FirstOrDefault();
            if (record != null)
            {
                Db.Entry<T>(record).CurrentValues.SetValues(item);
                Db.SaveChanges();
                return record;
            }

            return null;
        }

        public T Update2(T item)
        {
            try
            {
                Db.Set<T>().Attach(item);
                Db.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();

                return item;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return Db.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return Db.Set<T>();
        }

        public IEnumerable<T> ExecuteQuery(string commandString, params object[] param)
        {
            return (Db as System.Data.Entity.DbContext).Database.SqlQuery<T>(commandString, param);
        }

        public bool RemoveRange(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var list = SearchFor(predicate);

                Db.Set<T>().RemoveRange(list);

                Db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public DataTable ExecuteSPReturnTable(string commandString, bool IsStoredProc, params object[] param)
        {

            DataTable dt = new DataTable();

            using (SqlConnection conn =
                    new SqlConnection((Db as System.Data.Entity.DbContext).Database.Connection.ConnectionString))
            {
                conn.Open();
                // Create an EntityCommand.
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = commandString;

                    if (IsStoredProc)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    else
                    {
                        cmd.CommandType = CommandType.Text;
                    }

                    foreach (var p in param)
                    {
                        cmd.Parameters.Add(p);
                    }

                    // Execute the command.
                    using (SqlDataReader rdr =
                        cmd.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        // Read the results returned by the stored procedure.
                        dt.Load(rdr);
                    }
                }

                conn.Close();
            }


            return dt;
        }

        #endregion
    }
}
