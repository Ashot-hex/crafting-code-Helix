namespace Tax.Simulator.Api;

public class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsync(
                $"An unexpected error occurred. Please try again later.{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.StackTrace}"
            );
        }
    }
}