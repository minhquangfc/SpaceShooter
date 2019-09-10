using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    int count = 0;
    int score;
    void OnGUI()
    {
        //GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 30f, 100f),"LVMQ");

        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 60;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 * 0.1f, 300f, 100f), "Score: " + GameController.Instance.score,guiStyle);
        if(GameController.Instance.score==5)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 * 0.1f, 300f, 100f), "You Win", guiStyle);
        }
        if (GameController.Instance.isLose)
        {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 * 0.1f, 300f, 100f), "You Lose", guiStyle);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
