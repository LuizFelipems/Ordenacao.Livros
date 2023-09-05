namespace Ordenacao.Application.Commons.Responses
{
    public class PagedListResponse<TData>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecordCount { get; set; }
        public int TotalPages { get; set; }
        public List<TData> Records { get; set; } = new List<TData>();
    }
}
