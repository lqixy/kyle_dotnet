using System.ComponentModel.DataAnnotations;

namespace Kyle.Todos.ViewModels;

public class TodoViewModel
{

    // public TodoViewModel()
    // {
    //     
    // }
    //
    // public TodoViewModel(string content)
    // {
    //     Content = content;
    //     UserId = Guid.Parse("18F77F9F-825B-B467-3743-BD62E76B12CB");
    // }

    [Required(ErrorMessage = "内容不能为空")]
    public string Content { get; set; }
 

    public Guid UserId { get; set; }=Guid.Parse("18F77F9F-825B-B467-3743-BD62E76B12CB");
 
}