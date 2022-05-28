using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MenuButton, IPointerDownHandler
{
    public static Texture2D screenshot;
    //make sndError not unload after scene change
    public void Start(){
        DontDestroyOnLoad(GameObject.Find("sndError"));
    }
    // Start game when clicked
    public void OnPointerDown(PointerEventData eventdata){
        if(!interactable)return;
        // if button is not left click, return
        if(eventdata.button != PointerEventData.InputButton.Left)return;
        print("Clicked");
        StartCoroutine(ErrorSequence());
        GameObject.Find("imgErrorHover").GetComponent<ErrorButton>().ErrorSequence();
    }
    // wait until the frame has fully rendered, screenshot it, TODO finish this comment
    public IEnumerator ErrorSequence(){
        interactable = false;
        GameObject.Find("btnStart").GetComponent<Image>().color = Color.white;
        yield return new WaitForEndOfFrame();
        screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        //yield return new WaitForSeconds(2); // wait one second
        //yield return new WaitForEndOfFrame();// wait until frame has fully rendered
        // screenshot it
        // https://docs.unity3d.com/ScriptReference/ScreenCapture.CaptureScreenshotAsTexture.html
        //screenshotError = ScreenCapture.CaptureScreenshotAsTexture();
        // load main game - note that screenshot is not destroyed as it is static
        SceneManager.LoadScene("Main Game");
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);
    }
}
