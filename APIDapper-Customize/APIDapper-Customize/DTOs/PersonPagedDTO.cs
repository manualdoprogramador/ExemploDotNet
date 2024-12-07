namespace APIDapper_Customize.DTOs
{
    public class PersonPagedDTO
    {
        public IEnumerable<PersonDTO> Data { get; set; }
        public int TotalLines { get; set; }
    }
}
