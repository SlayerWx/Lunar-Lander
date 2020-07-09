using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite[] fireStep;
    SpriteRenderer myRender;
    [SerializeField]
    float timeBetweenFrame;
    [SerializeField]
    float timeAnimation;
    float timer;
    float timer2;
    int index;
    void Start()
    {
        myRender = GetComponent<SpriteRenderer>();
        timer = 0;
        index = 0;
        myRender.sprite = fireStep[index];
    }
    public bool Animation()
    {
       myRender.enabled = true;

       timer += Time.deltaTime;
       if(timer>timeBetweenFrame)
       {
           timer2 += timer;
           timer = 0;
           index++;
           if(index>=fireStep.Length) index = 0;
           myRender.sprite = fireStep[index];
           if(timer2 >timeAnimation)
           {
               myRender.sprite = fireStep[0];
               index = 0;
               timer2 = 0;
               myRender.enabled = false;
               return true;
           }
       }
    
        return false;
    }
}
