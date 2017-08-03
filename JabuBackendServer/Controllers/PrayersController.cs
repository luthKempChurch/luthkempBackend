using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using JabuBackendServer.Models;
using LuthKemp;
using JabuBackendServer.Providers;

namespace JabuBackendServer.Controllers
{
  //[Authorize]
  [RoutePrefix("api/prayer")]
  public class PrayersController : CustomApiController
  {
    private DataAccess.DataAccess repo;

    public PrayersController()
    {
      repo = new DataAccess.DataAccess();
    }

    [Route("get")]
    public async Task<HttpResponseMessage> Get()
    {
      try
      {
        var Prayer = await repo.GetPrayers();
        return Prayer != null ? Success(Request,Prayer) : BadRequest(Request,"Failed");
      }
      catch(Exception ex)
      {
        return ServerError(Request, ex);
      }
     
    }
    [Route("post")]
    [ResponseType(typeof(Prayer))]
    public async Task<HttpResponseMessage> Post([FromBody]Prayer prayer )
    {
      try
      {
        var _prayer = await repo.CreatePrayer(prayer);
        return _prayer != null ? Success(Request, prayer) : BadRequest(Request, "Failed to create a prayer");
      }catch(Exception ex)
      {
        return ServerError(Request, ex);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        repo.Dispose(disposing);
      }
      base.Dispose(disposing);
    }
  }
}