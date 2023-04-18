using System;
using AutoMapper;
using Kyle.Todos.Application.Constructs;
using Kyle.Todos.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kyle.Todos.Controllers
{
    [ApiController]
    [Route("/api/todo")]
    [Authorize]
    public class TodosController: ControllerBase
    {
        private readonly ITodoAppService _appService;
        private readonly IMapper _mapper;
        public TodosController(ITodoAppService appService, IMapper mapper)
        {
            _appService = appService;
            _mapper = mapper;
        }

        [HttpPost("get")]
        public async Task<GetTodosResult> Get(long userId)
        {
            var result = await _appService.Get(userId);
            return new GetTodosResult(result);
        }

        [HttpGet("detail")]
        public async Task<TodoDto> Detail(int id)
        {
            return await _appService.Get(id);
        }

        [HttpPost("add")]
        public async Task Add(TodoViewModel vm)
        {
            var dto = _mapper.Map<TodoDto>(vm);
            await _appService.Add(dto);
        }

    }

}

