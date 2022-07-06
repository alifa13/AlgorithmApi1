
using AlgorithmApi.Application.DataStructures.Job.Interfaces;

namespace AlgorithmApi.Application.DataStructures.Job.Implementaions
{
    public class JobOperations : IJobOperations
    {
        public List<Job> decodeStringToJobs(string jobsString)
        {
            List<string> strJobs = jobsString.Split("|").ToList();
            List<Job> jobs = new List<Job>();
            foreach (var item in strJobs)
            {
                var strJob = item.Split("-");
                
                jobs.Add(new Job {Name=strJob[0] , Time=Convert.ToInt32(strJob[1])});
            }

            return jobs;
        }

        public List<Job> sortJobsByTime(List<Job> jobs, string order = "asce")
        {
            var sortedJobs = new List<Job>();
            if (order == "desc")
            {
                sortedJobs = jobs.OrderByDescending(c => c.Time).ToList();
            }
            else if (order == "asce")
            {
                sortedJobs = jobs.OrderBy(c => c.Time).ToList();
            }

            return sortedJobs;
        }

        public int SumJobsTime(List<int> times)
        {
            int res = 0;
            for (int i = 0; i < times.Count; i++)
            {
                foreach (var item in times.GetRange(0,i+1))
                {
                    res += item;
                }
            }

            return res;
        }
    }
}
