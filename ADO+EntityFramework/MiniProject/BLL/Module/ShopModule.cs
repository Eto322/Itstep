using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services;
using DAL.Context;
using DAL.Repository;
using Ninject.Modules;

namespace BLL.Module
{
    public class ShopModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ShopContext>();
            

            Bind<CategoryRepository>().To<CategoryRepository>();
            Bind<GoodRepository>().To<GoodRepository>();
            Bind<ManufacturerRepository>().To<ManufacturerRepository>();

            Bind<CategoryService>().To<CategoryService>();
            Bind<GoodService>().To<GoodService>();
            Bind<ManufacturerService>().To<ManufacturerService>();
            
        }

    }
}
