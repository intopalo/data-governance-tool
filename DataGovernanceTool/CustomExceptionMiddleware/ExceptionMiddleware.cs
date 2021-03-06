using GlobalErrorHandling.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using DataGovernanceTool.Data.Models.Exceptions;


public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
 
    public ExceptionMiddleware(RequestDelegate next)
    {

        _next = next;
    }
 
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch(BaseException ex)
        {
            await HandleCustomException(httpContext, ex);

        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
 
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        string errorMessage;
        if(exception.InnerException == null)
            errorMessage = exception.Message;
        else
            errorMessage = exception.InnerException.Message;
 
        return context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = errorMessage
        }.ToString());
    }

     private static Task HandleCustomException(HttpContext context, BaseException exception)
    {
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)exception.StatusCode;

        string errorMessage;
        if(exception.InnerException == null)
            errorMessage = exception.Message;
        else
            errorMessage = exception.InnerException.Message;
 
        return context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = errorMessage
        }.ToString());
    }
}