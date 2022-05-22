using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventdata){
        print("Clicked");
        SceneManager.LoadScene("Main Game");
    }

    public void OnPointerEnter(PointerEventData eventdata){
        print("Pointer Entered");
        StartCoroutine(Fading.FadeTo(Color.grey, .2, GetComponent<Image>()));
    }

    public void OnPointerExit(PointerEventData eventdata){
        print("Pointer Exited");
        StartCoroutine(Fading.FadeTo(Color.white, .2, GetComponent<Image>()));
    }
}
