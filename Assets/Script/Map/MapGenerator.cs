using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] map;
    int col;
    float distance = 0.5f;
    float start;
    float end;
    [SerializeField]
    Camera myCm;
    GameObject lastInstantiated = null;
    [SerializeField]
    Transform leftWall;
    [SerializeField]
    Transform rightWall;
    [SerializeField]
    Transform upWall;
    [SerializeField]
    Transform downLimit;
    [SerializeField]
    float modifyDownLimitPosition;
    List<Transform> allMapSeted;
    [SerializeField]
    private Transform upLimitGeneration;
    void OnEnable()
    {
        allMapSeted = new List<Transform>();
        start = myCm.ScreenToWorldPoint(Vector3.zero).x;
        end = myCm.ViewportToWorldPoint(Vector3.right).x;
        Generate();
        leftWall.position = myCm.ViewportToWorldPoint(Vector3.zero);
        rightWall.position = myCm.ViewportToWorldPoint(Vector3.right);
        upWall.position = myCm.ViewportToWorldPoint(Vector3.up);
        downLimit.position = myCm.ScreenToWorldPoint(new Vector3(0,-1 + modifyDownLimitPosition, 0));
    }
    
    void Generate()
    {
        int generator = Random.Range(0, 5);
        if (lastInstantiated == null) 
        {
            lastInstantiated = Instantiate(map[generator], transform);
            lastInstantiated.transform.position = new Vector3(start+(distance/2)-1, 0, 1);
            allMapSeted.Add(lastInstantiated.transform);
        }
        while (lastInstantiated.transform.position.x < end)
        {

            if (generator == 0)
            {
                generator = Random.Range(1, 4);
                lastInstantiated = Instantiate(map[generator],
                    new Vector3(lastInstantiated.transform.position.x + distance,
                             lastInstantiated.transform.position.y, 1),
                    Quaternion.identity, transform);
                allMapSeted.Add(lastInstantiated.transform);
            }
            else if (generator == 1)
            {
                generator = 0;
                lastInstantiated = Instantiate(map[generator],
                    new Vector3(lastInstantiated.transform.position.x,
                                lastInstantiated.transform.position.y + distance, 1),
                    Quaternion.identity, transform);
                allMapSeted.Add(lastInstantiated.transform);
                if(lastInstantiated.transform.position.y > upLimitGeneration.position.y)
                {
                    generator = 3;
                    lastInstantiated = Instantiate(map[generator],
                        new Vector3(lastInstantiated.transform.position.x + distance,
                                 lastInstantiated.transform.position.y, 1),
                        Quaternion.identity, transform);
                    allMapSeted.Add(lastInstantiated.transform);
                }
            }
            else if (generator == 2)
            {
                generator = Random.Range(3, 4);
                lastInstantiated = Instantiate(map[generator],
                    new Vector3(lastInstantiated.transform.position.x + distance,
                                lastInstantiated.transform.position.y, 1),
                    Quaternion.identity, transform);
                allMapSeted.Add(lastInstantiated.transform);
            }
            else if (generator == 3)
            {
                generator = 4;
                lastInstantiated = Instantiate(map[generator],
                    new Vector3(lastInstantiated.transform.position.x,
                                lastInstantiated.transform.position.y - distance, 1),
                    Quaternion.identity, transform);
                allMapSeted.Add(lastInstantiated.transform);
                if (lastInstantiated.transform.position.y < downLimit.position.y)
                {
                    generator = 1;
                    lastInstantiated = Instantiate(map[generator],
                        new Vector3(lastInstantiated.transform.position.x + distance,
                                 lastInstantiated.transform.position.y, 1),
                        Quaternion.identity, transform);
                    allMapSeted.Add(lastInstantiated.transform);
                    generator = 0;
                    lastInstantiated = Instantiate(map[generator],
                        new Vector3(lastInstantiated.transform.position.x,
                                    lastInstantiated.transform.position.y + distance, 1),
                        Quaternion.identity, transform);
                    allMapSeted.Add(lastInstantiated.transform);
                }
            }
            else if (generator == 4)
            {
                generator = Random.Range(1, 4);
                lastInstantiated = Instantiate(map[generator],
                    new Vector3(lastInstantiated.transform.position.x + distance,
                                lastInstantiated.transform.position.y, 1),
                    Quaternion.identity, transform);
                allMapSeted.Add(lastInstantiated.transform);
                
            }
        }
    }
 
    public List<Transform> GetMapSeted()
    {
        return allMapSeted;
    }
    void DestroyMap()
    {
        if (allMapSeted.Count!= 0)
        {
            foreach (Transform w in allMapSeted)
            {
                Destroy(w.gameObject);
            }
            allMapSeted.Clear();
        }
    }
    public void RestartMap()
    { 
        lastInstantiated = null; 
        DestroyMap();
        Generate();
    }

}
