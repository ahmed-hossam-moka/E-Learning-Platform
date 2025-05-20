namespace OnlineLearningPlatform.BLL.Dtos
{
    public class PagedResponseDto<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } // Items per page
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; } // Total items in database
        public T Data { get; set; }  // The actual course data

        public PagedResponseDto(T data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            Data = data;
        }
    }
}