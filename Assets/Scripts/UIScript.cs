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
        //on main game load, load in screenshot from title screen, then "zoom out" from it (move and scale the image, not the camera)
        if(SceneManager.GetActiveScene().name == "Main Game"){
            StartButton.screenshot ??= new Texture2D(1920,1080); //if screenshot doesn't exist (i.e. we're testing), make a blank one
            GameObject.Find("imgScreenshot").GetComponent<RawImage>().texture = StartButton.screenshot; //set imgScreenshot texture to screenshot
            StartCoroutine(ZoomScreenshotEasy());//start zooming
            StartCoroutine(Wait1ThenFade());//wait one second then fade in
        }
    }

    public void FadeOut(float time){
        // fade to black over {time} seconds
        StartCoroutine(Fading.FadeTo(Color.black, time, GameObject.Find("imgFade").GetComponent<Image>()));
    }

    public void FadeIn(float time){
        // fade to clear over {time} seconds
        StartCoroutine(Fading.FadeTo(Color.clear, time, GameObject.Find("imgFade").GetComponent<Image>()));
    }
    // basically just modified Fading.FadeTo
    //unused rn
    public IEnumerator ZoomScreenshot(){
        // took a long time to find the right RectTransform properties - anchoredPosition is position relative to anchor at centre of UI, sizeDelta is effectively just size
        RectTransform rt = GameObject.Find("imgScreenshot").GetComponent<RectTransform>();
        // hackily ensure correct proportions
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.x * ((float)StartButton.screenshot.height / StartButton.screenshot.width));
        //get start, target, and difference vectors
        Vector3 startPos  = rt.anchoredPosition, targetPos  = new Vector3(-365, 149, 0), differencePos  = targetPos  - startPos;
        Vector2 startSize = rt.sizeDelta,        targetSize = new Vector2(81, 45),       differenceSize = targetSize - startSize;
        // same as Fading.FadeTo
        float proportion;
        for(float timePassed=0; (proportion=timePassed/2)<=1; timePassed+=Time.deltaTime){
            rt.anchoredPosition = startPos + Vector3.Scale(differencePos, new Vector3(proportion, proportion, 1));
            rt.sizeDelta = startSize + Vector2.Scale(differenceSize, new Vector2(proportion, proportion)); //vectors use Scale not * like Color
            yield return null;
        }
        //set to exactly right position at the end
        rt.anchoredPosition = targetPos;
        rt.sizeDelta = targetSize;
    }

    public IEnumerator ZoomScreenshotEasy(){ //using cubic easing, which is just 2 cubic functions smashed together halfway
        //same function, but proportion = cubicEase(timePassed)
        // took a long time to find the right RectTransform properties - anchoredPosition is position relative to anchor at centre of UI, sizeDelta is effectively just size
        RectTransform rt = GameObject.Find("imgScreenshot").GetComponent<RectTransform>();
        // hackily ensure correct proportions
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.x * ((float)StartButton.screenshot.height / StartButton.screenshot.width));
        //get start, target, and difference vectors
        Vector3 startPos  = rt.anchoredPosition, targetPos  = new Vector3(-365, 149, 0), differencePos  = targetPos  - startPos;
        Vector2 startSize = rt.sizeDelta,        targetSize = new Vector2(81, 45),       differenceSize = targetSize - startSize;
        // same as Fading.FadeTo
        float proportion;
        for(float timePassed=0; (proportion=cubicEase(timePassed))<=1; timePassed+=Time.deltaTime){
            rt.anchoredPosition = startPos + Vector3.Scale(differencePos, new Vector3(proportion, proportion, 1));
            rt.sizeDelta = startSize + Vector2.Scale(differenceSize, new Vector2(proportion, proportion)); //vectors use Scale not * like Color
            yield return null;
        }
        //set to exactly right position at the end
        rt.anchoredPosition = targetPos;
        rt.sizeDelta = targetSize;
    }

    private float cubicEase(float x){ // 0<=x<=2
        // .5x^3 if x<=1 else 1 + .0625(2x-4)^3
        //maths function from https://easings.net/#easeInOutCubic
        if(x<=1)
            return .5f*x*x*x;
        else {
            float temp = 2*x-4;
            return 1 + .0625f*(temp*temp*temp);
        }
    }

    public IEnumerator Wait1ThenFade(){
        yield return new WaitForSeconds(1);
        FadeIn(1);
    }
}