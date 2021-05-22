using System;

namespace Application.Interfaces.IServices
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}