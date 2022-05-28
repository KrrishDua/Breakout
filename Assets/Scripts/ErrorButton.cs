using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ErrorButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [HideInInspector] public static bool errorVisible;
    public void OnPointerEnter(PointerEventData eventdata){
        if(errorVisible){
            StartCoroutine(Fading.FadeTo(Color.white, .1f, GetComponent<Image>()));
            CursorHelper.CursorHand();
        }
    }
    public void OnPointerExit(PointerEventData eventdata){
        StartCoroutine(Fading.FadeTo(new Color(1,1,1,0), .1f, GetComponent<Image>()));
        CursorHelper.CursorNormal();
    }
    public void OnPointerDown(PointerEventData eventdata){
        print("clicked");
        StartCoroutine(Fading.FadeTo(new Color(1,1,1,0), .2f, GameObject.Find("imgFade").GetComponent<Image>())); //half-fade to white
        GameObject.Find("imgError").GetComponent<Image>().color = Color.clear; // show error message
        ErrorButton.errorVisible = false;
        GetComponent<Image>().color = Color.clear;
        CursorHelper.CursorNormal();
    }
    public void ErrorSequence(){
        StartCoroutine(Fading.FadeTo(new Color(1,1,1,.3f), .2f, GameObject.Find("imgFade").GetComponent<Image>())); //half-fade to white
        GameObject.Find("imgError").GetComponent<Image>().color = Color.white; // show error message
        ErrorButton.errorVisible = true;
        //GameObject.Find("sndError").GetComponent<AudioSource>().Play(0); //play error sound
    }
}
