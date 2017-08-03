using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace JabuBackendServer.Providers
{
  public class CustomApiController : ApiController
  {
    public HttpResponseMessage Success<T>(HttpRequestMessage request, T value, MediaTypeHeaderValue mediaType = null)
    {
      return request.CreateResponse(HttpStatusCode.OK, value);
    }

    public static HttpResponseMessage BadRequest<T>(HttpRequestMessage request, T value, MediaTypeHeaderValue mediaType = null)
    {
      return request.CreateResponse(HttpStatusCode.BadRequest, value);
    }

    public static HttpResponseMessage ServerError(HttpRequestMessage request, Exception ex)
    {
      return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
    }
  }
}