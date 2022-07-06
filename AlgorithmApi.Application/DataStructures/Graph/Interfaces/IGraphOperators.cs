using AlgorithmApi.Application.DataStructures.Matrix;

namespace AlgorithmApi.Application.DataStructures.Graph.Interfaces
{
    public interface IGraphOperators
    {
        public Graph DecodeMatrixToGraph(Matrix<string> graphMat);

    }
}
