using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class  BehavierController : MonoBehaviour
{
    [SerializeField]
    protected float durationmove = 0.2f; 
    private LeanTweenType typemove = LeanTweenType.linear;
    // Start is called before the first frame update
    int id;
    protected void MoveTo(Vector3 EndPoint,Action onComplete = null)
    {
        LeanTween.moveLocal(this.gameObject,EndPoint,durationmove).setEase(typemove).setOnComplete(onComplete);
    }

    protected void MoveUpdate(Vector3 EndPoint)
    {
        LeanTween.cancel (id);
		id = LeanTween.moveLocal (gameObject, EndPoint, durationmove).setEase(typemove).id;
    }

    protected void UpdateValue(Color from , Color to, Action<Color> updateValueExampleCallback = null)
    {
        LeanTween.value( gameObject,from, to, durationmove).setEase(LeanTweenType.easeOutElastic).setOnUpdate(updateValueExampleCallback);
    }
    protected void UpdateValue(float from , float to, Action<float> updateValueExampleCallback = null,Action onComplete = null)
    {
        LeanTween.value( gameObject,from, to, durationmove).setEase(typemove).setOnUpdate(updateValueExampleCallback).setOnComplete(onComplete);
    }

    protected void CheckCollider()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position , Vector2.zero);
        if(hit.collider != null)
        {
            OnCollection(hit.collider);
        }
    }

    protected virtual void OnCollection(Collider2D collider){}
}
