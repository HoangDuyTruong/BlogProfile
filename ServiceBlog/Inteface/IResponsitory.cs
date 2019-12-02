using ServiceBlog.ViewModel;
using ServiceBlog.ViewModel.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.Inteface
{
    public interface IResponsitory<T> where T: class
    {
        T GetId(int Id);
        BaseView<T> Get(out int total,InputBase input);
        T Create(T obj);
        bool Edit(T obj);
        bool Delete(int id);
    }
}
