using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public FieldBorder fieldBorder;

    public bool moveHorizontal;
    public bool moveVertical;

    private Vector3 startPosition;
    private Vector3 offset;

    private float width, halfWidth;
    private float height, halfHeight;
    
    private void Awake()
    {
        BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
        width = collider2D.size.x;
        halfWidth = width / 2;
        height = collider2D.size.y;
        halfHeight = height / 2;

        offset = new Vector3(width % 2 == 0 ? 0f : 0.5f, height % 2 == 0 ? 0f : 0.5f, 0f); 
    }

    private void OnMouseDown()
    {
        startPosition = transform.position;
        //offset = startPosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
    }

    private void OnMouseDrag()
    {
        Vector3 oldPosition = transform.position;
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
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
        
        // Check if another obstacle is in the way
        Vector3 direction = (position - oldPosition).normalized;
        RaycastHit2D hit = Physics2D.Raycast(oldPosition, direction, 1f, LayerMask.GetMask("Obstacle"));

        if (hit.collider != null)
        {
            print("hit");
            // transform.position = position.SnapOffset(offset);
            
            float distance = Mathf.Abs(hit.point.x - oldPosition.x);
            if (distance <= 1f)
            {
                print("block!");
                transform.position = position.SnapOffset(offset);
            }
        }else
            print("no hit");
    }
}
