using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public abstract class Observer<OData> : SingleMonoBehaviour<Observer<OData>>
{
    public delegate void CallBackObserver(OData data);
    
    Dictionary<string, HashSet<CallBackObserver>> dictObserver = new Dictionary<string, HashSet<CallBackObserver>>();
    // Use this for initialization
    public void AddObserver<Odata>(string topicName, CallBackObserver callbackObserver)
    {
        HashSet<CallBackObserver> listObserver = CreateListObserverForTopic(topicName);
        listObserver.Add(callbackObserver);
    }

    public void RemoveObserver<Odata>(string topicName, CallBackObserver callbackObserver)
    {
        HashSet<CallBackObserver> listObserver = CreateListObserverForTopic(topicName);
        listObserver.Remove(callbackObserver);
    }

    public void Notify(string topicName, OData Data)
    {
        HashSet<CallBackObserver> listObserver = CreateListObserverForTopic(topicName);
        foreach (CallBackObserver observer in listObserver)
        {
            observer(Data);
        }
    }

    protected HashSet<CallBackObserver> CreateListObserverForTopic(string topicName)
    {
        if (!dictObserver.ContainsKey(topicName))
            dictObserver.Add(topicName, new HashSet<CallBackObserver>());
        return dictObserver[topicName];
    }
}
