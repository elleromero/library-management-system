using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.interfaces
{
    internal interface IGenericDAO<T>
    {
        void Create(T model);

        void GetById(string id);

        void GetAll(T model);

        void Update(T model);

        void Delete(string id);

        void DeleteAll(IEnumerable<string> ids);
    }
}
