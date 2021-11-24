using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    // private Vector3 mOffset;
    // private bool isBeingHeld = false;
    // Vector3 worldPosi;

    void OnMouseDrag()
    {
        transform.position = GetMousePosi();
    }

    Vector3 GetMousePosi()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
