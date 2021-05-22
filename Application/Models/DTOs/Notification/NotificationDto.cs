using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs.Notification
{
    public class NotificationDto
    {
        public int NotificationID { get; set; }
        public string NotificationTexte { get; set; }
        public DateTime NotificationDate { get; set; }
        public Boolean NotificationVu { get; set; }
        public int UserId { get; set; }
    }
}
