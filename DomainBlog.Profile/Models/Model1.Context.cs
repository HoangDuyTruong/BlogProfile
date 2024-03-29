﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlogProfileEntities : DbContext
    {
        public BlogProfileEntities()
            : base("name=BlogProfileEntities")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        public DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public DbSet<AbumImage> AbumImages { get; set; }
        public DbSet<Auth_Assign> Auth_Assign { get; set; }
        public DbSet<Auth_AssignEntity> Auth_AssignEntity { get; set; }
        public DbSet<Auth_Permissions> Auth_Permissions { get; set; }
        public DbSet<Auth_Roles> Auth_Roles { get; set; }
        public DbSet<Auth_UserRoles> Auth_UserRoles { get; set; }
        public DbSet<Auth_Users> Auth_Users { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<CategoryBlog> CategoryBlogs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageType> ImageTypes { get; set; }
        public DbSet<InfoProfile> InfoProfiles { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Sys_Config> Sys_Config { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<WorkExp> WorkExps { get; set; }
    }
}
