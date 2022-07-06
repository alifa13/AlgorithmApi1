using AlgorithmApi.Application.DataStructures.Stuff;
using AlgorithmApi.Application.Algorithms.FractionalKnapsack;

namespace AlgorithmApi.Application.Algorithms.BB_01Knapsack
{
    public class BBKnapsack
    {
        private int _weightBound;
        private List<Stuff> _stuffs;
        private GFKnapsack _gfk;
        private int _optPrice = 0;
        private List<bool> _optItemSelection = new List<bool>();

        public BBKnapsack(int weightBound, List<Stuff> stuffs, GFKnapsack gfk)
        {
            _weightBound = weightBound;
            _stuffs = stuffs;
            _gfk = gfk;
            
        }

        public List<bool> BBKnapsack01(List<bool> lstItemSelection, int currentWeight, int level = 1)
        {
            List<bool> candidate = new List<bool>();

            if (level == _stuffs.Count + 1)
            {
                int itemSelectedWeight = 0;
                int currentPrice = 0;

                for (int i = 0; i < lstItemSelection.Count; i++)
                {
                    itemSelectedWeight += Convert.ToInt32(lstItemSelection[i]) * _stuffs[i].Weight;
                }
                if (itemSelectedWeight <= _weightBound)
                {
                    for (int i = 0; i < lstItemSelection.Count; i++)
                    {
                        currentPrice += Convert.ToInt32(lstItemSelection[i]) * _stuffs[i].Price;
                    }
                    if (currentPrice >= _optPrice)
                    {
                        _optPrice = currentPrice;
                        _optItemSelection = lstItemSelection.ToList();
                    }
                }
            }
            else
            {
                if (currentWeight + _stuffs[level - 1].Weight <= _weightBound)
                {
                    candidate.Add(true);
                    candidate.Add(false);
                }
                else
                    candidate.Add(false);

            }

            int preLPrice = 0;
            for (int j = 0; j < level - 1; j++)
            {
                preLPrice += Convert.ToInt32(lstItemSelection[j]) * _stuffs[j].Price;
            }
            double bound = preLPrice + _gfk.GetPriceGFK(_stuffs.GetRange(level - 1, _stuffs.Count - (level - 1)), _weightBound - currentWeight);
            if (bound <= _optPrice)
                return null;

            foreach (var item in candidate)
            {
                if (lstItemSelection.Count < _stuffs.Count)
                    lstItemSelection.Add(item);
                else
                    lstItemSelection[level - 1] = item;
                BBKnapsack01(lstItemSelection.ToList(), currentWeight + Convert.ToInt32(item) * _stuffs[level - 1].Weight, level + 1);
            }

            return _optItemSelection;
        }
    }
}
