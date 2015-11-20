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

            var path = new Path(Terrain.Grass);
            path.AddSides(side1Field, side2Field, side3Field, side4Field);

            side1Field.CreatePaths(Terrain.Grass, side2Field, side3Field, side4Field);
            side2Field.CreatePaths(Terrain.Grass, side1Field, side3Field, side4Field);
            side3Field.CreatePaths(Terrain.Grass, side1Field, side2Field, side4Field);
            side4Field.CreatePaths(Terrain.Grass, side1Field, side2Field, side3Field);

            return new Tile(new[] {side1Field, side2Field, side3Field, side4Field});
        }
        public static Tile StartingTile(SideFactory sideFactory)
        {
            var side1Football = sideFactory.Football();
            var side2FieldRoad = sideFactory.Road();
            var side3Field = sideFactory.Field();
            var side4FieldRoad = sideFactory.Road();

            side2FieldRoad.CreatePaths(Terrain.Road, side4FieldRoad);
            side4FieldRoad.CreatePaths(Terrain.Road, side2FieldRoad);

            side2FieldRoad.CreatePaths(Terrain.Grass, side4FieldRoad);
            side4FieldRoad.CreatePaths(Terrain.Grass, side2FieldRoad);

            side3Field.CreatePaths(Terrain.Grass, side1Football, side2FieldRoad, side4FieldRoad);
            side4FieldRoad.CreatePaths(Terrain.Grass, side1Football, side2FieldRoad, side3Field);

            return new Tile(new[] { side1Football, side2FieldRoad, side3Field, side4FieldRoad });
        }

    }
}