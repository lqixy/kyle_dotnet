using Kyle.Extensions.Exceptions;
using Kyle.Extensions.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using ILogger = Serilog.ILogger;

namespace Kyle.Members.Filters;

public class CustomExceptionFilter: IExceptionFilter
{
    private readonly ILogger _logger;

    public CustomExceptionFilter(ILogger logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        if (!(context.ActionDescriptor is ControllerActionDescriptor)) return;
        
        _logger.Error(context.Exception,context.Exception.Message);

        switch (context.Exception)
        {
            case UserFriendlyException:
                var ajaxResponse = new AjaxResponse(new{},  context.Exception.Message);
              context.Result =  new JsonResult(ajaxResponse);
                break;
            default:
                context.Result = new ObjectResult(new AjaxResponse(1103, "出错了!请稍后再试."));
                break;
                
        }
    }
}