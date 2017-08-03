using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LuthKemp;
using JabuBackendServer.Providers;

namespace JabuBackendServer.Controllers
{
    [RoutePrefix("api/notify")]
    public class NotificationsController : CustomApiController
  {
    private DataAccess.DataAccess repo;
    public NotificationsController()
    {
      repo = new DataAccess.DataAccess();
    }
    // GET: api/Notifications
    [Route("all_notifications")]
    [ResponseType(typeof(List<Notification>))]
    public async Task<HttpResponseMessage> GetNotifications()
    {
      try
      {
        var notification = await repo.GetNotifications();
        return notification != null ? Success(Request, notification) : BadRequest(Request, "Failed to get the notifications");
      }
      catch (Exception ex)
      {
        return ServerError(Request, ex);
      }
    }

    [Route("getNotification")]
    [ResponseType(typeof(Notification))]
    public async Task<HttpResponseMessage> GetNotification(int id,string title = null)
    {
      try
      {
        var notification = await repo.GetNotification(id,title);
        return notification != null ? Success(Request, notification) : BadRequest(Request, "Failed to get the notification");
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