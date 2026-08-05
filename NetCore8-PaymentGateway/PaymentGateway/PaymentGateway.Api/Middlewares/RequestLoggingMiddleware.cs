using System.Diagnostics;

namespace PaymentGateway.Api.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(
        RequestDelegate next,
        ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var watch = Stopwatch.StartNew();

        var ip = context.Connection.RemoteIpAddress?.ToString();

        _logger.LogInformation(
            "Inicio Request | {Method} {Path} | IP:{IP}",
            context.Request.Method,
            context.Request.Path,
            ip);

        await _next(context);

        watch.Stop();

        _logger.LogInformation(
            "Fin Request | Status:{Status} | Tiempo:{Time} ms",
            context.Response.StatusCode,
            watch.ElapsedMilliseconds);
    }
}