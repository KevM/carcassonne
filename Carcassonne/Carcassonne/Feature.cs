namespace Carcassonne
{
    public class Feature
    {
        public string Kind { get; set; }

        private Feature(string kind)
        {
            Kind = kind;
        }

        public static Feature Cloister = new Feature("cloister");
        public static Feature Inn = new Feature("inn");
        public static Feature Cathedral = new Feature("cathedral");
    }
}