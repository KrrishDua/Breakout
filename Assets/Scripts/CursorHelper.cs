using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHelper : MonoBehaviour
{
    // class needs to be run by cursorHelper GameObject to load handTexture, then can use static methods easily
    public Texture2D handTexture;
    public static void CursorNormal(){
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
    public static void CursorHand(){
                Cursor.SetCursor(GameObject.Find("cursorLoader").GetComponent<CursorHelper>().handTexture, new Vector2(0,0), CursorMode.Auto);
    }
}
