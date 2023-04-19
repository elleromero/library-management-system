using LibraryManagementSystem.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.dao
{
    internal class GenericDAO<T> : IGenericDAO<T>
    {
        public void Create(T model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public void GetAll(T model)
        {
            throw new NotImplementedException();
        }

        public void GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
