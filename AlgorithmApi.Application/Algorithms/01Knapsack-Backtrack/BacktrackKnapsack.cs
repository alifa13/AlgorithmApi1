using AlgorithmApi.Application.DataStructures.Stuff;
namespace AlgorithmApi.Application.Algorithms._01Knapsack_Backtrack
{
    public class BacktrackKnapsack
    {
        private List<Stuff> _stuffs;
        private int _weightBound;
        private int _optPrice = 0;
        private List<bool> _optItemSelection = new List<bool>();

        public BacktrackKnapsack(List<Stuff> stuffs , int weightBound)
        {
            _stuffs = stuffs;
            _weightBound = weightBound;
        }

        public List<bool> Knapsack01(List<bool> lstItemSelection , int level)
        {
            if (level == _stuffs.Count + 1)
            {
                int itemSelectionWeight = 0;
                int currentPrice = 0;
                for (int i = 0; i < lstItemSelection.Count; i++)
                {
                    itemSelectionWeight += Convert.ToInt32(lstItemSelection[i]) * _stuffs[i].Weight;
                }
                if(itemSelectionWeight <= _weightBound)
                {
                    for (int i = 0; i < lstItemSelection.Count; i++)
                    {
                        currentPrice += Convert.ToInt32(lstItemSelection[i]) * _stuffs[i].Price;
                    }
                    if(currentPrice >= _optPrice)
                    {
                        _optPrice = currentPrice;
                        _optItemSelection = lstItemSelection.ToList();
                    }
                }
            }
            else
            {
                if (lstItemSelection.Count < _stuffs.Count)
                    lstItemSelection.Add(true);
                else
                    lstItemSelection[level - 1] = true;
                Knapsack01(lstItemSelection , level + 1);

                lstItemSelection[level - 1] = false;
                Knapsack01(lstItemSelection, level + 1);
            }

            return _optItemSelection;
        }

    }
}
