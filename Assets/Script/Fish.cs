using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb; // degisken tanimlandi
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Rigidbody2d component ini aktardik
        _rb.velocity = new Vector2(_rb.velocity.x,9f);
    }

    void Update()
    {
        
    }
}
