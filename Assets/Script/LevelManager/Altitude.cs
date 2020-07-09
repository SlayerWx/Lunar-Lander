using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altitude : MonoBehaviour
{
    List<Transform> map;
    [SerializeField]
    MapGenerator mp;
    [SerializeField]
    Transform player;
    float result;
    // Start is called before the first frame update asAS
    void Start()
    {
        map = null;
        map = mp.GetMapSeted();

    }

    // Update is called once per frame
    void Update()
    {
        if(map!=null)AltitudeGenerator();
    }
    void AltitudeGenerator()
    {
        Transform lastSucces = null;
        foreach (Transform myTry in map)
        {
            if(lastSucces == null)
            {
                lastSucces = myTry;
            }
            else if(Vector3.Distance(player.position,myTry.position)<=Vector3.Distance(player.position,lastSucces.position))
            {
                lastSucces = myTry;
            }
          
        }
        if (lastSucces != null)
            result = Vector3.Distance(player.position, lastSucces.position);
        else result = 0;
    }
    public float GetAltitude()
    {
        return result;
    }
}
