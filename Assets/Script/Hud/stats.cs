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
    [SerializeField]
    private Altitude alt;
    [SerializeField]
    TimeOnLevel timer;
    // Start is called before the first frame update
    void Start()
    {
        time.text = "Time 0:00"; 
        points.text = "Points";
        gasoline.text = "Gasoline ??";
        altitude.text = "altitude ??";
        verticalVel.text = "Vertical Vel";
        horizontalVel.text = "Horizontal Vel";
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.GetSeconds() > 9) time.text = "Time " + timer.getMinutes() + ":" + timer.GetSeconds();
        else time.text = "Time " + timer.getMinutes() + ":0" + timer.GetSeconds();
        gasoline.text = "Gasoline " + playerMove.getGasoline();
        if ((int)(playerRigid.velocity.y * 10) > 0) verticalVel.text = "Vertical vel " + (int)Mathf.Abs(playerRigid.velocity.y * 10) + " Up";
        else if ((int)(playerRigid.velocity.y * 10) < 0) verticalVel.text = "Vertical vel " + (int)Mathf.Abs(playerRigid.velocity.y * 10) + " Down";
        else verticalVel.text = "Vertical vel " + (int)Mathf.Abs(playerRigid.velocity.y * 10);
        if ((int)(playerRigid.velocity.x * 10) < 0) horizontalVel.text = "Horizontal vel " + (int)Mathf.Abs(playerRigid.velocity.x * 10) + " Left";
        else if ((int)(playerRigid.velocity.x * 10) > 0) horizontalVel.text = "Horizontal vel " + (int)Mathf.Abs(playerRigid.velocity.x * 10) + " Right";
        else horizontalVel.text = "Horizontal vel " + (int)Mathf.Abs(playerRigid.velocity.x * 10);
        altitude.text = "Altitude " + (int)alt.GetAltitude() + "KM";
    }
}
//asAS