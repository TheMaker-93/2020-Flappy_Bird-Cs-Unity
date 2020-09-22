using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.Events;

public class DeathController : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;

    [SerializeField] private string killingCollidersTag = "None";
    [SerializeField] private bool isKillableByCollisions = true;
    [SerializeField] private bool isKillableByExitingCameraSpace = true;

    [SerializeField] private bool isDead = false;
    [SerializeField] private UnityEvent OnPlayerKilled;

    private void LateUpdate()
    {
        Vector2 objectViewportPosition = gameCamera.WorldToViewportPoint(this.transform.position);
        //Debug.LogError(objectViewportPosition);
        if (objectViewportPosition.y > 1 || objectViewportPosition.y < 0)
        {
            // kill the player
            KillPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == killingCollidersTag)
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        isDead = true;

        if (OnPlayerKilled != null)
            OnPlayerKilled.Invoke();
    }
}
