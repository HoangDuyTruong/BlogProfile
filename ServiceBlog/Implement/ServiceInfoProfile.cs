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
    public class ServiceInfoProfile : IServiceInfoProfile
    {
        private readonly BlogProfileEntities context = new BlogProfileEntities();
        public ServiceInfoProfile()
        {

        }
        public InfoProfile Create(InfoProfile obj)
        {
            if (obj == null)
                return null;
            try
            {
                var model = context.InfoProfiles.Add(obj);
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
            var infoPro = context.InfoProfiles.FirstOrDefault(x => x.InfoProfileID == id);
            if (infoPro != null)
            {
                try
                {
                    context.InfoProfiles.Remove(infoPro);
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

        public bool Edit(InfoProfile obj)
        {
            if (obj == null)
                return false;
            InfoProfile infoEdit = context.InfoProfiles.FirstOrDefault(x => x.InfoProfileID == obj.InfoProfileID);
            if (infoEdit == null)
                return false;
            infoEdit.Email = obj.Email;
            infoEdit.NumberPhone = obj.NumberPhone;
            infoEdit.Adress = obj.Adress;
            infoEdit.FullName = obj.FullName;
            infoEdit.Dob = obj.Dob;
            infoEdit.LinkFacebook = obj.LinkFacebook;
            infoEdit.Description = obj.Description;
            infoEdit.Slogan = obj.Slogan;
            infoEdit.AbumImageID = obj.AbumImageID;
            try
            {
                context.InfoProfiles.Attach(infoEdit);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public BaseView<InfoProfile> Get(out int total, InputBase input)
        {
            throw new NotImplementedException();
        }

        public InfoProfile GetId(int Id)
        {
            if (Id == default(int))
                return null;
            try
            {
                var model = context.InfoProfiles.FirstOrDefault(x => x.InfoProfileID == Id);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
