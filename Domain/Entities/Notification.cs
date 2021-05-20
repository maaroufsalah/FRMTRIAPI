using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Entities
{
    public partial class Notification
    {
        public int Id { get; set; }
        public string TextHeader { get; set; }
        public string TextBody { get; set; }
        public string TypeNotification { get; set; }
        public bool? IsRead { get; set; }
        public int? UserId { get; set; }
        public int? UserType { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
