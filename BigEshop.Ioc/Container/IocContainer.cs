using BigEshop.Application.Services.Implementations;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Data.Implementations;
using BigEshop.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Ioc.Container
{
    public static class IocContainer
    {
        public static void RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAccountService, AccountService>();

            services.AddSingleton<ISmsSenderService, SmsSenderService>();
			services.AddSingleton<IEmailSender, EmailSender>();

			services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IProductFeatureService, ProductFeatureService>();
            services.AddScoped<IProductGalleryService, ProductGalleryService>();
            services.AddScoped<IProductColorService, ProductColorService>();

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IWeblogCategoryService, WeblogCategoryService>();
            services.AddScoped<IWeblogService, WeblogService>();

            services.AddScoped<INovinoService, NovinoService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductFeatureRepository, ProductFeatureRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IProductGalleryRepository, ProductGalleryRepository>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IWeblogCategoryRepository,  WeblogCategoryRepository>();
            services.AddScoped<IWeblogRepository, WeblogRepository>();
            #endregion
        }
    }
}
