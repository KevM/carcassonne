namespace Carc.Tests
{
    public class Graph_Tests 
    {
        public void should_start_somewhere()
        {
            var sideFactory = new SideFactory();

            CreateGrassField(sideFactory);
        }

        public static Tile CreateGrassField(SideFactory sideFactory)
        {
            var side1Field = sideFactory.Field();
            var side2Field = sideFactory.Field();
            var side3Field = sideFactory.Field();
            var side4Field = sideFactory.Field();

            var field = new Path(Terrain.Grass, side1Field, side2Field, side3Field, side4Field);

            return new Tile(new[] {side1Field, side2Field, side3Field, side4Field});
        }

        public static Tile StartingTile(SideFactory sideFactory)
        {
            var side1Football = sideFactory.Football();
            var side2FieldRoad = sideFactory.Road();
            var side3Field = sideFactory.Field();
            var side4FieldRoad = sideFactory.Road();

            var road = new Path(Terrain.Road, side2FieldRoad, side4FieldRoad);
            var field1 = new Path(Terrain.Grass, side2FieldRoad, side4FieldRoad);
            var field2 = new Path(Terrain.Grass, side2FieldRoad, side3Field, side4FieldRoad);

            return new Tile(new[] { side1Football, side2FieldRoad, side3Field, side4FieldRoad });
        }

    }
}