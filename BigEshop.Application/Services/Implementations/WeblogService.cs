using BigEshop.Application.Extensions;
using BigEshop.Application.Services.Interfaces;
using BigEshop.Application.Statics;
using BigEshop.Data.Implementations;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Product;
using BigEshop.Domain.Models.Weblog;
using BigEshop.Domain.ViewModels.Weblog;
using BigEshop.Domain.ViewModels.WeblogCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Application.Services.Implementations
{
    public class WeblogService (IWeblogRepository weblogRepository) : IWeblogService
    {
        public async Task<CreateWeblogResult> CreateAsync(CreateWeblogViewModel model)
        {
            Weblog weblog = new()
            {
                CategoryId = model.CategoryId,
                Title = model.Title,
                Description = model.Description,
                Slug = model.Slug,
                IsDelete = false,
                CreateDate = DateTime.Now,
            };

            if (model.Image != null)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);

                string path = PathTools.WeblogImagePath;
                model.Image.AddImageToServer(imageName, path);

                weblog.Image = imageName;
            }

            await weblogRepository.InsertAsync(weblog);
            await weblogRepository.SaveAsync();

            return CreateWeblogResult.Success;
        }

        public async Task<DeleteWeblogResult> DeleteAsync(int id)
        {
            var weblog = await weblogRepository.GetByIdAsync(id);

            if (weblog == null)
                return DeleteWeblogResult.WeblogNotFound;

            weblog.IsDelete = true;

            weblogRepository.Update(weblog);
            await weblogRepository.SaveAsync();

            return DeleteWeblogResult.Success;
        }

        public async Task<UpdateWeblogViewModel> GetForEditAsync(int id)
        {
            var weblog = await weblogRepository.GetByIdAsync(id);

            if (weblog == null)
                return null;

            return new UpdateWeblogViewModel()
            {
                Id = weblog.Id,
                CategoryId = weblog.CategoryId,
                Title = weblog.Title,
                Description = weblog.Description,
                Slug = weblog.Slug,
                ImageName = weblog.Image
            };
        }

        public async Task<UpdateWeblogResult> UpdateAsync(UpdateWeblogViewModel model)
        {
            var weblog = await weblogRepository.GetByIdAsync(model.Id);

            if (weblog == null)
                return UpdateWeblogResult.WeblogNotFound;

            if (await weblogRepository.DuplicatedSlugAsync(model.Slug, model.Id))
                return UpdateWeblogResult.SlugDuplicated;

            weblog.CategoryId = model.CategoryId;
            weblog.Title = model.Title;
            weblog.Description = model.Description;
            weblog.Slug = model.Slug;

            if (model.NewImage != null)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(model.NewImage.FileName);

                string path = PathTools.WeblogImagePath;
                model.NewImage.AddImageToServer(imageName, path, null, null, null, weblog.Image);

                weblog.Image = imageName;
            }

            weblogRepository.Update(weblog);
            await weblogRepository.SaveAsync();

            return UpdateWeblogResult.Success;
        }

        public async Task<List<Weblog>> GetAllAsync()
        {
            return await weblogRepository.GetAllAsync();
        }

        public async Task<ClientWeblogDetailsViewModel> GetDetailsAsync(string slug)
        {
            var weblog = await weblogRepository.GetBySlugAsync(slug);

            if (weblog == null)
                return null;

            return new ClientWeblogDetailsViewModel()
            {
                Id = weblog.Id,
                Title = weblog.Title,
                CategoryId = weblog.CategoryId,
                Description = weblog.Description,
                Image = weblog.Image,
                Slug = weblog.Slug,
                CreateDate = weblog.CreateDate,
                WeblogComments = weblog?.WeblogComments,
                WeblogCategory = weblog?.WeblogCategory
            };
        }

        public async Task<AdminSideFilterWeblogViewModel> FilterAsync(AdminSideFilterWeblogViewModel model)
        {
            return await weblogRepository.FilterAsync(model);
        }

        public async Task<ClientSideFilterWeblogViewModel> FilterAsync(ClientSideFilterWeblogViewModel model)
        {
            return await weblogRepository.FilterAsync(model);
        }
    }
}
