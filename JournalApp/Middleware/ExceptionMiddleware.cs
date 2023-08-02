using LogicLayer.Dto;
using LogicLayer.Dto.log;
using LogicLayer.Service;
using LogicLayer.Service.iFaces;
using LogicLayer.ServiceException;
using System.Net;

namespace JournalApp.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerService logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, LogService logService)
        {
            try
            {
                await next(httpContext);
            }
            catch (ArgumentNullException ex)
            {
                logger.LogError($"A new ArgumentNullException has been thrown: {ex}");
                await HandleExceptionAsync(httpContext, ex, logService);
            }
            catch (ArgumentException ex)
            {
                logger.LogError($"A new ArgumentException has been thrown: {ex}");
                await HandleExceptionAsync(httpContext, ex, logService);
            }
            catch (NotFoundException ex)
            {
                logger.LogError($"A new NotFoundException has been thrown: {ex}");
                await HandleExceptionAsync(httpContext, ex, logService);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex, logService);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, LogService logService)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                ArgumentNullException => (int)HttpStatusCode.BadRequest,
                ArgumentException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var message = exception switch
            {
                ArgumentNullException => exception.Message,
                ArgumentException => exception.Message,
                NotFoundException => exception.Message,
                _ => "Internal Server Error from the custom middleware."
            };

            var controllerName = context.GetRouteData().Values["controller"];
            var actionName = context.GetRouteData().Values["action"];
            LogCreateDto log = new LogCreateDto();
            log.Exception = $"{exception.ToString()}.{exception.InnerException}";
            log.Message = message;
            log.Service = $"{controllerName}.{actionName}";
            log.DateTime = DateTime.Now;
            logService.Add(log);

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
