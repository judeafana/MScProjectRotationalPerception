using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script transitions between levels, meaning the different environments

public class GoToScene : MonoBehaviour
{
    public int scene;
    public GameObject point;
    public bool clicked = false;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex + 2;
    }
    
    void Update()
    {
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(point.transform.position, point.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
                if (hit.collider.tag == "button" && (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)|| Input.GetMouseButton(0)))

        {

            ChangeScene();
        }
    }
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}
