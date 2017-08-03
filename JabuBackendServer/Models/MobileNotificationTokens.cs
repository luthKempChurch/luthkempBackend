using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JabuBackendServer.Models
{
    public class MobileNotificationTokens
    {
    public int Id { get; set; }
    [StringLength(65)]
    [Index("ix_Token", 1, IsUnique = true)]
    public string Token { get; set; }
    public string DeviceId { get; set; }
  }

    public class MobileNotificationTokensViewModel
    {
        public string Token { get; set; }
    }
}