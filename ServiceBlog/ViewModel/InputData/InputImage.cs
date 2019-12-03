using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.ViewModel.InputData
{
    public class InputImage : InputBase
    {
        public string FileName { get; set; }
        public int PageSize { get; set; } = 15;
        public int Size { get; set; } = 0;
    }
}
