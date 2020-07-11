using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forceMapLimit : MonoBehaviour
{
    [SerializeField]
    private Vector2 myForceDirection;
    void Start()
    {

    }
    void OnTriggerStay2D(Collider2D collision)//asAS
    {
        if(collision.gameObject.tag == "Player")
        {
            Rigidbody2D col = collision.GetComponent<Rigidbody2D>();

            collision.transform.position = new Vector3(
                collision.transform.position.x + myForceDirection.normalized.x * (Time.deltaTime * Mathf.Abs(col.velocity.x)),
                collision.transform.position.y - myForceDirection.normalized.y * (Time.deltaTime * Mathf.Abs(col.velocity.y)),
                collision.transform.position.z);
            if(myForceDirection.x != 0)
            {
                col.velocity = new Vector2(0,col.velocity.y);
            }
            else if (myForceDirection.y != 0)
            {
                col.velocity = new Vector2(col.velocity.x,0);
            }

        }

    }
}