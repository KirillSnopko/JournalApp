using LogicLayer.Dto;
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (ArgumentNullException ex)
            {
                logger.LogError($"A new ArgumentNullException has been thrown: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (ArgumentException ex)
            {
                logger.LogError($"A new ArgumentException has been thrown: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (NotFoundException ex)
            {
                logger.LogError($"A new NotFoundException has been thrown: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
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

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
