namespace SpaceDonkey.Models.Omdb
{
    public class MovieModel
    {
        public MovieModel(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name { get; }
        public int Rating { get; }
    }
}