//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainBlog.Profile.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public Image()
        {
            this.CategoryBlogs = new HashSet<CategoryBlog>();
            this.ImageTypes = new HashSet<ImageType>();
        }
    
        public int ImageID { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
    
        public virtual ICollection<CategoryBlog> CategoryBlogs { get; set; }
        public virtual ICollection<ImageType> ImageTypes { get; set; }
    }
}
