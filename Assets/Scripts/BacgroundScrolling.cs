using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundScrolling : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        Scroll();
    }

    private void Scroll()
    {
        Vector2 offset = new Vector2(Time.fixedTime * speed, 0);
        meshRenderer.material.mainTextureOffset = offset;
    }
}
