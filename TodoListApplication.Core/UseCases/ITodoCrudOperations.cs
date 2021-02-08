using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TodoListApplication.Core.UseCases
{
    public interface ITodoCrudOperations<TDTO>
    {
        List<TDTO> GetAll();
        TDTO GetById(int id);
        void Insert(TDTO entity);
        void Change(TDTO entity);
        void Delete(int id);
    }
}
