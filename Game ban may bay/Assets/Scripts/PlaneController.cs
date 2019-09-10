using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HPController))]
public abstract class PlaneController : BehavierController
{
    [SerializeField]
    private int delayFrameToShoot = 10;

    [SerializeField]
    protected int Damage = 100;

    [SerializeField]

    protected int Defence = 50;
    public float durationBulletThrow;
    private int Framecount = 0;

    protected HPController _hpController;

    public LevelController _levelController;
    // Update is called once per frame
    private void Awake()
    {
        _hpController = GetComponent<HPController>();
        _levelController = GetComponent<LevelController>();
        _hpController.onEmptyHP += BeDestroy;
        _levelController.onLevelUp += OnLevelUp;
    }
    protected void Shoot()
    {
        if (Framecount < delayFrameToShoot)
        {
            Framecount++;
            return;
        } 
        Framecount = 0;
        CreateController.Instance.createBullet(this.transform.localPosition,this);
    }

    public void BeShooted(PlaneController oppenent)
    {
        
        float templeHP =  Defence - oppenent.Damage;
        if (templeHP > 0) templeHP*=-0.5f;
        _hpController.EditValue((int)templeHP);
    }

    public virtual void OnLevelUp(int currentlevel)
    {
       
    }

    protected abstract void BeDestroy();
    
    public void OnDestroy()
    {
        _hpController.onEmptyHP -= BeDestroy;
        _levelController.onLevelUp -= OnLevelUp;
    }
}
