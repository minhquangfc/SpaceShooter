using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlaneController
{
    void Start()
    {
        PlaneObserver.Instance.AddObserver<GameData>(TOPICNAME.EnemeyDestroy,OnDestroEnemy);
    }
    void Update() {
        Vector3 EndPoint = new Vector3(
            Input.mousePosition.x - Screen.width/2,
            Input.mousePosition.y - Screen.height/2
        );
        MoveUpdate(EndPoint);
        Shoot();
    }

    void OnDestroEnemy(GameData gameData)
    {
        _levelController.EditValue(100);
    }

    public override void OnLevelUp(int currentlevel)
    {
        Damage += 10*currentlevel;
        Defence += 10+currentlevel;
        _hpController.EditHP(10*currentlevel);
    }


    protected override void OnCollection(Collider2D collider)
    {

    }



    protected override void BeDestroy()
    {
        GameController.Instance.isLose = true;
        Destroy(this.gameObject);
    }
}
