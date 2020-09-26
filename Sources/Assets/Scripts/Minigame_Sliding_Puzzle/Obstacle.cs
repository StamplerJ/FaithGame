using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool moveHorizontal;
    public bool moveVertical;

    private Rigidbody2D rigidbody;
    
    private Vector3 startPosition;
    private Vector3 offset;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        if (!moveHorizontal)
            rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionX;
        
        if (!moveVertical)
            rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnMouseDown()
    {
        startPosition = transform.position;
        offset = startPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        Vector3 position = transform.position;
        position = new Vector3(
            (moveHorizontal ? curPosition.x : position.x),
            (moveVertical   ? curPosition.y : position.y),
            0f);

        if (tag.Equals("Player"))
        {
            position = position.Clamp(5f, 5.5f, 0f);
        }
        else
        {
            position = position.Clamp(5f, 5f, 0f);
        }
        
        rigidbody.MovePosition(position.SnapOffset(new Vector3(0f, 0.5f, 0f)));
    }
}
