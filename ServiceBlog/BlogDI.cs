using ServiceBlog.Implement;
using ServiceBlog.Inteface;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiceBlog
{
    public class BlogDI
    {
        static readonly Container container = new Container();
        public static void InitializeInjector()
        {
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IServiceAlbum, ServiceAlbum>(Lifestyle.Scoped);
            container.Register<IServiceBlog,ServiceBlog.Implement.ServiceBlog> (Lifestyle.Scoped);
            container.Register<IServiceImage, ServiceImage>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

        }
        public static IServiceAlbum albumService
        {
            get
            {
                return container.GetInstance<ServiceAlbum>();
            }
        }
        public static IServiceBlog blogService
        {
            get
            {
                return container.GetInstance<ServiceBlog.Implement.ServiceBlog>();
            }
        }
        public static IServiceImage imageService
        {
            get
            {
                return container.GetInstance<ServiceImage>();
            }
        }
    }
}
