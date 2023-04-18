using AutoMapper;
using Kyle.Todos.Application.Constructs;
using Kyle.Todos.Domain.Entities;

namespace Kyle.Todos.Application;

public class TodoProfile:  Profile
{
    public TodoProfile()
    {
        CreateMap<Todo, TodoDto>();
        CreateMap<TodoDto, Todo>();
    }
}