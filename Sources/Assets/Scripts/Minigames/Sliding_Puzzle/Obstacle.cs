using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public FieldBorder fieldBorder;

    public bool moveHorizontal;
    public bool moveVertical;

    private Rigidbody2D _rigidbody2D;
    
    private Vector3 lastValidPosition;
    private Vector3 offset;
    private Vector3 mousePosition;
    
    private float width, halfWidth;
    private float height, halfHeight;
    
    private void Awake()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        width = collider2D.size.x;
        halfWidth = width / 2;
        height = collider2D.size.y;
        halfHeight = height / 2;

        lastValidPosition = transform.position;
        offset = new Vector3(width % 2 == 0 ? 0f : 0.5f, height % 2 == 0 ? 0f : 0.5f, 0f);

        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionX;
        _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionY;
        _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnMouseDrag()
    {
        mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        if (!moveHorizontal)
            _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionX;
        if (!moveVertical)
            _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionY;
    }

    private void OnMouseUp()
    {
        mousePosition = Vector3.zero;
        
        _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionX;
        _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezePositionY;
        _rigidbody2D.constraints |= RigidbodyConstraints2D.FreezeRotation;
    }

    private void FixedUpdate()
    {
        if (mousePosition == Vector3.zero)
            return;
        
        lastValidPosition = new Vector3(transform.position.x, transform.position.y);
        
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(mousePosition) + offset;
        
        // Move only 1 unit at a time
        curPosition.Clamp(curPosition.x -1, curPosition.x + 1, curPosition.y + 1, curPosition.y - 1);
        
        // Move only on enabled axis
        Vector3 position = transform.position;
        position = new Vector3(
            (moveHorizontal ? curPosition.x : position.x),
            (moveVertical   ? curPosition.y : position.y),
            0f);

        // Move only within field borders
        if (tag.Equals("Player"))
        {
            position = position.Clamp(
                fieldBorder.left + halfWidth, 
                fieldBorder.right - halfWidth, 
                fieldBorder.top - halfHeight, 
                fieldBorder.bottom - halfHeight);
        }
        else
        {
            position = position.Clamp(
                fieldBorder.left + halfWidth, 
                fieldBorder.right - halfWidth, 
                fieldBorder.top - halfHeight, 
                fieldBorder.bottom + halfHeight);
        }

        Vector3 targetPosition = position.SnapOffset(offset);
        print(curPosition + " vs " + targetPosition);
        _rigidbody2D.MovePosition(new Vector2(targetPosition.x, targetPosition.y));
    }
}