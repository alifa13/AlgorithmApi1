using AlgorithmApi.Application.DataStructures.Graph.Interfaces;
using AlgorithmApi.Application.DataStructures.Matrix;

namespace AlgorithmApi.Application.DataStructures.Graph.Implementations
{
    public class GraphOperators : IGraphOperators
    {
        public Graph DecodeMatrixToGraph(Matrix<string> graphMat)
        {
            Graph graph = new Graph();
            graph.vertices = new List<int>();
            graph.Adjs = new List<List<int>>();
            List<int> adjs = new List<int>();
             
            for (int i = 0; i < graphMat.MatrixTable.Count; i++)
            {
                var row = graphMat.MatrixTable[i];
                graph.vertices.Add(i);
                for (int j = 0; j <row.Count ; j++)
                {
                    if(row[j] == "1")
                        adjs.Add(j);
                }
                
                graph.Adjs.Add(adjs.ToList());
                adjs.Clear();
            }

            return graph;
        }
    }
}
