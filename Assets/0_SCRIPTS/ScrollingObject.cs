using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    
    [SerializeField] private Vector2 movementDirection = Vector2.left;
    [SerializeField] private float speed;

    private void Update()
    {
        this.transform.position = this.transform.position + (Vector3)movementDirection * speed * Time.deltaTime;
    }

}
