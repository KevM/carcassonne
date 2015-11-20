using System;
using System.Collections.Generic;
using System.Linq;

namespace Carcassonne
{
    public class Path
    {
        private readonly List<Side> _sides = new List<Side>();

        public Side[] Sides => _sides.ToArray();
        public Terrain Terrain { get; set; }
        public bool IsTerminated => !Sides.Any();

        public Path(Terrain terrain, params Side[] sides)
        {
            Terrain = terrain;
            foreach (var side in sides)
            {
                side.AddPath(this);
            }
            _sides.AddRange(sides);
        }
    }

    public class Side
    {
        // TODO make equitable 

        private readonly List<Path> _paths = new List<Path>();
        public Path[] Paths => _paths.ToArray();
        public Terrain Terrain { get; set; }
        public Guid Id { get; }
        public Tile FacingTile;

        public Side(Terrain terrain)
        {
            Terrain = terrain;
            Id = Guid.NewGuid();
            FacingTile = null;
        }

        public bool ValidatePotentialFacingTile(Tile tile)
        {
            throw new NotImplementedException("oh no!");
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }
    }

    public class Tile
    {
        public Side[] Sides { get; set; }
        public Feature[]  Features { get; set; }
        public Guid Id => Guid.NewGuid();

        public Tile(Side[] sides)
        {
            if (sides.Length != 4)
            {
                throw new ArgumentException("4 sides are required for a tile.", nameof(sides));
            }

            Sides = sides;
            Features = new Feature[0];
        }
    }
}
