using AutoMapper;
using Kyle.Common;
using Kyle.Todos.Application.Constructs;
using Kyle.Todos.Domain;
using Kyle.Todos.Domain.Entities;

namespace Kyle.Todos.Application;

public class TodoAppService: ITodoAppService
{
    private readonly ITodoRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILongGenerator _generator;

    public TodoAppService(ITodoRepository repository, IMapper mapper, ILongGenerator generator)
    {
        _repository = repository;
        _mapper = mapper;
        _generator = generator;
    }

    public async Task<IEnumerable<TodoDto>> Get(long userId)
    {
        var entities = await _repository.Get(userId);
        // return Enumerable.Empty<TodoDto>();
        return _mapper.Map<IEnumerable<TodoDto>>(entities);
    }

    public async Task<TodoDto> Get(int id)
    {
        var entity = await _repository.Get(id);
        return _mapper.Map<TodoDto>(entity);
    }

    public async Task Add(TodoDto dto)
    {
        dto.BuildId(_generator.Create());
        var entity = _mapper.Map<Todo>(dto);
        await _repository.Insert(entity);
    }
}