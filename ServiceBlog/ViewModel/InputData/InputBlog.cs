using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.ViewModel.InputData
{
    public class InputBlog: InputBase
    {
        public int? FillterIdCategory { get; set; }
        public string FillterTitle { get; set; }
        public int? FillterIdBlog { get; set; }
        public int PageSize { get; set; }
        public int Size { get; set; }
    }
}
