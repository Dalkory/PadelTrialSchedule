using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PadelTrialSchedule.Api.Handlers;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var isClientError = exception is ArgumentException;
        var statusCode = isClientError
            ? StatusCodes.Status400BadRequest
            : StatusCodes.Status500InternalServerError;

        if (isClientError)
        {
            logger.LogWarning(exception, "Schedule request validation failed.");
        }
        else
        {
            logger.LogError(exception, "Unhandled API error.");
        }

        var problem = new ProblemDetails
        {
            Status = statusCode,
            Title = isClientError ? "Некорректный запрос" : "Внутренняя ошибка сервера",
            Detail = isClientError ? exception.Message : "Не удалось обработать запрос. Повторите попытку позже.",
            Instance = httpContext.Request.Path
        };
        problem.Extensions["traceId"] = httpContext.TraceIdentifier;

        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken).ConfigureAwait(false);
        return true;
    }
}
