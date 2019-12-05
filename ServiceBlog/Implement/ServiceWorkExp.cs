using DomainBlog.Profile.Models;
using ServiceBlog.Inteface;
using ServiceBlog.ViewModel;
using ServiceBlog.ViewModel.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.Implement
{
    public class ServiceWorkExp : IServiceWorkExp
    {
        private readonly BlogProfileEntities context = new BlogProfileEntities();
        
        public ServiceWorkExp()
        {

        }
        public WorkExp Create(WorkExp obj)
        {
            if (obj == null)
                return null;
            try
            {
                var model = context.WorkExps.Add(obj);
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
            var workExp = context.WorkExps.FirstOrDefault(x => x.WorkID == id);
            if (workExp != null)
            {
                try
                {
                    context.WorkExps.Remove(workExp);
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

        public bool Edit(WorkExp obj)
        {
            if (obj == null)
                return false;
            WorkExp workExpEdit = context.WorkExps.FirstOrDefault(x => x.WorkID == obj.WorkID);
            if (workExpEdit == null)
                return false;
            workExpEdit.YearExp = obj.YearExp;
            workExpEdit.Level = obj.Level;
            workExpEdit.Percent = obj.Percent;
            workExpEdit.Description = obj.Description;
            workExpEdit.CompanyName = obj.CompanyName;
            workExpEdit.Position = obj.Position;
            workExpEdit.InfoProfileID = obj.InfoProfileID;
            try
            {
                context.WorkExps.Attach(workExpEdit);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BaseView<WorkExp> Get(out int total, InputBase input)
        {
            throw new NotImplementedException();
        }

        public WorkExp GetId(int Id)
        {
            if (Id == default(int))
                return null;
            try
            {
                var model = context.WorkExps.FirstOrDefault(x => x.WorkID == Id);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
