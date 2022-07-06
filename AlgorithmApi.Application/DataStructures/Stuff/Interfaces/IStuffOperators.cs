namespace AlgorithmApi.Application.DataStructures.Stuff.Interfaces
{
    public interface IStuffOperators
    {
        public List<Stuff> SortStuffs(List<Stuff> stuffs);
        public List<Stuff> DecodeStringToStuffs(string strStuffs);
    }
}
