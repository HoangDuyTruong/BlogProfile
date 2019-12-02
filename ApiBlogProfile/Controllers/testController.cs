using DomainBlog.Profile.Models;
using ServiceBlog.Implement;
using ServiceBlog.ViewModel;
using ServiceBlog.ViewModel.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiBlogProfile.Controllers
{
    public class testController : ApiController
    {
        // GET: api/test
        public IEnumerable<string> Get()
        {
            ServiceBlog.Implement.ServiceBlog test = new ServiceBlog.Implement.ServiceBlog();

            int total = 0;
            BaseView<BlogDetail> data=test.Get(out total, new InputBlog()
            {
                PageSize = 0,
                Size =10,
                FillterIdBlog = 1,
                FillterIdCategory =2
            });

            return new string[] { "value1", "value2" };
        }

        // GET: api/test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/test/5
        public void Delete(int id)
        {
        }
    }
}
