using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    Transform spriteTransform = null;

    void Start()
    {
        Cursor.visible = false;

        spriteTransform = GetComponentInChildren<Transform>();
    }

    void Update()
    {


        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        spriteTransform.position = cursorPos;
    }
}
