using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.ViewModel.InputData
{
    public class InputInfoProfile : InputBase
    {
        public int PageSize { get; set; }
        public int Size { get; set; }
    }
}
