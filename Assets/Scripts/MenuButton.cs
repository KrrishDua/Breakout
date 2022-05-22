using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D handTexture;
    public void OnPointerEnter(PointerEventData eventdata){
        print("Pointer Entered");
        // fade to grey
        StartCoroutine(Fading.FadeTo(new Color(.5f, .5f, .5f, 1), .1f, GetComponent<Image>()));
        // change cursor to hand
        // a little annoyingness - can't inherit handTexture value, only want to load it once, so have to run this script in cursorLoader GameObject and access its property from there
        Cursor.SetCursor(GameObject.Find("cursorLoader").GetComponent<MenuButton>().handTexture, new Vector2(0,0), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventdata){
        print("Pointer Exited");
        // fade to white
        StartCoroutine(Fading.FadeTo(Color.white, .1f, GetComponent<Image>()));
        // reset cursor to pointer
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
