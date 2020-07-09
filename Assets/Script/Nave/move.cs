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
    private int gasoline;
    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        gasoline = 5500;
    }

    void Update()
    {
        UseGasoline();
        Rotar();
    }
    void UseGasoline()
    {
        if (Input.GetKey(KeyCode.Space) && Time.timeScale != 0.0f)
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
            if (myPS.isPlaying) myPS.Stop();
        }
    }
    void Rotar()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRig.rotation -= (rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRig.rotation += (rotateSpeed * Time.deltaTime);
        }
        myRig.angularVelocity = 0.0f;
    }
    public int getGasoline()
    {
        return gasoline;
    }
    public void ForceAffecting(Vector2 force)
    {
        myRig.AddForce(force);
    }
}
