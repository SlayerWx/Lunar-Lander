using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCollision : MonoBehaviour
{
    [SerializeField]
    bool imVictoryCollision = false;
    // Start is called before the first frame update asAS
    private static float minVel= 0.04f;
    private static float minRotate = 7.0f;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerStatus w = col.gameObject.GetComponent<PlayerStatus>();
            Vector2 velP = col.gameObject.GetComponent<Move>().GetVelocity();
            if (imVictoryCollision && Mathf.Abs(velP.x) < minVel && Mathf.Abs(velP.y) < minVel && Mathf.Abs(col.transform.rotation.eulerAngles.z) < minRotate)
            {
                w.SetSafeLanding(true);
            }
            else
            {
                w.SetAlive(false);
                w.SetSafeLanding(false);
            }
        }
    }
}
