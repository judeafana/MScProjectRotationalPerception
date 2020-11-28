using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {

            Debug.Log("Sword destryoed the target" + " " + gameObject.name + " " + collision.gameObject.name);
            Destroy(collision.gameObject);

        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Cylinder")
    //    {
    //        Debug.Log("Sword destryoed the cube" + );
    //        Destroy(other.gameObject);
    //    }
    //}
}
