using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //on scene load
        if(SceneManager.GetActiveScene().name == "Main Game")
            FadeIn();
    }

    public void FadeOut(){
        // fade to black over 1 second
        StartCoroutine(Fading.FadeTo(Color.black, 1, GameObject.Find("imgFade").GetComponent<Image>()));
    }

    public void FadeIn(){
        // fade to clear over 1 second
        StartCoroutine(Fading.FadeTo(Color.clear, 1, GameObject.Find("imgFade").GetComponent<Image>()));
    }
    // slightly hacky. I wanted to fade out the menu screen before switching, but the OnPointerDown handler muse return void, so have to make a different function do it.
    public IEnumerator FadeOutThenSwitch(){
        FadeOut();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Main Game");
        CursorHelper.CursorNormal();
    }
}