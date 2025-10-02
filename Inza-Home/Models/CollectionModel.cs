namespace Inza_Home.Models
{
    public class CollectionModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string CoverImage { get; set; } = "";
        public List<string> Images { get; set; } = new List<string>();
        public int Order { get; set; }
        public bool Show { get; set; }
    }

}
