using Application.Models.DTOs;
using Application.Models.DTOs.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.IServices
{
    public interface INotificationStorage
    {
        void Load(IList<NotificationDto> notificationList);
        void Add(NotificationDto notification);
        IList<NotificationDto> ReadAll();
        int GetCount();
    }
}
