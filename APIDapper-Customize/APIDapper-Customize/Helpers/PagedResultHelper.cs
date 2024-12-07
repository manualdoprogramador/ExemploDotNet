namespace APIDapper_Customize.Helpers
{
    public class PagedResultHelper<T>
    {
        public int TotalRegisters { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
