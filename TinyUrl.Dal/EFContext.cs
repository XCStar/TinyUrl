using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using TinyUrl.Model;
namespace TinyUrl.Dal
{
    public class EFContext : DbContext
    {
        public EFContext (DbContextOptions options) : base (options)
        {

        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {

            var t = typeof (Entity);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies ();
            foreach (var ass in assemblies)
            {
                var types = ass.GetTypes ().Where (x =>!x.IsInterface&&!x.IsAbstract&& x.IsPublic && t.IsAssignableFrom (x)&&x.Name!=t.Name).ToArray ();

                foreach (var item in types)
                {
                   
                    modelBuilder.Entity(item).HasKey("ID");
                }
            }
           // modelBuilder.Entity(typeof(UrlItem));
            base.OnModelCreating (modelBuilder);

        }
    }
}