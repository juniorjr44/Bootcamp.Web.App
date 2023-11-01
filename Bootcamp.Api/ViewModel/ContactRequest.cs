namespace Bootcamp.Api.ViewModel
{
    public class ContactRequest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ContactType { get; set; }
        public string? ContactAddress { get; set; }
    }
}
