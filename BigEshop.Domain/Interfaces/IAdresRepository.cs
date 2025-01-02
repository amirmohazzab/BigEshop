using BigEshop.Domain.Models.Adres;
using BigEshop.Domain.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigEshop.Domain.Interfaces
{
    public interface IAdresRepository
    {
        Task<List<Adres>> GetAllAsync();

        void Update(Adres adres);

        Task InsertAsync(Adres adres);

        Task<Adres> GetByIdAsync(int id);

        Task SaveAsync();
    }
}
