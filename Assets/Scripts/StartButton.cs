using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MenuButton, IPointerDownHandler
{
    // int screenWidth = 1920, screenHeight = 1080;
    public static Texture2D screenshot;
    // Start game when clicked
    public void OnPointerDown(PointerEventData eventdata){
        // if button is not left click, return
        if(eventdata.button != PointerEventData.InputButton.Left)return;
        print("Clicked");
        StartCoroutine(ScreenshotThenSwitch());
    }
    // wait until the frame has fully rendered, screenshot it, then switch scenes
    public IEnumerator ScreenshotThenSwitch(){
        // wait until frame has fully rendered
        yield return new WaitForEndOfFrame();
        // screenshot it
        // https://docs.unity3d.com/ScriptReference/ScreenCapture.CaptureScreenshotAsTexture.html
        screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        // load main game - note that screenshot is not destroyed as it is static
        SceneManager.LoadScene("Main Game");
    }
}
