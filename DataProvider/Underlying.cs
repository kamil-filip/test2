namespace DataProvider
{
    public class Underlying
    {

        public Underlying(string path, string id)
        {
            Id = id;
            Path = path;
        }

        public string Path { get; set; }
        public string Id { get; set; }
    }
}


