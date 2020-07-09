using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    float constantForce;
    [SerializeField]
    float rotateSpeed;
    private Rigidbody2D myRig;
    [SerializeField]
    private ParticleSystem myPS;
    [SerializeField]
    private int gasoline;
    Vector3 startPosition;
    bool inAnimation;
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        inAnimation = false;
    }

    void Update()
    {
        UseGasoline();
        Rotar();
    }
    void UseGasoline()
    {
        if (Input.GetKey(KeyCode.Space) && Time.timeScale != 0.0f && !inAnimation)
        {
            if (gasoline > 0)
            {
                myRig.AddForce(transform.up * constantForce);
                gasoline--;
                if (!myPS.isPlaying)
                {
                    myPS.Play();
                }
            }
            else
            {
                gasoline = 0;
                myPS.Stop();
            }
        }
        else
        {
            if (myPS.isPlaying) myPS.Stop();
        }
    }
    void Rotar()
    {
        if (!inAnimation)
        {
            myRig.isKinematic = false;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                myRig.rotation -= (rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            { 
                myRig.rotation += (rotateSpeed * Time.deltaTime);
            }
        }
        else
        {
            myRig.isKinematic = true;
            myRig.velocity = Vector2.zero;
        }
        myRig.angularVelocity = 0.0f;
    }
    public int GetGasoline()
    {
        return gasoline;
    }
    public void ForceAffecting(Vector2 force)
    {
        myRig.AddForce(force);
    }
    public Vector2 GetVelocity()
    {
        return myRig.velocity;
    }
    public void RestartPosition()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        myRig.velocity = Vector2.zero;
    }
    public void SetInAnimation(bool w)
    {
        inAnimation = w;
    }
}
