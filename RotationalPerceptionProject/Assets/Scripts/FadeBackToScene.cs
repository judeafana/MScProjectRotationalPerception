using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeBackToScene : MonoBehaviour
{
   public Animator animator;
   // public Spawner checkingFlag;
    public int levelToLoad;
    
   // public RaycastingPoint sceneNum;
    public RaycastingPoint checkClick;
    
    int sceneCounter;
    

    private void Start()
    {

        if (PlayerPrefs.HasKey("sceneCounter"))
        {
            sceneCounter = PlayerPrefs.GetInt("sceneCounter");
            sceneCounter += 1;
            PlayerPrefs.SetInt("sceneCounter", sceneCounter);

        }

        else
        {
            sceneCounter = 1;
            PlayerPrefs.SetInt("sceneCounter", sceneCounter);
        }


        if (sceneCounter%3 ==0)
            levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        else
        levelToLoad = SceneManager.GetActiveScene().buildIndex - 1;
      
    }
    void Update()
    {
        if (checkClick.clickFlag)
        {
            FadeOut();
            checkClick.clickFlag = false;
        }
        
    }

    public void FadeOut()
    {
        animator.SetTrigger("Fade_Out");
        Debug.Log("Faded Out");
    }
    public void FadeIn()
    {
        animator.SetTrigger("Fade_In");
        Debug.Log("Faded In");
    }

    public void OnFadeComplete()
    {
        Debug.Log("used this amazing wonderful funtion to see if the onfade complete works or not!!!");
        SceneManager.LoadScene(levelToLoad);
    }
}
