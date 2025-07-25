﻿using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _titleService;

        public PostsController(IPostsService titlesService)
        {
            _titleService = titlesService;
        }

        [HttpGet]
        public async Task<IEnumerable<PostDto>> Get() =>
            await _titleService.Get();
    }
}
