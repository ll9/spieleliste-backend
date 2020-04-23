namespace spieleliste_backend.Dtos
{
    public class ResourceParameters
    {
        public const int MaxPageSize = 20;

        private int _page = 1;

        public int Page
        {
            get => _page;
            set => _page = value > 0 ? value : 1;
        }

        private int _pageSize = MaxPageSize;

        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value > 1 && value < MaxPageSize ? value : MaxPageSize;
            }
        }

        public int SkipCount => (Page - 1) * PageSize;
    }
}