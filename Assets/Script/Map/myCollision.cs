using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCollision : MonoBehaviour
{
    [SerializeField]
    bool imVictoryCollision;
    // Start is called before the first frame update
    void Start()
    {
        imVictoryCollision = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(imVictoryCollision)
            {

            }
            else
            {

            }
        }
    }
}
