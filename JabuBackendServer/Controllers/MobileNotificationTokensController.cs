using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using JabuBackendServer.Models;
using JabuBackendServer.Providers;

namespace JabuBackendServer.Controllers
{
  [RoutePrefix("api/mobileNotify")]
  public class MobileNotificationTokensController : CustomApiController
  {
    private DataAccess.DataAccess repo;

    public MobileNotificationTokensController()
    {
      repo = new DataAccess.DataAccess();
    }

    [Route("post")]
    public async Task<HttpResponseMessage> Post([FromBody] MobileNotificationTokens notfy)
    {
      try
      {
        var _notify = await repo.CreateMobileNotification(notfy);
        return _notify == null ? BadRequest(Request, "could not save the token") : Success(Request, _notify);
      }catch(Exception ex)
      {
        return ServerError(Request, ex);
      }
    }
    [Route("get")]
    public async Task<HttpResponseMessage> Get()
    {
      try
      {
        var _notify = await repo.GetMobileNotifications();
        return _notify == null ? BadRequest(Request, "could not save the token") : Success(Request, _notify);
      }
      catch (Exception ex)
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