using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimEventSource 
{
    event System.Action<string> EventAnim;
    void Play(string name);
   
}
