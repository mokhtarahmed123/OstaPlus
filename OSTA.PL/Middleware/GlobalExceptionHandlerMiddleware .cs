using Microsoft.AspNetCore.Mvc;

namespace OSTA.PL.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BLL.Exceptions.ApplicationException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
            catch (BLL.Exceptions.NotFoundException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status404NotFound, "Not Found");
            }
            catch (BLL.Exceptions.UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status401Unauthorized, "Unauthorized");
            }
            catch (BLL.Exceptions.BadRequestException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest, "Bad Request");
            }
            catch (BLL.Exceptions.ConflictException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status409Conflict, "Conflict");
            }
            catch (BLL.Exceptions.ValidationException ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest, "InValidation Exception");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode, string title)
        {
            var traceId = Guid.NewGuid();

            _logger.LogError(ex,
                "Error occurred while processing the request. TraceId: {TraceId}, Message: {Message}",
                traceId, ex.Message);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var problemDetails = new ProblemDetails
            {
                Title = title,
                Status = statusCode,
                Instance = context.Request.Path,
                Detail = $"{ex.Message} (TraceId: {traceId})"
            };

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
