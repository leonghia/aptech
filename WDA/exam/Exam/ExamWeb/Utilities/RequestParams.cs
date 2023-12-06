namespace ExamWeb.Utilities
{
    public class RequestParams
    {

        public int PageNumber { get; set; } = 1;

        private const int _maxPageSize = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }

            set
            {
                _pageSize = value > _maxPageSize ? _maxPageSize : value;
            }
        }
    }
}
