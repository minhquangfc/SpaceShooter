using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public abstract class BehaviourController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    protected float durationmove = 0.2f;
    //Action<id> _callBack;
    //callBack _callBack;
    void Start()
    {
        //_callBack = Test;
        //_callBack(id);
    }
    private void Test(int a)
    {
        Debug.Log(a);
    }
    private LeanTweenType typemove = LeanTweenType.linear;
    int id;
    protected void MoveTo(Vector3 EndPoint,Action onComplete=null)
    {
        LeanTween.moveLocal(this.gameObject, EndPoint, durationmove).setEase(typemove).setOnComplete(onComplete);
    }

    // Update is called once per frame
    protected void MoveUpdate(Vector3 EndPoint)
    {
        LeanTween.cancel(id);
        id = LeanTween.moveLocal(gameObject, EndPoint, durationmove).setEase(typemove).id;
    }
    protected void UpdateValue(Color from,Color to,Action<Color> updateValueExampleCallback = null)
    {
        LeanTween.value(gameObject, from, to, durationmove).setEase(LeanTweenType.easeInElastic).setOnUpdate(updateValueExampleCallback);
    }
    protected void UpdateValue(float from, float to, Action<float> updateValueExampleCallback = null, Action onComplete = null)
    {
        LeanTween.value(gameObject, from, to, durationmove).setEase(typemove).setOnUpdate(updateValueExampleCallback).setOnComplete(onComplete);
    }
    protected void Checkvacham()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position,Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log("Va cham");
            OnCollection(hit.collider);
        }
        
    }
    protected virtual void OnCollection(Collider2D collider)
    {

    }
    
   
}
