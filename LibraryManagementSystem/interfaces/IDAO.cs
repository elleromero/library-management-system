using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.interfaces
{
    internal interface IDAO<T>
    {
        ReturnResult<T> GetById(string id);
        ReturnResultArr<T> GetAll(int page);
        ReturnResult<T> Update(T model);
        ReturnResult<T> Create(T model);
        bool Remove(string id);
        T? Fill(SqlDataReader reader);
    }
}
