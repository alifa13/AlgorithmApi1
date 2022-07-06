
using AlgorithmApi.Application.DataStructures.Stuff.Interfaces;

namespace AlgorithmApi.Application.DataStructures.Stuff.Implementations
{
    public class StuffOperators : IStuffOperators
    {
        public List<Stuff> DecodeStringToStuffs(string strStuffs)
        {
            List<Stuff> result = new List<Stuff>();
            List<string> stuffsString = strStuffs.Split('|').ToList();
            foreach (string stuff in stuffsString)
            {
                var strStuff = stuff.Split('-');
                result.Add(new Stuff { Price = Convert.ToInt32(strStuff[0]), Weight = Convert.ToInt32(strStuff[1]) });
            }
            return result;
        }

        public List<Stuff> SortStuffs(List<Stuff> stuffs)
        {
            return stuffs.OrderByDescending(c => (c.Price / c.Weight)).ToList();
        }
    }
}
