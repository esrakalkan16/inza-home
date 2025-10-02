namespace Inza_Home.Models
{
    public class HomeIndexViewModel
    {
        public List<Collection> Collections { get; set; } = new();
        public List<CollectionImage> CollectionImages { get; set; } = new();
    }

    public class CollectionVm
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";  
        public string? CoverImage { get; set; }



        public List<string> Images { get; set; } = new();
    }

}
