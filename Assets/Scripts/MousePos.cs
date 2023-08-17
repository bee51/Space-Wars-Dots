using System;
using UnityEngine;

public class MousePos : MonoBehaviour
{
  

    private float LaMouse(Vector3 pos)
    {
        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var lookPos = new Vector2(ray.x- pos.x,ray.y  - pos.y);

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg - 90f;

        return angle;
    }
}