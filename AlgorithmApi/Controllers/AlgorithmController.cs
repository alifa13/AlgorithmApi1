using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlgorithmApi.Application.Algorithms.LCS;
using AlgorithmApi.Application.Algorithms.JobScheduling;
using AlgorithmApi.Application.DataStructures.Job.Interfaces;
using AlgorithmApi.Application.Algorithms.DFS;
using AlgorithmApi.Application.DataStructures.Matrix.Interfaces;
using AlgorithmApi.Application.DataStructures.Graph.Interfaces;
using AlgorithmApi.Application.Algorithms._01Knapsack_Backtrack;
using AlgorithmApi.Application.DataStructures.Stuff.Interfaces;
using AlgorithmApi.Application.Algorithms.BB_01Knapsack;
using AlgorithmApi.Application.Algorithms.FractionalKnapsack;
using AlgorithmApi.Application.DataStructures.Matrix;
using AlgorithmApi.Application.Algorithms.Strassen;

namespace AlgorithmApi.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmController : ControllerBase
    {
        private IJobOperations _jobOperations;
        private IMatrixOperators _matrixOperators;
        private IGraphOperators _graphOperators;
        private IStuffOperators _stuffOperators;
        private GFKnapsack _gFKnapsack;

        public AlgorithmController(IJobOperations jobOperations, IMatrixOperators matrixOperators, IGraphOperators graphOperators, IStuffOperators stuffOperators , GFKnapsack gFKnapsack)
        {
            _jobOperations = jobOperations;
            _matrixOperators = matrixOperators;
            _graphOperators = graphOperators;
            _stuffOperators = stuffOperators;
            _gFKnapsack = gFKnapsack;
            int a = 5;
            int b = 6;
            int c = 7;
            int d = 8;
            int t = 9;
            int h = 10;
            int y = 11;
        }

        [HttpGet]
        [Route("LCS/{strA}/{strB}")]
        public string LCS(string strA, string strB)
        {
            LCSAlgorithm lCSAlgorithm = new LCSAlgorithm(strA, strB);
            return lCSAlgorithm.printLCS();
        }

        [HttpGet]
        [Route("job/{strJobs}")]
        public IActionResult JobSchedule(string strJobs)
        {
            JobScheduling jobScheduling = new JobScheduling(strJobs, _jobOperations);
            var jobs = jobScheduling.printJobSchedule();
            var t = jobScheduling.SumJobsTime(jobs);
            string res = jobScheduling.FormatResult(jobs, t);
            JsonResult jRes = new JsonResult(res);

            return jRes;
        }

        [HttpGet]
        [Route("dfs/{graphMat}")]
        public string DFSAlgorithm(string graphMat)
        {
            var matrix = _matrixOperators.decodeStringToMatrix(graphMat);
            var graph = _graphOperators.DecodeMatrixToGraph(matrix);
            DFS dFS = new DFS(graph);
            
            return dFS.ShowGraphTraversal();
        }

        [HttpGet]
        [Route("backtrack/{strStuffs}/{weightBound}")]
        public List<bool> BTKnapsack(string strStuffs, int weightBound)
        {
            List<bool> result = new List<bool>();
            var stuffs = _stuffOperators.DecodeStringToStuffs(strStuffs);
            BacktrackKnapsack backtrack = new BacktrackKnapsack(stuffs, weightBound);
            
            return backtrack.Knapsack01(result, 1);
        }

        [HttpGet]
        [Route("branchbound/{strStuffs}/{weightBound}")]
        public List<bool> B_BKnapsack(string strStuffs , int weightBound)
        {
            List<bool> result = new List<bool>();
            var stuffs = _stuffOperators.DecodeStringToStuffs(strStuffs);
            var sortedStuffs=_stuffOperators.SortStuffs(stuffs);

            BBKnapsack branchBound = new BBKnapsack(weightBound, sortedStuffs, _gFKnapsack);
            return branchBound.BBKnapsack01(result, 0);
        }

        [HttpGet]
        [Route("strassen/{strMatA}/{strMatB}")]
        public Matrix<string> Strassen(string strMatA , string strMatB)
        {
            var matA = _matrixOperators.decodeStringToMatrix(strMatA);
            var matB = _matrixOperators.decodeStringToMatrix(strMatB);

            StrassenAlgorithm strassenAlgorithm = new StrassenAlgorithm(matA, matB, _matrixOperators);
            return strassenAlgorithm.StrassenMul();

        }
    }
}
