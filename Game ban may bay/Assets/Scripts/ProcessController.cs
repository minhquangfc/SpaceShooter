using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; public class ProcessController : BehaviourController


{
    // Start is called before the first frame update
    [SerializeField]
    protected int maxValue;
    [SerializeField]
    protected int currentsValue;
    [SerializeField]
    protected Image img;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EditValue(int value)
    {
        int previousValue = currentsValue;
        currentsValue += value;
        Debug.Log(currentsValue);
        if(currentsValue<=0)
        {
            currentsValue = 0;
        };
        if (currentsValue > maxValue) currentsValue = maxValue;
        //Debug.Log((float)currentsValue/maxValue);
        UpdateValue(previousValue, currentsValue, OnUpdate, OnCompleteUpdate);
    }
    protected void Refresh()
    {
        EditValue(currentsValue);
    }
    protected virtual void OnUpdate(float value)
    {
        if (img != null)
            img.fillAmount = (float)value / maxValue;
    }
    protected virtual void OnCompleteUpdate()
    {

    }
    
}
