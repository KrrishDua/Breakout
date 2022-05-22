using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fading.FadeTo(new Color(1,1,1,0), 1, GameObject.Find("imgFade").GetComponent<Image>()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
