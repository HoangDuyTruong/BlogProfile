using DomainBlog.Profile.Models;
using ServiceBlog.ViewModel;
using ServiceBlog.ViewModel.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.Inteface
{
    public  interface  IServiceBlog : IResponsitory<BlogDetail>
    {
    }
}
