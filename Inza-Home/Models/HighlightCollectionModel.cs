namespace Inza_Home.Models
{
    public class HighlightCollectionModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string HighlightDescription { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool Show { get; set; } 
    }
}
    