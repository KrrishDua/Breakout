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
            GameObject.Find("imgScreenshot").GetComponent<RawImage>().texture = StartButton.screenshot;
            print(StartButton.screenshot.width);print(StartButton.screenshot.height);
            StartCoroutine(ZoomScreenshot());
            StartCoroutine(Wait1ThenFade());
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
    public IEnumerator ZoomScreenshot(){
        // took a long time to find the right RectTransform properties - anchoredPosition is position relative to anchor at centre of UI, sizeDelta is effectively just size
        RectTransform rt = GameObject.Find("imgScreenshot").GetComponent<RectTransform>();
        // hackily ensure correct proportions
        // working out (using 1027x642): 1027/16*?=642 => 1027/16 = 642/? => ? = 642/(1027/16)
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, (float)(rt.sizeDelta.x / 16.0 * (StartButton.screenshot.height/(StartButton.screenshot.width/16.0))));//*(StartButton.screenshot.height / StartButton.screenshot.width)));
        print(rt.sizeDelta);
        print((StartButton.screenshot.height/(StartButton.screenshot.width/16)));
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

    public IEnumerator Wait1ThenFade(){
        yield return new WaitForSeconds(1);
        FadeIn(1);
    }
}