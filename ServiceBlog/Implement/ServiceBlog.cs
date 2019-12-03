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
            if (obj == null)
                return null;
            try
            {
                var model = context.BlogDetails.Add(obj);
                context.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }

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
            if (obj == null)
                return false;
            BlogDetail blogEdit = context.BlogDetails.FirstOrDefault(x => x.BlogID == obj.BlogID);
            if (blogEdit == null)
                return false;
            blogEdit.AuthorName = obj.AuthorName;
            blogEdit.CategoryBlogID = obj.CategoryBlogID;
            blogEdit.Description = obj.Description;
            blogEdit.Content = obj.Content;
            blogEdit.TitleBlog = obj.TitleBlog;
            try
            {
                context.BlogDetails.Attach(blogEdit);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
            return context.BlogDetails.FirstOrDefault(x => x.BlogID == Id);
        }
    }
}
