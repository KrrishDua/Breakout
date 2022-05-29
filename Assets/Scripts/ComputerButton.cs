using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ComputerButton : MenuButton, IPointerDownHandler
{
    public void Start(){
        interactable = false;
    }
    public void OnPointerDown(PointerEventData eventdata){
        if(!interactable)return;

        print("Screen Opened");
        OnPointerExit(null);
        interactable = false;
        StartCoroutine(GameObject.Find("Background").GetComponent<UIScript>().ZoomScreenshotEasy(false));
        StartCoroutine(Wait2ThenSwitch());
    }
    /*public override void OnPointerEnter(PointerEventData eventdata){
        if(canOpenScreen)
            base.OnPointerEnter(eventdata);
    }
    public override void OnPointerExit(PointerEventData eventdata){
        if(canOpenScreen)
            base.OnPointerExit(eventdata);
    }*/
    private IEnumerator Wait2ThenSwitch(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Title Screen");
    }
}
