using AutoMapper;
using Kyle.Todos.Application.Constructs;

namespace Kyle.Todos.ViewModels;

public class TodoViewProfile: Profile
{
   public TodoViewProfile()
   {
       CreateMap<TodoViewModel,TodoDto>();
   }
}