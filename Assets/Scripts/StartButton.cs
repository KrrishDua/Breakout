using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButton : MenuButton, IPointerDownHandler
{
    // Start game when clicked
    public void OnPointerDown(PointerEventData eventdata){
        print("Clicked");
        StartCoroutine(GameObject.Find("Canvas").GetComponent<UIScript>().FadeOutThenSwitch());
    }
}
