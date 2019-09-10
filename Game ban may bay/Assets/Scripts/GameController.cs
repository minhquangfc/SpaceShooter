using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingleMonoBehaviour<GameController>
{
    // Start is called before the first frame update
    //[SerializeField]
    //private int delayFrameToShoot = 5;
    //[SerializeField]
    public int score = 0;
    private int Framecount = 0;
    public bool isLose = false;
    void Awake()
    {
        PlaneObserver.Instance.AddObserver<GameData>(TOPICNAME.EnemeyDestroy, AddScore);
    }
    void Start()
    {
        //for(int i=0;i<5;i++)

        //WayController.Instance.CreateEnemy(new Vector3(0, 0, 0));
        WayController.Instance.createWave(0);
    }
    void AddScore(GameData gameData)
    {
        score++;
    }
    // Update is called once per frame
    void Update()
    {
        int x = Random.Range(-332, 332);
        int y = Random.Range(667, 1000);
        Vector3 positon = new Vector3(x, y, 0);
        //if (Framecount < delayFrameToShoot)
        //{
        //    Framecount++;
        //    return;
        //}
        //Framecount = 0;
        CreateController.Instance.CreateEnemy(positon);
    }
}
