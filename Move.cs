using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
    public class Move
    {
        public Coordinate End { get; set; }
        public Coordinate Start { get; set; }
        public Movement Movement { get; set; }

        public IEnumerable<Move> GetNextMoves()
        {
            var movements = KnownMovements.Values
                .Select(m => Movement.NextMove(m))
                .Where(m => m != Movement.Empty)
                .Distinct().ToList();

            return movements.Select(m => End * m);
        }

        public Move GetNextMove(int offset)
        {
            return End * Movement.NextMove(KnownMovements.Values[offset]);
        }

        public static IList<Move> operator *(Move startingMove, IEnumerable<int> offsets)
        {
            var result = new List<Move>();

            var move = startingMove;
            result.Add(move);

            foreach (var offset in offsets)
            {
                move = move.GetNextMove(offset);
                result.Add(move);
            }

            return result;
        }

        public static explicit operator Move(Coordinate startingCoordinate)
        {
            return new Move
            {
                Start = startingCoordinate,
                End = startingCoordinate,
                Movement = (-1, 0)
            };
        }
    }
}