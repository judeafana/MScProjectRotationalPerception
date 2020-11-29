using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

//Detects clicks when pointing and save it into the CSV file with the level’s information.

public class RaycastingPoint : MonoBehaviour
{
    public GameObject point;
    public GameObject origin;
    public bool clickFlag= false;
    public int goBackToScene;
    public int clickCounter;
    float angle;
    public CalculateAngle angleReceived;
    float pointingAngle;
    //use bool flag instead to get it 1 time only

    public AudioSource audio;

    string textHeaders;

    void Start()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        goBackToScene = currentLevel - 1;

        audio.Play();

        clickCounter = 0;
    }

    public void Update()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(origin.transform.position, point.transform.forward);

        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) || OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) /* || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) )//* || Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) ) /*|| OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)*/
        {
            clickCounter += 1;
            pointingAngle = angleReceived.angle;
           
            if (clickCounter == 2)
            {
                pointingAngle = angleReceived.angle;
                clickFlag = true;
                 CreateText();

            }

        }
        
    }


    void CreateText()
    {
        // Save to Oculus quest folder 
        string path2 = Application.persistentDataPath + "/ Angles.csv";

        //Save in unity's assets
     //   string path2 = Application.dataPath+ "/ Angles.csv";

        if (!File.Exists(path2))
        {
            // File.WriteAllText(path2, "Vertices \n");

            
            textHeaders = "Scene Name" + "," + "Angle" + "," +"Date and Time  \n";

            File.WriteAllText(path2,textHeaders);
        }

       //CheckAngle from the CalculateAngle script, it works well

       // string content = SceneManager.GetActiveScene().name + " Angle is : " + pointingAngle + ", "+ "Direction is : "  + point.transform.forward + " , " +System.DateTime.Now+ "\n";
        
       // File.AppendAllText(path2, content);

        string contents2 =  SceneManager.GetActiveScene().name + ","  + pointingAngle + "," + System.DateTime.Now + " \n";
        File.AppendAllText(path2, contents2);
     

      //  Debug.Log(" Angle is : " + angle + ", "+ "Direction is " + point.transform.forward);

     
    }
}
