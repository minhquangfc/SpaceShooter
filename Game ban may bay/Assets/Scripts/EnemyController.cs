using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlaneController
{
    // Start is called before the first frame update
    void Start()
    {
       EnemyMove();
    }

    void EnemyMove()
    {
         Vector3 endpoint = new Vector3( Random.Range(-360,360),Random.Range(-640,640) );
        MoveTo(endpoint,EnemyMove); 
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
       
    }
    public void SetlevelEnemy(int level)
    {
        _levelController.SetLevel(level);
    }
    public override void OnLevelUp(int currentlevel)
    {
        Damage += 5*currentlevel;
        Defence += 5+currentlevel;
        _hpController.EditHP(5*currentlevel);
    }

    protected override void BeDestroy()
    {
        PlaneObserver.Instance.Notify(TOPICNAME.EnemeyDestroy,null);
        Destroy(this.gameObject);
    }
}
