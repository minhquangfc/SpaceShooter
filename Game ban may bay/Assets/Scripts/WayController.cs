using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WaveInfo
{
    public int enemyLevel;
    public int numberenemy;
}
public class WayController : SingleMonoBehaviour<WayController>
{
    // Start is called before the first frame update
    public int currentEnemyCount;
    [SerializeField]
    private WaveInfo[] wayArr;
    private int currentindex = 0;
    void Start()
    {
        PlaneObserver.Instance.AddObserver<GameData>(TOPICNAME.EnemeyDestroy, OnEnemyDestroy);
    }

    void OnEnemyDestroy(GameData gameData)
    {
        currentEnemyCount--;
        if(currentEnemyCount<=0)
        {
            createWave(currentindex + 1);
        }
    }
    public void createWave(int index)
    {
        if (index == wayArr.Length) return;
        currentindex = index;
        WaveInfo wayInfo = wayArr[index];
        currentEnemyCount = wayInfo.numberenemy;
        for (int i = 0; i < wayInfo.numberenemy; i++)
        {
            EnemyController enemy = CreateController.Instance.CreateEnemy(new Vector3(1, 0, 0));
            enemy.SetlevelEnemy(wayInfo.enemyLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
