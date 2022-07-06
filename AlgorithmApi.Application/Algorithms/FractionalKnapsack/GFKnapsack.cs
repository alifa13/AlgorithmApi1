using AlgorithmApi.Application.DataStructures.Stuff;

namespace AlgorithmApi.Application.Algorithms.FractionalKnapsack
{
    public class GFKnapsack
    {
        public double GetPriceGFK(List<Stuff> stuffs , int weightBound)
        {
            double price = 0;
            int b = weightBound;
            int i = 0;
            for (i = 0; i < stuffs.Count; i++)
            {
                if (stuffs[i].Weight < b)
                {
                    b -= stuffs[i].Weight;
                    price += stuffs[i].Price;
                }
                else
                    break;
            }

            if(i < stuffs.Count)
            {
                price += ((double)b/stuffs[i].Weight) * stuffs[i].Price;
            }

            return price;
        }
    }
}
