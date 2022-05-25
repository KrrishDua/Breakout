using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ComputerButton : MenuButton, IPointerDownHandler
{
    public bool canOpenScreen = false;
    public void OnPointerDown(PointerEventData eventdata){
        if(canOpenScreen){
            print("Screen Opened");
            OnPointerExit(null);
            canOpenScreen = false;
            StartCoroutine(GameObject.Find("Canvas").GetComponent<UIScript>().ZoomScreenshotEasy(false));
            StartCoroutine(Wait2ThenSwitch());
        }
    }
    public override void OnPointerEnter(PointerEventData eventdata){
        if(canOpenScreen)
            base.OnPointerEnter(eventdata);
    }
    public override void OnPointerExit(PointerEventData eventdata){
        if(canOpenScreen)
            base.OnPointerExit(eventdata);
    }
    private IEnumerator Wait2ThenSwitch(){
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Title Screen");
    }
}
