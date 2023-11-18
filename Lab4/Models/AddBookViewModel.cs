namespace Lab4.Models
{
    public class AddBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
