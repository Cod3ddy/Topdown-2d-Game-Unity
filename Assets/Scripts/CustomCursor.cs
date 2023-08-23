using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{

    private bool isCursorEnabled = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        Cursor.visible = isCursorEnabled;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        //get current mouse position
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        //disable or enable default mouse cursor and enable or disable custom cursor
        if (Input.GetKey(KeyCode.LeftControl)) isCursorEnabled = !isCursorEnabled;
        if(isCursorEnabled == true)
        {
            Cursor.visible = true;
            spriteRenderer.enabled = false;
        }
        else
        {
            Cursor.visible = false;
            spriteRenderer.enabled = true;
        }
    }
}
