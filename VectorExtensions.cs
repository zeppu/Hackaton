using System;
using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
    public static class VectorExtensions
    {
        public static IList<Vector> GenerateAllNextMoves(this Vector vector)
        {
            var x = vector.MoveForward();

            var list = new HashSet<Vector>();

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var item = x + (i, j);
                    item.Parent = x.Parent;

                    if (vector.End != item.End)
                    {

                        list.Add(item);
                    }
                }
            }

            return list.ToList();
        }

        public static Vector MoveForward(this Vector vector)
        {
            return new Vector((vector.EndX, vector.EndY), (vector.EndX + vector.DiffX, vector.EndY + vector.DiffY), vector);
        }

        public static bool HasRepeatedAncestor(this Vector vector, IList<Coordinate> oldPositions)
        {

            var temp = vector;
            var count = 0;
            while (++count < 40)
            {
                if (temp.Parent == null)
                    return false;

                var parentCord = temp.Parent.End;

                if (oldPositions.Any(m => parentCord == m))
                    return true;

                oldPositions.Add(parentCord);

                temp = temp.Parent;
            }

            return false;
        }
    }
}