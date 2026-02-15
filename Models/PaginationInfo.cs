namespace ContentManagementSystem.Models
{
  public class PaginationInfo
  {
    private int _pageNumber = 1;

    public int PageNumber
    {
      get => _pageNumber;
      set => _pageNumber = value < 1 ? 1 : value;
    }
    public int PageSize { get; set; } = 5;
    public int TotalItems { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
  }
}
