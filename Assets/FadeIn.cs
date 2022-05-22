using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fade());
    }
    //https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
    IEnumerator Fade(){
        //start at opacity 1, then decrease by delta time and yield until opacity 0
        for(float i=1;i>=0;i-=Time.deltaTime){
            GetComponent<Image>().color = new Color(0,0,0,i);
            yield return null;
        }

    }
}
