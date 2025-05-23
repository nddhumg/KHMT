using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ndd.Random
{
    public class ChanceSelectorRandom<T> : IRandomSelector<T> where T : class
    {
        private List<T> items = new();
        private List<float> weights = new();
        private float totalMax;
        private float totalWeight = 0;

        public ChanceSelectorRandom(float totalMax = 1)
        {
            this.totalMax = totalMax;
        }

        public float TotalWeight => totalWeight;

        public void AddItem(T item, float weight)
        {
            if (totalWeight + weight > totalMax)
            {
                Debug.LogWarning("Total weight exceeds max allowed.");
                return;
            }
            items.Add(item);
            weights.Add(weight);
            totalWeight += weight;
        }

        public void AddItems(List<T> newItems, List<float> newWeights)
        {
            if (newItems.Count != newWeights.Count)
            {
                Debug.LogWarning("Items and weights count mismatch.");
                return;
            }

            float sumNewWeights = 0;
            foreach (var w in newWeights) sumNewWeights += w;

            if (totalWeight + sumNewWeights > totalMax)
            {
                Debug.LogWarning("Total weight exceeds max allowed.");
                return;
            }

            items.AddRange(newItems);
            weights.AddRange(newWeights);
            totalWeight += sumNewWeights;
        }

        public void ClearItems()
        {
            items.Clear();
            weights.Clear();
            totalWeight = 0;
        }

        public T GetRandomItem()
        {
            if (items.Count == 0) { 

                return null;
            }

            float randomValue = UnityEngine.Random.Range(0, totalMax);

            if (randomValue > totalWeight)
            {
                return null;
            }

            float cumulativeWeight = 0;
            for (int i = 0; i < items.Count; i++)
            {
                cumulativeWeight += weights[i];
                if (randomValue <= cumulativeWeight)
                {
                    return items[i];
                }
            }

            return null; 
        }

        public bool TryGetRandomItem(out T item)
        {
            item = GetRandomItem();
            return item != null;
        }

        public void RemoveItem(T item)
        {
            int index = items.IndexOf(item);
            if (index >= 0)
            {
                totalWeight -= weights[index];
                items.RemoveAt(index);
                weights.RemoveAt(index);
            }
            else
            {
                Debug.LogWarning("Item not found in the list.");
            }
        }

        public void RemoveItemAt(int index)
        {
            if (index < 0 || index >= items.Count)
            {
                Debug.LogWarning("Index out of range.");
                return;
            }
            totalWeight -= weights[index];
            items.RemoveAt(index);
            weights.RemoveAt(index);
        }

        public void SetRateItem(T item, float value)
        {
            int index = items.IndexOf(item);
            if (index >= 0)
            {
                float newTotalWeight = totalWeight - weights[index] + value;
                if (newTotalWeight > totalMax)
                {
                    Debug.LogWarning("Total weight exceeds max allowed.");
                    return;
                }

                totalWeight = newTotalWeight;
                weights[index] = value;
            }
            else
            {
                Debug.LogWarning("Item not found in the list.");
            }
        }

        public void SetRateItem(int index, float value)
        {
            if (index < 0 || index >= items.Count)
            {
                Debug.LogWarning("Index out of range.");
                return;
            }

            float newTotalWeight = totalWeight - weights[index] + value;
            if (newTotalWeight > totalMax)
            {
                Debug.LogWarning("Total weight exceeds max allowed.");
                return;
            }

            totalWeight = newTotalWeight;
            weights[index] = value;
        }
    }

}
