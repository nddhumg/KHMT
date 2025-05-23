using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderGameObject : MonoBehaviour
{
    [SerializeField] private Transform slider;
    [SerializeField,Range(0,1)]private float value = 1;
    private Vector3 scaleSlider = Vector3.one;
    
    public float Value { get => value;
        set { 
            this.value = value;
            UpdateSlider();
        }
    }
    private void UpdateSlider()
    {
        scaleSlider.x = value;
        slider.localScale = scaleSlider;
    }
}
