using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LuthKemp;
using JabuBackendServer.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JabuBackendServer.DataAccess
{
  public class DataAccess : IDataAccess
  {
    private ApplicationDbContext db; 
    public DataAccess()
    {
      db = new ApplicationDbContext();
    }

    public async Task<Event> CreateEvent(Event eventObject)
    {
      db.Events.Add(eventObject);
      return await db.SaveChangesAsync() > 0 ? eventObject : null;
    }

    public async Task<Notification> CreateNotification(Notification notification)
    {
      db.Notifications.Add(notification);
      return await db.SaveChangesAsync() > 0 ? notification : null;
    }

    public async Task<Prayer> CreatePrayer(Prayer prayer)
    {
      db.Prayers.Add(prayer);
      return await db.SaveChangesAsync() > 0 ? prayer : null;
    }

    public async Task<Event> GetEvent(int Id , string parameters = null, DateTime? date = null)
    {
      if(parameters == null)
      {
        return await db.Events.FindAsync(Id);
      }else if( parameters != null && date != null)
      {
        return db.Events.Single(x => x.Title.Equals(parameters) && x.Id.Equals(Id) && x.Date.Equals(date));
      }else if(date != null)
      {
        return db.Events.Single(x => x.Id.Equals(Id) && x.Date.Equals(date));
      }
      return null;
    }

    public async Task<List<Event>> GetEvents(string title = null, DateTime? date = null)
    {
      if (date != null && title != null)
      {
        return await db.Events.Where(x=> x.Date.Equals(date) && x.Title.Equals(title)).ToListAsync();
      }
      else if (date != null)
      {
        return await db.Events.Where(x => x.Date.Equals(date)).ToListAsync();
      }
      else if (title != null)
      {
        return await db.Events.Where(x => x.Title.Equals(title)).ToListAsync();
      }
      else
      {
        var _events = await db.Events.ToListAsync();
        _events.ForEach(delegate (Event ev)
        {
          ev.Date = ev.Date;
        });
        return _events;
      }
    }

    public async Task<Notification> GetNotification(int Id, string title = null)
    {
      if (title == null)
      {
        return db.Notifications.Single(x=>x.Title.Equals(title) && x.Id.Equals(Id));
      }
      else
      {
        return await db.Notifications.FindAsync(Id);
      }
    }

    public async Task<List<Notification>> GetNotifications(string title = null)
    {
      return string.IsNullOrEmpty(title) ? await db.Notifications.ToListAsync() : await db.Notifications.Where(x => x.Title.Equals(title)).ToListAsync();
    }

    public async Task<Prayer> GetPrayer(int Id)
    {
      return await db.Prayers.FindAsync(Id);
    }

    public async Task<List<Prayer>> GetPrayers(string email = null)
    {
      return string.IsNullOrEmpty(email) ? await db.Prayers.ToListAsync() : await db.Prayers.Where(x => x.Email.Equals(email)).ToListAsync();
    }

    public async Task<bool> UpdateEvent(Event eventObject)
    {
      var events = await db.Events.FindAsync(eventObject.Id);
      events.Address = eventObject.Address;
      events.ContactPerson = eventObject.ContactPerson;
      events.Date = eventObject.Date;
      events.Description = eventObject.Description;
      events.Email = eventObject.Email;
      events.Show = eventObject.Show;
      events.Title = eventObject.Title;
      db.Entry(events).State = EntityState.Modified;

      return await db.SaveChangesAsync() > 0 ? true : false;
    }

    public async Task<bool> UpdateNotification(Notification notifacation)
    {
      var _notification = await db.Notifications.FindAsync(notifacation.Id);
      _notification.Message = notifacation.Message;
      _notification.Title = notifacation.Title;
      db.Entry(_notification).State = EntityState.Modified;

      return await db.SaveChangesAsync() > 0 ? true : false;
    }

    public async Task<bool> UpdatePrayer(Prayer prayer)
    {
      var _prayer = await db.Prayers.FindAsync(prayer.Id);
      _prayer.Description = prayer.Description;
      _prayer.Email = prayer.Email;
      _prayer.FirstName = prayer.FirstName;
      _prayer.PhoneNumber = prayer.PhoneNumber;
      _prayer.Surname = prayer.Surname;
      db.Entry(_prayer).State = EntityState.Modified;
     
      return await db.SaveChangesAsync() > 0 ? true : false;
    }
    public void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
    }

    public async Task<MobileNotificationTokens> CreateMobileNotification(MobileNotificationTokens mobileNotfy)
    {
      db.MobileNotificationToken.Add(mobileNotfy);
      return await db.SaveChangesAsync() > 0 ? mobileNotfy : null;
    }

    public async Task<List<MobileNotificationTokens>> GetMobileNotifications()
    {
      return await db.MobileNotificationToken.ToListAsync();
    }

  }
}