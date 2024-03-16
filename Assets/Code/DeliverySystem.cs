using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliverySystem : MonoBehaviour
{
    [SerializeField] Color32 packageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    private bool _hasPackage;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Package") && !_hasPackage)
        {
            _hasPackage = true;
            sr.color = packageColor;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Customer") && _hasPackage)
        {
            sr.color = noPackageColor;
            _hasPackage = false;
        }
    }
}
