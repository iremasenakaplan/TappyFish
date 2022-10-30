using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float _speed;
    BoxCollider2D _box;
    float groundWidth;

    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        groundWidth = _box.size.x;
    }

    
    void Update()
    {
        transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);

        if(transform.position.x <= -groundWidth)
        {
            transform.position = new Vector2(transform.position.x + 2 * groundWidth,transform.position.y);
        }
    }
}
