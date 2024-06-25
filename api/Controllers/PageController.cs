using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Page;
using api.Extensions;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/page")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public readonly IPageRepository _pageRepo;
        private readonly UserManager<AppUser> _userManager;

        public PageController(ApplicationDBContext context, IPageRepository pageRepo, UserManager<AppUser> userManager)
        {
            _pageRepo = pageRepo;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pages = await _pageRepo.GetAllAsync(query);

            var pageDto = pages.Select(s => s.ToPageDto()).ToList();

            return Ok(pages);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var page = await _pageRepo.GetByIdAsync(id);

            if (page == null)
            {
                return NotFound();
            }
            
            return Ok(page.ToPageDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreatePageRequestDto pageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var pageModel = pageDto.ToPageFromCreateDto();
            pageModel.AppUserId = appUser.Id;

            await _pageRepo.CreateAsync(pageModel);
            return CreatedAtAction(nameof(GetById), new { id = pageModel.Id }, pageModel.ToPageDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePageRequestDto pageDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pageModel = await _pageRepo.UpdateAsync(id, pageDto);

            if (pageModel == null)
            {
                return NotFound();
            }

            return Ok(pageModel.ToPageDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var pageModel = await _pageRepo.DeleteAsync(id);

            if (pageModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}