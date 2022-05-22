using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    // adapted and generalised from https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/
    public static IEnumerator FadeTo(Color targetColor, float time, Image image){
        // I unironically desk-checked this algorithm lol
        Color startColor = image.color;
        Color difference = targetColor - startColor;
        float proportion;
        for(float timePassed=0; (proportion=timePassed/time)<=1; timePassed+=Time.deltaTime){
            image.color = startColor + difference * new Color(proportion, proportion, proportion, proportion); // Color is synonymous with Vector4; works element-by-element for all maths operations.
            yield return null;
        }
        image.color = targetColor;
        print("Finished fading to " + image.color.ToString());
    }
}
