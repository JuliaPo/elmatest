using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using NHibernate;
using DomainModel.Repositories;
using NHibernate.Criterion;

namespace Domain.Managers
{
    public class HistoryManager : IHistoryManager
    {
        public void Add(History item)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(item);
                    transaction.Commit();
                }
            }
        }

        public IEnumerable<Models.History> List()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var criteria = session.CreateCriteria(typeof(History));

                //Отфильтровать данные, выбрать операцию, выбрать действие, интерфейс перепилить
                //criteria.Add(Restrictions.Ge("X", 5));
                var docs = criteria.List<History>();
                return docs;
            }
        }
    }
}
