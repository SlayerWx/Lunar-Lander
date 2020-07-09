using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimation : MonoBehaviour
{
    float timer;
    [SerializeField]
    float timerMx;
    // Start is called before the first frame update asAS

    // Update is called once per frame
    public bool Animation()
    {
        timer += Time.deltaTime;
        if(timer<timerMx) 
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.identity, timer / timerMx);
            return false;
        }
        timer = 0;
        return true;
    }
}
