using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

//: This script is responsible of transition between trials of levels, spawning cubes differently according to the level and mode, displaying the numbers and arrows of each new level.


public class Spawner : MonoBehaviour
{
    public GameObject myCube;
     GameObject myTarget;
    public float spawnTime ;
    Vector3 movement;
    
    GameObject clone;
    Vector3 initPosition;

    string spawnName;

    public int spawnCounter;
    public LevelFader callFade;
    public bool checkFlag;

    public int time = 0;

    string sceneName;

    Vector3 playerRound;
    Vector3 cloneRange;
    bool changeBool_x=false;
    bool changeBool_z=false;
    float range_x, range_z;

    public Transform originPoint;
    public GameObject cubeOriginPoint;

    public float rotAngle;
    public int sceneCounterOrig=0;

    public TMP_Text text;
    public GameObject containingCube;
    public Canvas canv;

    string sceneIndex;
    int sceneText;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        
       playerRound = GameObject.FindGameObjectWithTag("Player").transform.position;

                if (PlayerPrefs.HasKey("sceneCounterOrig"))
                {
                    sceneCounterOrig = PlayerPrefs.GetInt("sceneCounterOrig");
                    sceneCounterOrig += 1;
                    PlayerPrefs.SetInt("sceneCounterOrig", sceneCounterOrig);

                }

                else
                {
                    sceneCounterOrig = 0;
                    PlayerPrefs.SetInt("sceneCounterOrig", sceneCounterOrig);
                }
                
        sceneText = Mathf.CeilToInt(((SceneManager.GetActiveScene().buildIndex) /2) +1);

        text.text = sceneText.ToString();
       

        if ((sceneCounterOrig) %3==0)
        {  
 
        StartCoroutine(Appear());
        StartCoroutine(Disappear());
        spawnTime = 8;
          
        }
        else
        {
            spawnTime = 2;
            containingCube.SetActive(false);
            canv.gameObject.SetActive(false);
        }

            switch (sceneName)
        {
            case "InteractiveSceneSeatedConsistent":
                spawnName = "SpawnRandomSeated";
                break;
            case "InteractiveSceneSeatedInconsistent":
                {
                    spawnName = "SpawnRandomSeated2";
                    //cubeOriginPoint.transform.localRotation = originPoint.localRotation;
                    if (PlayerPrefs.HasKey("rotAngle"))
                    {
                        rotAngle = PlayerPrefs.GetFloat("rotAngle");

                        PlayerPrefs.SetFloat("rotAngle", rotAngle);

                        cubeOriginPoint.transform.eulerAngles = new Vector3(cubeOriginPoint.transform.eulerAngles.x, rotAngle, cubeOriginPoint.transform.eulerAngles.z);
                    }
                    else
                        rotAngle = 0;
                    PlayerPrefs.SetFloat("rotAngle", rotAngle);
                }
                break;
            case "InteractiveSceneSeatedNoCues":
                spawnName = "SpawnRandomSeated2";
                break;

            case "InteractiveSceneStandingConsistent":
                spawnName = "SpawnRandomStanding";
                break;

            case "InteractiveSceneStandingInconsistent":
                {
                    spawnName = "SpawnRandomStanding2";
                    //cubeOriginPoint.transform.localRotation = originPoint.localRotation;
                    if (PlayerPrefs.HasKey("rotAngle"))
                    {
                        rotAngle = PlayerPrefs.GetFloat("rotAngle");

                        PlayerPrefs.SetFloat("rotAngle", rotAngle);

                        cubeOriginPoint.transform.eulerAngles = new Vector3(cubeOriginPoint.transform.eulerAngles.x, rotAngle, cubeOriginPoint.transform.eulerAngles.z);
                    }
                    else
                        rotAngle = 0;
                    PlayerPrefs.SetFloat("rotAngle", rotAngle);
                }
                break;

            case "InteractiveSceneStandingNoCues":
                spawnName = "SpawnRandomStanding2";
                break;
                
        }

        InvokeRepeating(spawnName, spawnTime,4);
        myTarget = GameObject.FindGameObjectWithTag("Player");
    }

        IEnumerator Disappear()
    {
       yield return new WaitForSeconds(4);
        containingCube.SetActive(false);
        canv.gameObject.SetActive(false);

    }

    IEnumerator Appear()
{
        yield return new WaitForSeconds(0);
        containingCube.SetActive(true);
        canv.gameObject.SetActive(true);

    }

