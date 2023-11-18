namespace Lab4.Models
{
    public class UpdateBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
        public int Count { get; set; }
    }
}
