using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveInMenu : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 start;
    Vector2 end;
    float time;
    [SerializeField]
    Camera myCm;
    bool direction;
    void Start()
    {
        float aux = myCm.pixelHeight/4;
        start = new Vector2(transform.position.x, aux);
        transform.position = new Vector3(start.x, start.y, transform.position.z);
        end = new Vector2(transform.position.x,myCm.pixelHeight - aux);
        direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(start,end,time);
        if (direction) time += Time.deltaTime;
        else time -= Time.deltaTime;
        if (time > 1.0f) direction = false;
        if (time < 0) direction = true;
    }
}
