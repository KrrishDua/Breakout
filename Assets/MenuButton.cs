using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventdata){
        print("Pointer Entered");
        // fade to grey
        StartCoroutine(Fading.FadeTo(Color.grey, .2, GetComponent<Image>()));
    }

    public void OnPointerExit(PointerEventData eventdata){
        print("Pointer Exited");
        //fade to white
        StartCoroutine(Fading.FadeTo(Color.white, .2, GetComponent<Image>()));
    }
}
