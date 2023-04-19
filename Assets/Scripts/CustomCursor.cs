using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D CustomCursorImage;
    void Start()
    {
        Cursor.SetCursor(
            CustomCursorImage,
            new Vector2(CustomCursorImage.width / 2, CustomCursorImage.height / 2),
            CursorMode.ForceSoftware);    
    }

}
