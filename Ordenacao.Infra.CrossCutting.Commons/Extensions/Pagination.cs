namespace Ordenacao.Infra.CrossCutting.Commons.Extensions
{
    public class Pagination<T>
    {
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalRecordCount { get; }
        public int TotalPages { get; set; }
        public ICollection<T> Records { get; }

        public Pagination(ICollection<T> records, int pageNumber, int pageSize, int totalRecords)
        {
            Records = records;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = CalculateTotalPages(pageSize, totalRecords);
            TotalRecordCount = totalRecords;
        }

        private int CalculateTotalPages(int pageSize, int totalRecords)
        {
            if (pageSize > 0 && totalRecords > 0)
                return (int)Math.Ceiling((float)totalRecords / pageSize);

            return 0;
        }
    }
}
