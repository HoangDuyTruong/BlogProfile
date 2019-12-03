using DomainBlog.Profile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBlog.Inteface
{
    public interface IServiceAlbum : IResponsitory<AbumImage>
    {
        bool RemoveImageAlbum(int IdAlbum, int IdImages);
        Image AddImageAlbum(ImageType image);
    }
}
