using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class LevelController : ProcessController
{
    // Start is called before the first frame update
    int level = 1;
    [SerializeField]
    private Text txtLevel;
    
    public event Action<int> onLevelUp;
    void Start()
    {
        if (img != null)
            img.color = new Color(0, 0, 1);
        currentsValue = 0;
        OnUpdate(currentsValue);
    }
    public void SetLevel(int _level)
    {
        level = _level;
        //maxValue += 100;
        //EditValue(currentsValue);
        txtLevel.text = "Lv." + Convert.ToString(level);
        if (onLevelUp != null) onLevelUp(level);
    }
    protected override void OnCompleteUpdate()
    {
        if(currentsValue>=maxValue)
        {
            //currentsValue = 0;
            level++;
            maxValue += 100;
            EditValue(currentsValue);
            txtLevel.text = "Lv." + Convert.ToString(level);
            if (onLevelUp != null) onLevelUp(level);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
