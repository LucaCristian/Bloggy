using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Page;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IPageRepository
    {
        Task<List<Page>> GetAllAsync(QueryObject query);
        Task<Page?> GetByIdAsync(int id);
        Task<Page> CreateAsync (Page pageModel);
        Task<Page?> UpdateAsync(int id, UpdatePageRequestDto pageDto);
        Task<Page?> DeleteAsync(int id);
        Task<bool> PageExists(int id);
    }
}