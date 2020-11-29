using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script rotates the environment around the player (providing the inconsistency). 

public class MoveAround : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * .4f);
    }
}
