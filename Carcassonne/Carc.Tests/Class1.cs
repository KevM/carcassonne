using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Carc.Tests
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

    public class Graph
    {
        public Tile StartingStartingTile { get; set; }
        public Graph(Tile startingTile)
        {
            StartingStartingTile = startingTile;
        }
    }
}
