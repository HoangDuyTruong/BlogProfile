﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiBlogProfile.Controllers
{
    public class ImagesController : ApiController
    {
        // GET: api/Images
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Images/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Images
        public void Post([FromBody]string value)
        {
           
        }

        // PUT: api/Images/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Images/5
        public void Delete(int id)
        {
        }
    }
}