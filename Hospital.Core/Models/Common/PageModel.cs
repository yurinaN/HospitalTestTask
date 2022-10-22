namespace Hospital.Core.Models.Common
{
    public class PageModel<T>
    {
        public PageModel(List<T> items, int count)
        {
            Items = items;
            Count = count;
        }

        public List<T> Items { get; set; }
        public int Count { get; set; }
    }
}
