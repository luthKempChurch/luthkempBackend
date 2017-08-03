using JabuBackendServer.Models;
using LuthKemp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabuBackendServer.DataAccess
{
  interface IDataAccess
  {
    #region "Events"
    Task<Event> CreateEvent(Event eventObject);
    Task<bool> UpdateEvent(Event eventObject);

    Task<Event> GetEvent(int Id, string title = null,DateTime? date = null);
    Task<List<Event>> GetEvents(string title = null, DateTime? date = null);
    #endregion

    #region "Prayers"
    Task<Prayer> CreatePrayer(Prayer prayer);
    Task<bool> UpdatePrayer(Prayer prayer);

    Task<Prayer> GetPrayer(int Id);
    Task<List<Prayer>> GetPrayers(string email = null);
    #endregion

    #region "Prayers"
    Task<Notification> CreateNotification(Notification notification);
    Task<bool> UpdateNotification(Notification prayer);

    Task<Notification> GetNotification(int Id, string title = null);
    Task<List<Notification>> GetNotifications(string title = null);
    #endregion

    #region "Mobile notifications"
    Task<MobileNotificationTokens> CreateMobileNotification(MobileNotificationTokens mobileNotfy);
   
    Task<List<MobileNotificationTokens>> GetMobileNotifications();
    #endregion
  }
}
