using AlgorithmApi.Application.DataStructures.Matrix;
using AlgorithmApi.Application.DataStructures.Matrix.Implementations;
using AlgorithmApi.Application.DataStructures.Matrix.Interfaces;

namespace AlgorithmApi.Application.Algorithms.Strassen
{
    public class StrassenAlgorithm
    {
        private Matrix<string> _matA;
        private Matrix<string> _matB;
        private IMatrixOperators _matrixOperators;

        public StrassenAlgorithm(Matrix<string> matA , Matrix<string> matB , IMatrixOperators matrixOperators)
        {
            _matA = matA;
            _matB = matB;
            _matrixOperators = matrixOperators;
        }

        public Matrix<string> StrassenMul()
        {
            Matrix<string>[] variables = new Matrix<string>[7];
            Matrix<string>[] result = new Matrix<string>[4];
            

            if (_matA.MatrixTable.Count != _matB.MatrixTable[0].Count)
                return null;
            else
            {
                var subMatA = _matrixOperators.partitionMatrixIntoFourSubMatrix(_matA);
                var subMatB = _matrixOperators.partitionMatrixIntoFourSubMatrix(_matB);
                variables[0] = _matrixOperators.mul(_matrixOperators.sum(subMatA[0], subMatA[3]), _matrixOperators.sum(subMatB[0], subMatB[3]));
                variables[1] = _matrixOperators.mul(_matrixOperators.sum(subMatA[2], subMatA[3]), subMatB[0]);
                variables[2] = _matrixOperators.mul(subMatA[0] , _matrixOperators.Sub(subMatB[1],subMatB[3]));
                variables[3] = _matrixOperators.mul(subMatA[3], _matrixOperators.Sub(subMatB[2], subMatB[0]));
                variables[4] = _matrixOperators.mul(_matrixOperators.sum(subMatA[0], subMatA[1]), subMatB[3]);
                variables[5] = _matrixOperators.mul(_matrixOperators.Sub(subMatA[2], subMatA[0]), _matrixOperators.sum(subMatB[0], subMatB[1]));
                variables[6] = _matrixOperators.mul(_matrixOperators.Sub(subMatA[1], subMatA[3]), _matrixOperators.sum(subMatB[2], subMatB[3]));

                result[0] = _matrixOperators.sum(_matrixOperators.Sub(_matrixOperators.sum(variables[0], variables[3]), variables[4]), variables[6]);
                result[1] = _matrixOperators.sum(variables[2] , variables[4]);
                result[2] = _matrixOperators.sum(variables[1] , variables[3]);
                result[3] = _matrixOperators.sum(_matrixOperators.Sub(_matrixOperators.sum(variables[0], variables[2]), variables[1]), variables[5]);
            }

            return _matrixOperators.ConquerMatrices(result.ToList());
        }
    }
}
