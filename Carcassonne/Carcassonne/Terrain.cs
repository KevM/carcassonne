namespace Carcassonne
{
    public class Terrain
    {
        public string Kind { get; set; }

        private Terrain(string kind)
        {
            Kind = kind;
        }

        public static Terrain City = new Terrain("city");
        public static Terrain Grass = new Terrain("city");
        public static Terrain Road = new Terrain("city");
        public static Terrain River = new Terrain("city");
    }
}