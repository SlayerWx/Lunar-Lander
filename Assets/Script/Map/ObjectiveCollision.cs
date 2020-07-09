using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectiveCollision : MonoBehaviour
{
    [SerializeField]
    bool imVictoryCollision = false;
    // Start is called before the first frame update asAS
    private static float minVel = 0.06f;
    private static float minRotate = 9.0f;
    int myValue = 0;
    private int pointsInSafe = 10;
    [SerializeField]
    Canvas myCn;
    int maxValueMultiplicator = 5;
    void Start()
    {
        if(imVictoryCollision)
        {
            myValue = Random.Range(1, maxValueMultiplicator);
            myCn.GetComponentInChildren<Text>().text = "X" + myValue;
        }
        else
        {
            myCn.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            PlayerStatus w = col.gameObject.GetComponent<PlayerStatus>();
            Vector2 velP = col.gameObject.GetComponent<Move>().GetVelocity();
            if (imVictoryCollision )//&& Mathf.Abs(velP.x) < minVel && Mathf.Abs(velP.y) < minVel)&& Mathf.Abs(col.transform.rotation.eulerAngles.z) < minRotate)
            {
                w.SetSafeLanding(true);
                w.SumPoints(myValue * pointsInSafe);
            }
            else
            {
                w.SetAlive(false);
                w.SetSafeLanding(false);
            }
        }
    }
}
