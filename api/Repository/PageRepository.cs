using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Page;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PageRepository : IPageRepository
    {
        private readonly ApplicationDBContext _context;

        public PageRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<List<Page>> GetAllAsync(QueryObject query)
        {
            var pages = _context.Pages.Include(a => a.AppUser).Include(c => c.Comments).ThenInclude(a => a.AppUser).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                pages = pages.Where(s => s.Title.Contains(query.Title));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    pages = query.IsDescending ? pages.OrderByDescending(s => s.Title) : pages.OrderBy(s => s.Title);
                }
            }

            var skipNumber = (query.pageNumber - 1) * query.pageSize;

            return await pages.Skip(skipNumber).Take(query.pageSize).ToListAsync();
        }

        public async Task<Page?> GetByIdAsync(int id)
        {
            return await _context.Pages.Include(a => a.AppUser).Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Page> CreateAsync(Page pageModel)
        {
            await _context.Pages.AddAsync(pageModel);
            await _context.SaveChangesAsync();
            return pageModel;
        }

        public async Task<Page?> DeleteAsync(int id)
        {
            var pageModel = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);
            
            if (pageModel == null)
            {
                return null;
            }

            _context.Pages.Remove(pageModel);
            await _context.SaveChangesAsync();
            return pageModel;
        }

        public async Task<Page?> UpdateAsync(int id, UpdatePageRequestDto pageDto)
        {
            var existingPage = await _context.Pages.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPage == null)
            {
                return null;
            }

            existingPage.Title = pageDto.Title;
            existingPage.Content = pageDto.Content;
            existingPage.CreatedOn = DateTime.Now;

            await _context.SaveChangesAsync();
            return existingPage;
        }

        public Task<bool> PageExists(int id)
        {
            return _context.Pages.AnyAsync(s => s.Id == id);
        }
    }
}