namespace Carcassonne
{
    public class SideFactory
    {
        public Side Football()
        {
            var side = new Side(Terrain.City);
            var football = new Path(Terrain.City, side);
            return side;
        }
        public Side Field()
        {
            return new Side(Terrain.Grass);
        }
        public Side Road()
        {
            return new Side(Terrain.Road);
        }
    }
}