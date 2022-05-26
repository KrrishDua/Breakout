using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public bool interactable = true;

    public virtual void OnPointerEnter(PointerEventData eventdata){
        if(!interactable)return;
        print("Pointer Entered");
        // fade to grey
        StartCoroutine(Fading.FadeTo(new Color(.5f, .5f, .5f, 1), .1f, GetComponent<Image>()));
        // set cursor to hand
        CursorHelper.CursorHand();
    }

    public virtual void OnPointerExit(PointerEventData eventdata){
        if(!interactable)return;
        print("Pointer Exited");
        // fade to white
        StartCoroutine(Fading.FadeTo(Color.white, .1f, GetComponent<Image>()));
        // reset cursor to pointer
        CursorHelper.CursorNormal();
    }
}
