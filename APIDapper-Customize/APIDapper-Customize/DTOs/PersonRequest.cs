namespace APIDapper_Customize.DTOs
{
    public class PersonRequest
    {
        public PersonRequest()
        {
            Page = 1;
            PageSize = 5;
        }
        
        public string? Name { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
