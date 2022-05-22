using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    // adapted and generalised from https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
    public static IEnumerator FadeTo(Color targetColor, double time, Image image){
        // I unironically desk-checked this algorithm lol
        Color startColor = image.color;
        Color difference = targetColor - startColor;
        for(float i=0;i<=time;i+=Time.deltaTime){
            image.color = startColor + difference * new Vector4(i,i,i,i); // Color is synonymous with Vector4, and works element-by-element for all maths operations.
            yield return null;
        }
    }
}
