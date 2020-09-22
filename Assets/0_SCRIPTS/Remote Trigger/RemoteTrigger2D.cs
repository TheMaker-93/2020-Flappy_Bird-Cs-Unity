using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RemoteTrigger2D : MonoBehaviour
{
    private Collider2D collider;

    public OnTriggerEvent OnTriggerEnter;
    public OnTriggerEvent OnTriggerStay;
    public OnTriggerEvent OnTriggerExit;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter?.Invoke(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerStay?.Invoke(collision);   
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExit?.Invoke(collision);
    }

}