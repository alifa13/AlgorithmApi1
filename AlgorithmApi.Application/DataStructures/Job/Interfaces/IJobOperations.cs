
namespace AlgorithmApi.Application.DataStructures.Job.Interfaces
{
    public interface IJobOperations
    {
        public List<Job> decodeStringToJobs(string jobsString);
        public List<Job> sortJobsByTime(List<Job> jobs , string order = "desc");

        public int SumJobsTime(List<int> times);
    }
}
