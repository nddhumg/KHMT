using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeightedRandomSelector<T> 
{
    void AddItem(T item, float weight);
    void AddItems(List<T> items, List<float> weights);
    void RemoveItem(T item);
    void RemoveItemAt(int index);
    void SetRateItem(T item, float value);
    void SetRateItem(int index, float value);
    T GetRandomItem();
    void ClearItems();
}