public void SpawnRandomSeated()
    {
        //first round make it from the front, then develop it to be all around the place, use 3d sounds to indicate the position of the object
        //Only in front of the player while seated
        clone =Instantiate(myCube, new Vector3 (Random.Range(myTarget.transform.position.x-1.6f, myTarget.transform.position.x+ 1.6f), Random.Range(myTarget.transform.position.y , myTarget.transform.position.y + 1), Random.Range(myTarget.transform.position.z +.6f, myTarget.transform.position.z + 1)), myTarget.transform.rotation);
     
        clone.transform.LookAt(myTarget.transform);
        Destroy(clone, 4);
        spawnCounter++;
    }
  
    public void SpawnRandomSeated2()
    {
        range_x = Random.Range(0.0f, 1.0f);
        if (range_x < 0.5f)
            changeBool_x = true;
        else changeBool_x = false;

        range_z = Random.Range(0.0f, 1.0f);
        if (range_z > 0.5f)
            changeBool_z = true;
        else changeBool_z = false;


        Debug.Log("bool_x=" + changeBool_x + " " +range_x + " , x= " + cloneRange.x);
        Debug.Log("bool_z=" + changeBool_z + " " +range_x + " , z= " + cloneRange.z);
        
        if (!changeBool_x)
            cloneRange.x = Random.Range(myTarget.transform.position.x + .6f, myTarget.transform.position.x + 2f);
        else
            cloneRange.x = Random.Range(myTarget.transform.position.x - .6f, myTarget.transform.position.x - 2f);

        if (changeBool_z)
            cloneRange.z = Random.Range(myTarget.transform.position.z + .6f, myTarget.transform.position.z + 2f);
        else
            cloneRange.z = Random.Range(myTarget.transform.position.z - .6f, myTarget.transform.position.z - 2f);

        cloneRange = new Vector3(cloneRange.x, Random.Range(myTarget.transform.position.y, myTarget.transform.position.y + 1), cloneRange.z);

        //All around the player while seated, will be duplicated into 2 different scenes (w & w/o cues)
        clone = Instantiate(myCube, cloneRange, myCube.transform.rotation); /*new Vector3(Random.Range(myTarget.transform.position.x - 1.5f, myTarget.transform.position.x + 1.5f), Random.Range(myTarget.transform.position.y, myTarget.transform.position.y + 1), Random.Range(myTarget.transform.position.z - 1, myTarget.transform.position.z + 1))*/

        clone.transform.LookAt(myTarget.transform);
        Destroy(clone, 4);
        spawnCounter++;
      
    }

    public void SpawnRandomStanding()
    {
        //Only front while standing
        clone = Instantiate(myCube, new Vector3(Random.Range(myTarget.transform.position.x - 1.7f, myTarget.transform.position.x + 1.7f), Random.Range(myTarget.transform.position.y, myTarget.transform.position.y + 1), Random.Range(myTarget.transform.position.z + .6f, myTarget.transform.position.z + 1)), myTarget.transform.rotation);
        
        clone.transform.LookAt(myTarget.transform);
        Destroy(clone, 4);
        spawnCounter++;
    }

    public void SpawnRandomStanding2()
    {
        
        range_x = Random.Range(0.0f, 1.0f);
        if (range_x < 0.5f)
            changeBool_x = true;
        else changeBool_x = false;

        range_z = Random.Range(0.0f, 1.0f);
        if (range_z > 0.5f)
            changeBool_z = true;
        else changeBool_z = false;

        
        if (!changeBool_x)
            cloneRange.x = Random.Range(myTarget.transform.position.x + .7f, myTarget.transform.position.x + 2f);
        else
            cloneRange.x = Random.Range(myTarget.transform.position.x - .7f, myTarget.transform.position.x - 2f);

        if (changeBool_z)
            cloneRange.z = Random.Range(myTarget.transform.position.z + .7f, myTarget.transform.position.z + 2f);
        else
            cloneRange.z = Random.Range(myTarget.transform.position.z - .7f, myTarget.transform.position.z - 2f);

        cloneRange = new Vector3(cloneRange.x, Random.Range(myTarget.transform.position.y+ .3f, myTarget.transform.position.y + 1.3f), cloneRange.z);

        //All around the player while standing, will be duplicated into 2 different scenes (w & w/o cues)
        clone = Instantiate(myCube, cloneRange, myCube.transform.rotation);  /*new Vector3(Random.Range(myTarget.transform.position.x - 1.5f, myTarget.transform.position.x + 1.5f), Random.Range(myTarget.transform.position.y, myTarget.transform.position.y + 1), Random.Range(myTarget.transform.position.z - 1, myTarget.transform.position.z + 1))*/


        //All around the player while standing , will be duplicated into 2 different scenes (w & w/o cues)
        // clone = Instantiate(myCube, new Vector3(Random.Range(myTarget.transform.position.x - 2, myTarget.transform.position.x + 2), Random.Range(myTarget.transform.position.y, myTarget.transform.position.y + 1), Random.Range(myTarget.transform.position.z - 2, myTarget.transform.position.z + 1)), myCube.transform.rotation);

        clone.transform.LookAt(myTarget.transform);
        Destroy(clone, 4);
        spawnCounter++;
    }

        void Update()
    {
       //Debug.Log(sceneText + ", " + (SceneManager.GetActiveScene().buildIndex).ToString());

        rotAngle = cubeOriginPoint.transform.eulerAngles.y;
        PlayerPrefs.SetFloat("rotAngle", rotAngle);

        if (spawnCounter == 8)
        {
            time++;
            if (time >= 75)
            {
                checkFlag = true;
                
                time = 0;

            }
        }

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
       
        Caching.ClearCache();
    }
       
}
