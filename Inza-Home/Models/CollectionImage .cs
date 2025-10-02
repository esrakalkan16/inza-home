namespace Inza_Home.Models
{
    public class CollectionImage
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public string ImageUrl { get; set; } = "";
        public bool DefaultImage { get; set; }
        public int Order { get; set; }
        public bool ShowInSlider { get; set; }
        public int SliderOrder { get; set; }
    }
}
