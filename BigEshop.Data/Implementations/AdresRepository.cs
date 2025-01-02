using BigEshop.Data.Context;
using BigEshop.Domain.Interfaces;
using BigEshop.Domain.Models.Adres;
using BigEshop.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Data.Implementations
{
    public class AdresRepository (BigEshopContext context) : IAdresRepository
    {
        public async Task<List<Adres>> GetAllAsync()
        => await context.Adreses.Where(a => !a.IsDelete).ToListAsync();

        public async Task<Adres> GetByIdAsync(int id)
        => await context.Adreses.FirstOrDefaultAsync(a => a.Id == id);
            
        public async Task InsertAsync(Adres adres)
        => await context.Adreses.AddAsync(adres);

        public async Task SaveAsync()
        => await context.SaveChangesAsync();

        public void Update(Adres adres)
        => context.Adreses.Update(adres);
    }
}
