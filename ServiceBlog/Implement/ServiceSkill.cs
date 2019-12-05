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
    public class ServiceSkill : IServiceSkill
    {
        private readonly BlogProfileEntities context = new BlogProfileEntities();

        public ServiceSkill()
        {

        }
        public Skill Create(Skill obj)
        {
            if (obj == null)
                return null;
            try
            {
                var model = context.Skills.Add(obj);
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
            var skill = context.Skills.FirstOrDefault(x => x.SkillID == id);
            if (skill != null)
            {
                try
                {
                    context.Skills.Remove(skill);
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

        public bool Edit(Skill obj)
        {
            if (obj == null)
                return false;
            Skill skillEdit = context.Skills.FirstOrDefault(x => x.SkillID == obj.SkillID);
            if (skillEdit == null)
                return false;
            skillEdit.NameSkill = obj.NameSkill;
            skillEdit.Description = obj.Description;
            skillEdit.YearExp = obj.YearExp;
            skillEdit.Percent = obj.Percent;
            skillEdit.Level = obj.Level;
            skillEdit.InfoProfileID = obj.InfoProfileID;
            try
            {
                context.Skills.Attach(skillEdit);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BaseView<Skill> Get(out int total, InputBase input)
        {
            throw new NotImplementedException();
        }

        public Skill GetId(int Id)
        {
            if (Id == default(int))
                return null;
            try
            {
                var model = context.Skills.FirstOrDefault(x => x.SkillID == Id);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
