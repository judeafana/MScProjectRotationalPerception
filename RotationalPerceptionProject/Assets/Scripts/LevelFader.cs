using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script applies the fade in and out effect with the animation

public class LevelFader : MonoBehaviour
{
    public Animator animator;
    public Spawner checkingFlag;
    public int levelToLoad;
    
    private void Start()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;  
    }
    void Update()
    {
        if (checkingFlag.checkFlag)
        {
            FadeOut();
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
        Debug.Log("onfade complete works");
        SceneManager.LoadScene(levelToLoad);
    }
}
