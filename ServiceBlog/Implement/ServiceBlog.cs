using DomainBlog.Profile.Models;
using ServiceBlog.Inteface;
using ServiceBlog.ViewModel;
using ServiceBlog.ViewModel.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.Implement
{
    public class ServiceBlog : IServiceBlog
    {
        private readonly BlogProfileEntities context = new BlogProfileEntities();
        public ServiceBlog()
        {

        }
        public BlogDetail Create(BlogDetail obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var blog = context.BlogDetails.FirstOrDefault(x => x.CategoryBlogID == id);
            if(blog != null)
            {
                try
                {
                    context.BlogDetails.Remove(blog);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Edit(BlogDetail obj)
        {
            throw new NotImplementedException();
        }

        public  BaseView<BlogDetail> Get(out int total,InputBase input)
        {
            BaseView<BlogDetail> modelView = new BaseView<BlogDetail>();
            InputBlog blogFilter = input as InputBlog;
            try
            {
                total = context.BlogDetails.Count();
                IQueryable query = context.Set<BlogDetail>();
                if (blogFilter.FillterIdBlog != default(int) && blogFilter.FillterIdBlog != null)
                {
                    query = query.OfType<BlogDetail>().Where(x => x.BlogID == blogFilter.FillterIdBlog);
                }
                if (blogFilter.FillterIdCategory != default(int) && blogFilter.FillterIdCategory != null)
                {
                    query = query.OfType<BlogDetail>().Where(x => x.CategoryBlogID == blogFilter.FillterIdCategory);
                }
                if (blogFilter.FillterTitle != default(string) && blogFilter.FillterTitle != null && blogFilter.FillterTitle != "")
                    query = query.OfType<BlogDetail>().Where(x => x.TitleBlog.Contains(blogFilter.FillterTitle));
                modelView.Data = query.OfType<BlogDetail>().OrderBy(x=>x.BlogID).Skip(blogFilter.Size * blogFilter.PageSize).Take(blogFilter.Size).ToList();
                modelView.Status = 1;
                return modelView;

            }
            catch (Exception ex)
            {
                total = 0;
                modelView.Status = 0;
                return modelView;
            }
        }

        public BlogDetail GetId(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
