using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : BehaviourController
{
    // Start is called before the first frame update
    [SerializeField]
    private PlaneController _Own;
    void Start()
    {
        //Vector3 EndPoint = new Vector3(
        //    this.transform.localPosition.x,
        //    this.transform.localPosition.y + 1280);
        //MoveTo(EndPoint, ()=>
        //{
        //    Destroy(this.gameObject);
        //});
    }

    // Update is called once per frame
    void Update()
    {
        Checkvacham();
    }
    public void throwBullet(PlaneController Own)
    {
        _Own = Own;
        Vector3 EndPoint = this.transform.localPosition + Own.transform.up * 1280;
        durationmove = Own.durationBulletThrow;
        MoveTo(EndPoint,  () =>
        {
            Destroy(this.gameObject);
        });
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
    protected override void OnCollection(Collider2D collider)
    {
        PlaneController plane = collider.GetComponent < PlaneController >();
        if (plane == null||plane== _Own || plane.tag == _Own.tag) return;
        plane.BeShooted(_Own);
        
    }
}
