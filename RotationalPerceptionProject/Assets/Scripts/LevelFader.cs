using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFader : MonoBehaviour
{
    public Animator animator;
   public Spawner checkingFlag;
    public int levelToLoad;

   // public AudioSource audio;

    //public RaycastingPoint sceneNum;
    // public RaycastingPoint checkClick;

    // Update is called once per frame

    private void Start()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        //audio.Play();

      //  animator = GetComponent<Animator>();
     //   checkingFlag = GetComponent<Spawner>();
      //  checkClick = GetComponent<RaycastingPoint>();
      //  sceneNum = GetComponent<RaycastingPoint>();
      //  levelToLoad = sceneNum.goBackToScene;
        //checkClick = checkClick.clickFlag;
    }
    void Update()
    {
        if (checkingFlag.checkFlag)
        {
            FadeOut();
            //checkingFlag.checkFlag = false;
        }

     
    }

   public void FadeOut ()
    {
        animator.SetTrigger("Fade_Out");
    }
    public void FadeIn()
    {
        animator.SetTrigger("Fade_In");
    }

    public void OnFadeComplete()
    {
        Debug.Log("used this amazing wonderful funtion to see if the onfade complete works or not!!!");
        SceneManager.LoadScene(levelToLoad);
    }
}
