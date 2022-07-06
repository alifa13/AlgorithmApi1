
using AlgorithmApi.Application.DataStructures.Job;
using AlgorithmApi.Application.DataStructures.Job.Implementaions;
using AlgorithmApi.Application.DataStructures.Job.Interfaces;

namespace AlgorithmApi.Application.Algorithms.JobScheduling
{
    public class JobScheduling
    {
        private string _strJobs;
        private IJobOperations _jobOperations;

        public JobScheduling(string strJobs , IJobOperations jobOperations)
        {
            _strJobs = strJobs;
            _jobOperations = new JobOperations();
        }

        public List<Job> printJobSchedule()
        {
            List<Job> jobs , sortedJobs = new List<Job>();
            jobs = _jobOperations.decodeStringToJobs(_strJobs);
            sortedJobs = _jobOperations.sortJobsByTime(jobs , "asce");

            return sortedJobs;
        }

        public int SumJobsTime(List<Job> jobs)
        {
            var sumTimes = _jobOperations.SumJobsTime(jobs.Select(c => c.Time).ToList());
            return sumTimes;
        }

        public string FormatResult(List<Job> jobs , int sumTimes)
        {
            string res = "";
            foreach (var item in jobs)
            {
                res += item.Name + " : " + item.Time.ToString() + " | ";
            }

            res += "----Time : " + sumTimes.ToString();

            return res;
        }
    }
}
