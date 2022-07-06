namespace AlgorithmApi.Application.DataStructures.Matrix.Interfaces
{
    public interface IMatrixOperators
    {
        public Matrix<string> decodeStringToMatrix(string strMat);

        public Matrix<string> sum(Matrix<string> mat1, Matrix<string> mat2);

        public Matrix<string> mul(Matrix<string> mat1, Matrix<string> ma2);

        public List<Matrix<string>> partitionMatrixIntoFourSubMatrix(Matrix<string> mat);

        public Matrix<string> Sub(Matrix<string> mat1, Matrix<string> mat2);

        public Matrix<string> ConquerMatrices(List<Matrix<string>> mat);


    }
}
