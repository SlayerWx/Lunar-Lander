using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float minDistance;
    [SerializeField]
    private float timeToGo;
    [SerializeField]
    Altitude alt;
    private float zoomTimer;
    private float unZoomTimer;
    [SerializeField]
    private float zoom;
    private bool done;
    private Camera myCm;
    private float startOrthographicSize;
    private bool firstTime;
    [SerializeField]
    private float velZoom;
    private playerStatus myPlayerStatus;
    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
        zoomTimer = 0;
        done = false;
        myCm = GetComponent<Camera>();
        startOrthographicSize = myCm.orthographicSize;
        firstTime = false;
        unZoomTimer = timeToGo;
        myPlayerStatus = player.GetComponent<playerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alt.GetAltitude() < minDistance)
        {
            if(firstTime)
            {
                unZoomTimer = 0;
            }
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.position.x, zoomTimer / timeToGo), 
                                             Mathf.Lerp(transform.position.y, player.position.y, zoomTimer / timeToGo),
                                             transform.position.z);
            myCm.orthographicSize = Mathf.Lerp(myCm.orthographicSize, zoom,zoomTimer/(timeToGo/ velZoom));
                zoomTimer += Time.deltaTime;
            if (zoomTimer > (timeToGo / velZoom))
                firstTime = true;
        }
        else
        {
            zoomTimer = 0;
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, startPosition.x, unZoomTimer / timeToGo),
                                             Mathf.Lerp(transform.position.y, startPosition.y, unZoomTimer / timeToGo),
                                             startPosition.z);
            myCm.orthographicSize = Mathf.Lerp(myCm.orthographicSize, startOrthographicSize, unZoomTimer / (timeToGo / velZoom));
            unZoomTimer += Time.deltaTime;
        }
    }
}
