using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class HPController : ProcessController
{
    public event Action onEmptyHP;
    // Start is called before the first frame update

    void Start()
    {
        img.color = new Color(0,1,0);
        currentsValue = maxValue;
        Refresh();
    }
    
    protected override void OnUpdate(float value)
    {
        base.OnUpdate(value);
        img.color = new Color(value,value/maxValue,0);
    }


    public void EditHP(int value)
    {
        maxValue += value;
        currentsValue = maxValue;
        Refresh();
    }
    protected override void OnCompleteUpdate()
    {
        if (currentsValue > 0) return;
            if (onEmptyHP != null)
                onEmptyHP();
    }
}
