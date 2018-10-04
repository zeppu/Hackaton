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
                    list.Add(item);
                }
            }

            return list.ToList();
        }

        public static Vector MoveForward(this Vector vector)
        {
            return new Vector((vector.EndX, vector.EndY), (vector.EndX + vector.DiffX, vector.EndY + vector.DiffY));
        }
    }
}