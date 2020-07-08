using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    Vector2 gravityInWorld;
    [SerializeField]
    move playerMovement;
    
    void FixedUpdate()
    {
        ApplyGravityInPlayer();
    }
    void ApplyGravityInPlayer()
    {
        playerMovement.ForceAffecting(gravityInWorld);
    }
}
