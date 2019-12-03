using DomainBlog.Profile.Models;
using ServiceBlog;
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
    public class BlogApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            int total = 0;
            var data = BlogDI.blogService.Get(out total, new InputBlog() {
                FillterIdCategory = 2,
                PageSize = 0,
                Size = 10
            });
            return Json(data);
    } }
}
