using System.Net;
using AMVTravel.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AMVTravel.Application.Middlewares
{
    public class MiddlewareException
	{
		private readonly RequestDelegate _requestDelegate;

		public MiddlewareException(RequestDelegate requestDelegate)
		{
			_requestDelegate = requestDelegate;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _requestDelegate.Invoke(context);
			}
			catch (ArgumentException ex)
			{
				var response = context.Response;
				response.StatusCode = (int)HttpStatusCode.BadRequest;
				await HandleException(response, ex.Message);
			}
			catch (Exception ex)
			{
                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await HandleException(response, ex.Message);
            }
		}

        private async Task HandleException(HttpResponse response, string message)
        {
			response.ContentType = "application/json";
			await response.WriteAsync(JsonConvert.SerializeObject(new RespuestaBase<object>
			{
				Codigo = response.StatusCode,
				Data = null,
				Mensaje = message
			}));
        }
    }
}

