using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : SingleMonoBehaviour<CreateController>
{
    // Start is called before the first frame update
    [SerializeField]
    private BulletController _bullet;
    [SerializeField]
    private EnemyController _enemy;
    T createObjact<T>(T Object, Vector3 position, Transform parent = null) where T : MonoBehaviour
    {
        if (parent == null) parent = this.transform;
        T _Object = Instantiate<T>(Object, position, Object.transform.rotation, parent);
        _Object.transform.localPosition = position;
        return _Object;
    } 
    public void createBullet(Vector3 position, PlaneController plane, Transform parent=null)
    {
        if (parent == null) parent = this.transform;
        BulletController bullet= createObjact(_bullet, position,parent);
        bullet.throwBullet(plane);
    }
    public EnemyController CreateEnemy(Vector3 position, Transform parent=null)
    {
        return createObjact(_enemy, position, parent);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
