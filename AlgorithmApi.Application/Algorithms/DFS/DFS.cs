
using AlgorithmApi.Application.DataStructures.Graph;
using AlgorithmApi.Application.DataStructures.Graph.Enums;
using AlgorithmApi.Application.DataStructures.Matrix;

namespace AlgorithmApi.Application.Algorithms.DFS
{
    public class DFS
    {
        private Graph _graph;
        private List<int> _parents = new List<int>();
        private List<VertexColor> _colors = new List<VertexColor>();
        private List<int> _discoveryTime = new List<int>();
        private int _time = 0;
        public DFS(Graph graph)
        {
            _graph = graph;
        }

        public string ShowGraphTraversal()
        {
            string graphTraversalString = "";
            for (int i = 0; i < _graph.vertices.Count; i++)
            {
                _colors.Add(VertexColor.White);
                _parents.Add(-1);
            }

            for (int j = 0; j < _graph.vertices.Count; j++)
            {
                if (_colors[j] == VertexColor.White)
                {
                    graphTraversalString += DFSVisit(j);
                }
            }

            return graphTraversalString.Substring(0, graphTraversalString.Length - 1);
        }

        private string DFSVisit(int vertexIndex)
        {
            string traversalString = $"{vertexIndex}" + "-";
            _colors[vertexIndex] = VertexColor.Gray;
            _time += 1;
            _discoveryTime.Add(_time);
            foreach (var adj in _graph.Adjs[vertexIndex])
            {
                if (_colors[adj] == VertexColor.White)
                {
                    _parents[adj] = vertexIndex;
                    traversalString += DFSVisit(adj);
                }
            }
            _colors[vertexIndex] = VertexColor.Black;
            return traversalString;
        }
    }
}
