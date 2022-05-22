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
        GetComponent<Image>().color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventdata){
        print("Pointer Exited");
        GetComponent<Image>().color = Color.white;
    }
}
