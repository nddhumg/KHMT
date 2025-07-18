using System;
using System.Collections.Generic;
using UnityEngine;

namespace Ndd.Random
{
    /// <summary>
    /// A generic random selector that chooses an item based on weighted chances.
    /// Each item has a fixed weight, and the probability of selection is proportional to its weight divided by the total weight (totalWeight).
    /// 
    /// Features:
    /// - Add single or multiple items with their corresponding weights.
    /// - Get a random item based on weighted probability.
    /// - Update or remove items and their weights dynamically.
    /// - Handles edge cases such as null items or invalid weights with warnings.
    /// </summary>
    public class GuaranteedSelectorRandom<T> : IRandomSelector<T> where T : class
    {
        private List<float> weights = new();
        private List<T> items = new();
        private float totalWeight;

        public int CountItem => items.Count;

        public float TotalWeight => totalWeight;

        public void AddItem(T item, float weight)
        {
            if (item == null)
            {
                Debug.LogWarning("Item cannot be null.");
                return;
            }

            if (weight <= 0)
            {
                Debug.LogWarning("Weight must be greater than 0.");
                return;
            }

            totalWeight += weight;
            weights.Add(weight);
            items.Add(item);
        }

        public void AddItems(List<T> items, List<float> weights)
        {
            if (items == null || weights == null)
            {
                Debug.LogWarning("Items or weights cannot be null.");
                return;
            }

            if (items.Count != weights.Count)
            {
                Debug.LogWarning("The number of items must match the number of weights.");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                T item = items[i];
                float weight = weights[i];

                if (item == null)
                {
                    Debug.LogWarning($"Item at index {i} is null. Skipping.");
                    continue;
                }

                if (weight <= 0)
                {
                    Debug.LogWarning($"Weight at index {i} must be greater than 0. Skipping.");
                    continue;
                }

                this.items.Add(item);
                this.weights.Add(weight);
                totalWeight += weight;
            }
        }
        public T GetRandomItem()
        {
            if (items.Count == 0)
            {
                Debug.LogWarning("No items available.");
                return default(T);
            }

            float randomValue = UnityEngine.Random.Range(0, totalWeight);
            float accumulatedWeight = 0;
            for (int i = 0; i < weights.Count; i++)
            {
                accumulatedWeight += weights[i];
                if (randomValue <= accumulatedWeight)
                    return items[i];
            }

            Debug.LogError("Random selection failed.");
            return default(T);
        }

        public void ClearItems()
        {
            weights.Clear();
            items.Clear();
            totalWeight = 0;
        }

        public void RemoveItem(T itemRemove)
        {
            int index = FindIndexItem(itemRemove);
            RemoveItemAt(index);
        }

        public void SetRateItem(T item, float value)
        {
            int index = FindIndexItem(item);
            SetRateItem(index, value);
        }

        public void SetRateItem(int index, float value)
        {
            weights[index] = value;
        }

        protected int FindIndexItem(T itemFind)
        {
            int index = 0;
            foreach (T item in items)
            {
                if (item == itemFind)
                {
                    return index;
                }
                index++;
            }
            Debug.LogWarning("Item not found");
            return -1;
        }

        public void RemoveItemAt(int index)
        {
            weights.RemoveAt(index);
            items.RemoveAt(index);
        }

    }

}