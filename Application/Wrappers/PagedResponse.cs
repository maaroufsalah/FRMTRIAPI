using System.Collections.Generic;

namespace Application.Wrappers
{
    public class PagedResponse<T>
    {
        public PagedResponse() { }
        public PagedResponse(string message) => (Succeeded, Message) = (false, message);
        public PagedResponse(IReadOnlyCollection<T> data, int count, int pageIndex, int pageSize) => (Succeeded, Message, Data) = (true, null, new PaginatedList<T>(data, count, pageIndex, pageSize));

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public PaginatedList<T> Data { get; set; }
    }
}