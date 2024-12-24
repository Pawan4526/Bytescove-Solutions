namespace Bytescove_Solutions.Models
{
    public class EmailViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string Skype { get; set; }
        public string LookingFor { get; set; }
        public string Body { get; set; }
        public IFormFile Attachment { get; set; }
    }
}
