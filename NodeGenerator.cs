using System.Collections.Generic;
using System.Linq;

namespace GrandPrixApp
{
    public class NodeGenerator
    {
        public static IList<Node> GenerateNodes(string nodestring, int columns, int rows)
        {
            var rowList = Enumerable.Range(0, nodestring.Length / columns)
                .Select(i => nodestring.Substring(i * columns, columns)).ToList();

            var finalList = new List<Node>(nodestring.Length);

            for (var i = 0; i < rowList.Count(); i++)
            {
                var y = i;

                var values = rowList[i].Select((x, j) => new Node(j, y, (NodeType) x - '0'));

                finalList.AddRange(values);
            }

            return finalList;
        }
    }
}