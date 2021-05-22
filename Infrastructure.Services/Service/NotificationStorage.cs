using Application.Interfaces.IServices;
using Application.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Models.DTOs.Notification;

namespace Infrastructure.Services.Service
{
    public class NotificationStorage : INotificationStorage
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession session => httpContextAccessor.HttpContext.Session;
        public NotificationStorage(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void Load(IList<NotificationDto> notificationList)
        {
            httpContextAccessor.HttpContext.Session.SetString("notificationList", JsonConvert.SerializeObject(notificationList));
        }

        public void Add(NotificationDto notification)
        {
            IList<NotificationDto> notificationList;
            var notificationListString = httpContextAccessor.HttpContext.Session.GetString("notificationList");
            if (!string.IsNullOrEmpty(notificationListString))
                notificationList = JsonConvert.DeserializeObject<IList<NotificationDto>>(notificationListString);
            else
                notificationList = new List<NotificationDto>();
            notificationList.Add(notification);
            Load(notificationList);
        }

        public IList<NotificationDto> ReadAll()
        {
            IList<NotificationDto> notificationList;
            IList<NotificationDto> notificationListReturn;
            var notificationListString = httpContextAccessor.HttpContext.Session.GetString("notificationList");
            if (!string.IsNullOrEmpty(notificationListString))
            {
                notificationListReturn = JsonConvert.DeserializeObject<IList<NotificationDto>>(notificationListString);
                notificationList = JsonConvert.DeserializeObject<IList<NotificationDto>>(notificationListString);
            }
            else
            {
                notificationListReturn = new List<NotificationDto>();
                notificationList = new List<NotificationDto>();
            }
            Load(notificationList.Select(n => { n.NotificationVu = true; return n; }).ToList());
            return notificationListReturn.OrderByDescending(n=>n.NotificationDate).ToList();
        }

        public int GetCount()
        {
            IList<NotificationDto> notificationList;
            var notificationListString = httpContextAccessor.HttpContext.Session.GetString("notificationList");
            if (!string.IsNullOrEmpty(notificationListString))
                notificationList = JsonConvert.DeserializeObject<IList<NotificationDto>>(notificationListString);
            else
                notificationList = new List<NotificationDto>();
            return notificationList.Count(n => !n.NotificationVu);
        }
    }
}