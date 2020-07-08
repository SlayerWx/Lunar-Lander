using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stats : MonoBehaviour // asAS
{
    [SerializeField]
    private Text time;
    [SerializeField]
    private Text points;
    [SerializeField]
    private Text gasoline;
    [SerializeField]
    private Text altitude;
    [SerializeField]
    private Text verticalVel;
    [SerializeField]
    private Text horizontalVel;
    [SerializeField]
    private Rigidbody2D playerRigid;
    [SerializeField]
    private move playerMove;
    private float timerS;
    private int timerM;
    [SerializeField]
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        time.text = "Time 0:00";
        timerS = 0.0f;
        timerM = 0;
        points.text = "Points";
        gasoline.text = "Gasoline ??";
        altitude.text = "altitude ??";
        verticalVel.text = "Vertical Vel";
        horizontalVel.text = "Horizontal Vel";
    }

    // Update is called once per frame
    void Update()
    {
        timerS += Time.deltaTime;
        if(timerS >60)
        {
            timerS = 0;
            timerM++;
        }
        time.text = "Time " + timerM + ":"+ (int)timerS;
        gasoline.text = "Gasoline " + playerMove.getGasoline();
        verticalVel.text = "Vertical Vel " + (int)(playerRigid.velocity.y*10);
        horizontalVel.text = "Horizontal vel " + (int)(playerRigid.velocity.x*10);
        altitude.text = "Altitude " + (int)(Mathf.Abs(playerMove.transform.position.y) + Mathf.Abs(tr.position.y));
    }
}
