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
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Token { get; set; }
        public ApplicationUser User { get; set; }
    }

    public class MobileNotificationTokensViewModel
    {
        public string Token { get; set; }
    }
}