using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.ViewModel.InputData
{
    public interface InputBase
    {
         int PageSize { get; set; }
         int Size { get; set; }
    }
}
