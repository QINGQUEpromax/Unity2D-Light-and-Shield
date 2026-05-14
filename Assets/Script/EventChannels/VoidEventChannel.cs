using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/EventChannels/VoidEventChannel",fileName = "VoidEventChannel")]
public class VoidEventChannel : ScriptableObject
{ 
    event System.Action Delegate;
    public void Broadcast()
    {
        Delegate?.Invoke();
    }

    public void Addlistener(System.Action action)
    {
        Delegate += action;
    }

    public void Removelistener(System.Action action)
    {
        Delegate -= action;
    }
}
