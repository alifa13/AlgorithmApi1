using AlgorithmApi.Application.DataStructures.Matrix;

namespace AlgorithmApi.Application.Algorithms.LCS
{
    public class LCSAlgorithm
    {
        private string _inputStr1;
        private string _inputStr2;

        public LCSAlgorithm(string inputStr1 , string inputStr2)
        {
            _inputStr1 = inputStr1;
            _inputStr2 = inputStr2;
        }

        public string printLCS()
        {
            string lcs = "";
            int i = _inputStr1.Length;
            int j = _inputStr2.Length;

            Matrix<int> mat = fillLCSTable(_inputStr1 , _inputStr2);

            while (i > 0 && j > 0)
            {
                if (_inputStr1[i-1] == _inputStr2[j-1])
                {
                    lcs += _inputStr1[i-1];
                    i -= 1;
                    j -= 1;
                }
                else if (mat.MatrixTable[i-1][j] >= mat.MatrixTable[i][j-1])
                    i -= 1;
                else
                    j -= 1;

            }

            return reverseLCS(lcs);
        }

        private string reverseLCS(string lcs)
        {
            string rev = "";
            for (int i = lcs.Length-1; i > -1; i--)
            {
                rev += lcs[i];
            }

            return rev;
        }

        private Matrix<int> fillLCSTable(string strA , string strB)
        {
            Matrix<int> matrix = new Matrix<int>();
            matrix.MatrixTable = new List<List<int>>();
            var c = matrix.MatrixTable;
            int[] rowMat = new int[strB.Length + 1];

            for (int i = 0; i < strA.Length + 1; i++)
            {
                c.Add(rowMat.ToList());
                for (int j = 0; j < strB.Length + 1; j++)
                {
                    if (i == 0 || j == 0)
                        c[i][j] = 0;
                    else if (strA[i-1] == strB[j-1])
                        c[i][j] = c[i-1][j-1] + 1;
                    else if (strA[i-1] != strB[j-1])
                        c[i][j] = Math.Max(c[i][j - 1], c[i - 1][j]);
                }
               
            }

            return matrix;

        }
       
    }
}
