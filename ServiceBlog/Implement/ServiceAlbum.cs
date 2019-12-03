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
    public class ServiceAlbum : IServiceAlbum
    {
        private readonly BlogProfileEntities context = new BlogProfileEntities();
        public Image AddImageAlbum(ImageType image)
        {
            var modelImage = context.Images.FirstOrDefault(x => x.ImageID == image.ImageID);
            var modelAlbum = context.AbumImages.FirstOrDefault(x => x.AbumImageID == image.AbumImageID);
            if (modelAlbum != null && modelImage != null)
            {
                try
                {
                    var model = context.ImageTypes.Add(image);
                    context.SaveChanges();
                    return modelImage;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            else
                return null;
        }

        public AbumImage Create(AbumImage obj)
        {
            if (obj != null)
            {
                try
                {
                    var model = context.AbumImages.Add(obj);
                    context.SaveChanges();
                    return model;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            var model = context.AbumImages.FirstOrDefault(x => x.AbumImageID == id);
            if (model != null)
            {
                try
                {
                    context.AbumImages.Remove(model);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
                return false;
        }

        public bool Edit(AbumImage obj)
        {
            try
            {
                var albumEdit = context.AbumImages.FirstOrDefault();
                if (albumEdit == null)
                    return false;
                else
                {
                    albumEdit.Description = obj.Description;
                    albumEdit.NameAbum = obj.NameAbum;
                    albumEdit.TypeAbum = obj.TypeAbum;
                    context.AbumImages.Attach(albumEdit);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public BaseView<AbumImage> Get(out int total, InputBase input)
        {
            throw new NotImplementedException();
        }

        public AbumImage GetId(int Id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveImageAlbum(int IdAlbum, int IdImages)
        {
            throw new NotImplementedException();
        }
    }
}
