using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LuthKemp;
using JabuBackendServer.Providers;
using System.Collections.Generic;

namespace JabuBackendServer.Controllers
{
  [RoutePrefix("api/event")]
  public class EventsController : CustomApiController
  {
    private DataAccess.DataAccess repo;
    public EventsController()
    {
      repo = new DataAccess.DataAccess();
    }

    // GET: api/Events/5
    [Route("getEvent")]
    [ResponseType(typeof(Event))]
    public async Task<HttpResponseMessage> GetEvent(int id, string title = null, DateTime? date = null)
    {
      try
      {
        var @event = await repo.GetEvent(id, title, date);
        return @event != null ? Success(Request, @event) : BadRequest(Request, "Failed to get the event");
      }catch(Exception ex)
      {
        return ServerError(Request, ex);
      }
    }

    [Route("getEvents")]
    [ResponseType(typeof(List<Event>))]
    public async Task<HttpResponseMessage> GetEvents()
    {
      try
      {
        var @events = await repo.GetEvents();
        return @events != null ? Success(Request, @events) : BadRequest(Request, "Failed to get the events");
      }
      catch (Exception ex)
      {
        return ServerError(Request, ex);
      }
    }

    [Route("postEvent")]
    [ResponseType(typeof(List<Event>))]
    public async Task<HttpResponseMessage> PostEvent([FromBody]Event _event)
    {
      try
      {
        var @events = await repo.CreateEvent(_event);
        return @events != null ? Success(Request, @events) : BadRequest(Request, "Failed to get the events");
      }
      catch (Exception ex)
      {
        return ServerError(Request, ex);
      }
    }

    [Route("updateEvent")]
    [ResponseType(typeof(bool))]
    public async Task<HttpResponseMessage> PutEvent([FromBody]Event _event)
    {
      try
      {
        var @events = await repo.UpdateEvent(_event);
        return @events? Success(Request, "event updated") : BadRequest(Request, "Failed to update the events");
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