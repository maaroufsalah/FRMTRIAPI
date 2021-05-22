using Application.Interfaces.IServices;
using System;

namespace Infrastructure.Services.Shared
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
