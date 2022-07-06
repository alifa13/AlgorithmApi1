using AlgorithmApi.Application.DataStructures.Matrix.Interfaces;

namespace AlgorithmApi.Application.DataStructures.Matrix.Implementations
{
    public class MatrixOperators : IMatrixOperators
    {
        public Matrix<string> ConquerMatrices(List<Matrix<string>> mat)
        {
            Matrix<string> res = new Matrix<string>();
            res.MatrixTable = new List<List<string>>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(i==0 || i==1)
                        res.MatrixTable.Add(new List<string> { mat[0].MatrixTable[i][0] , mat[0].MatrixTable[i][1] , mat[1].MatrixTable[i][0] , mat[1].MatrixTable[i][1] });
                    if(i== 2 || i == 3)
                        res.MatrixTable.Add(new List<string> { mat[2].MatrixTable[i][0], mat[2].MatrixTable[i][1], mat[3].MatrixTable[i][0], mat[3].MatrixTable[i][1] });
                }
            }

            return res;
        }

        public Matrix<string> decodeStringToMatrix(string strMat)
        {

            var rowsMat = strMat.Split('|');
            var mat1 = new Matrix<string>();
            mat1.MatrixTable = new List<List<string>>();

            foreach (var item in rowsMat)
            {
                var rowElements = item.Split('-');
                mat1.MatrixTable.Add(rowElements.ToList());
            }

            return mat1;
        }

        public Matrix<string> mul(Matrix<string> mat1, Matrix<string> mat2)
        {
            int countRowsMat1 = mat1.MatrixTable.Count;
            Matrix<string> result = new Matrix<string>();
            List<string> rowResult = new List<string>();
            int resultElement = 0;

            for (int i = 0; i < countRowsMat1; i++)
            {
                for (int j = 0; j < countRowsMat1; j++)
                {
                    for (int k = 0; k < countRowsMat1; k++)
                    {
                        resultElement += Int32.Parse(mat1.MatrixTable[i][k]) * Int32.Parse(mat2.MatrixTable[k][j]);
                    }
                    rowResult.Add(resultElement.ToString());
                }
                result.MatrixTable.Add(rowResult);
            }

            return result;
        }

        public List<Matrix<string>> partitionMatrixIntoFourSubMatrix(Matrix<string> mat)
        {
            List<Matrix<string>> subMatrices = new List<Matrix<string>>();
            var subMat1 = new Matrix<string>();
            var subMat2 = new Matrix<string>();
            subMat1.MatrixTable = new List<List<string>>();
            subMat2.MatrixTable = new List<List<string>>();
            List<string> rowSubMat = new List<string>();

            for (int i = 0; i < mat.MatrixTable.Count; i++)
            {
                for (int j = 0; j < mat.MatrixTable.Count; j++)
                {
                    rowSubMat.Add(mat.MatrixTable[i][j]);
                }
                subMat1.MatrixTable.Add(rowSubMat.GetRange(0, 2));
                subMat2.MatrixTable.Add(rowSubMat.GetRange(2, 2));
                if(i==1 || i==3)
                {
                    subMatrices.Add(subMat1);
                    subMatrices.Add(subMat2);
                    subMat1.MatrixTable.Clear();
                    subMat2.MatrixTable.Clear();
                }
            }

            return subMatrices;
        }

        public Matrix<string> Sub(Matrix<string> mat1, Matrix<string> mat2)
        {
            Matrix<string> result = new Matrix<string>();
            List<string> rowResult = new List<string>();

            for (int i = 0; i < mat1.MatrixTable.Count; i++)
            {
                for (int j = 0; j < mat1.MatrixTable.Count; j++)
                {
                    rowResult.Add((Int32.Parse(mat1.MatrixTable[i][j]) - Int32.Parse(mat2.MatrixTable[i][j])).ToString());
                }
                result.MatrixTable.Add(rowResult);
            }

            return result;
        }

        public Matrix<string> sum(Matrix<string> mat1, Matrix<string> mat2)
        {
            Matrix<string> result = new Matrix<string>();
            List<string> rowResult = new List<string>();

            for (int i = 0; i < mat1.MatrixTable.Count; i++)
            {
                for (int j = 0; j < mat1.MatrixTable.Count; j++)
                {
                    rowResult.Add((Int32.Parse(mat1.MatrixTable[i][j]) + Int32.Parse(mat2.MatrixTable[i][j])).ToString());
                }
                result.MatrixTable.Add(rowResult);
            }

            return result;
        }
    }
}
