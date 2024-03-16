using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Driving : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float speed = 0.1f;
    private float slowSpeed = 20f;
    private float boostSpeed = 30f;

    void Update()
    {
        float rotateAmount = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Rotate(0, 0, -rotateAmount);
        transform.Translate(0, speedAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boost"))
        {
            speed = boostSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed = slowSpeed;
    }
}
