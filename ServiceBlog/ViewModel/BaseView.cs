using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.ViewModel
{
    public class BaseView<T> where T: class
    {
        public List<T> Data { get; set; }
        public int Status { get; set; }
        public int SizePage { get; set; }
        public int Page { get; set; }
    }
}
