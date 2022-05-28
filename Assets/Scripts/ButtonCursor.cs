using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCursor : MenuButton, IPointerDownHandler
{
    // Start is called before the first frame update
        public void OnPointerDown(PointerEventData eventdata){
        if(!interactable)return;
        // if button is not left click, return
        if(eventdata.button != PointerEventData.InputButton.Left)return;
        print("Clicked");
        OnPointerExit(null);
    }
}
