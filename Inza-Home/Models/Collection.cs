namespace Inza_Home.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Description2 { get; set; } = "";
        public int Order { get; set; }
        public bool ShowSlider { get; set; }
        public bool ShowCard { get; set; }
    }
}
