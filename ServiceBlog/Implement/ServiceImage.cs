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
    public class ServiceImage : IServiceImage
    {
        private readonly BlogProfileEntities context = new BlogProfileEntities();
        public Image Create(Image obj)
        {
            if (obj == null)
                return null;
            try
            {
                var model= context.Images.Add(obj);
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
            var images = context.Images.FirstOrDefault(x => x.ImageID == id);
            if (images == null)
                return false;
            else
            {
                try
                {
                    context.Images.Remove(images);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool Edit(Image obj)
        {
            if (obj != null)
                return false;
            var images = context.Images.FirstOrDefault(x => x.ImageID == obj.ImageID);
            if (images == null)
                return false;
            else
            {
                try
                {
                    images.FileName = obj.FileName;
                    images.ImageTypes = obj.ImageTypes;
                    images.Path = obj.Path;
                    context.Images.Attach(images);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public BaseView<Image> Get(out int total, InputBase input)
        {
            InputImage filter = input as InputImage;
            BaseView<Image> reponse = new BaseView<Image>();
            try
            {
                total = context.Images.Count();
                IQueryable query = context.Set<Image>().AsNoTracking();
                if (filter.FileName != "" && filter.FileName != null)
                    query = query.OfType<Image>().Where(x => x.FileName.Contains(filter.FileName));
                query = query.OfType<Image>().OrderBy(x => x.ImageID).Skip(filter.Size * filter.PageSize).Take(filter.Size);
                reponse.Data = query.OfType<Image>().ToList();
                reponse.Status = 1;
                return reponse;
            }
            catch (Exception ex)
            {
                total = 0;
                return null;
            }
        }

        public Image GetId(int Id)
        {
            if (Id == default(int))
                return null;
            try
            {
                var model = context.Images.FirstOrDefault(x => x.ImageID == Id);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
