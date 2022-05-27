using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelpButton : MenuButton, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventdata) {
        Application.OpenURL("https://bababooey1234.github.io/BreakoutHelp/");
    }
}
