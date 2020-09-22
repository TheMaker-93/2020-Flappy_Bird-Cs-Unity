using Unity.Mathematics;
using UnityEngine;

public class ScrollingBackgroundController : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private SpriteRenderer[] tillingObjects = new SpriteRenderer[2];

    [SerializeField] private int currentTrackingIndex = -1;
    [SerializeField] private SpriteRenderer objectBeingTracked;

    [SerializeField] private float xViewportPointBeforePositionSwap = 1f;

    private void Awake()
    {
        if (gameCamera == null)
            gameCamera = Camera.main;
        if (tillingObjects == null || tillingObjects.Length == 0)
            Debug.LogError("No tiling objects had been deffined");

        objectBeingTracked = tillingObjects[currentTrackingIndex];

    }

    private void LateUpdate()
    {
        float xViewportPosition = GetObjectXViewportPosition(objectBeingTracked);
        Debug.LogError(xViewportPosition);

        if (xViewportPosition >= xViewportPointBeforePositionSwap)
        {
            // get the next object
            currentTrackingIndex += 1;
            if (currentTrackingIndex >= tillingObjects.Length)
            {
                currentTrackingIndex = 0;
                objectBeingTracked = tillingObjects[currentTrackingIndex];
            }

            float newXPosition = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            objectBeingTracked.transform.position = new Vector3(
                newXPosition + objectBeingTracked.bounds.size.x / 2,
                objectBeingTracked.transform.position.y,
                objectBeingTracked.transform.position.z);

            // get the next object
            currentTrackingIndex += 1;
            if (currentTrackingIndex >= tillingObjects.Length)
            {
                currentTrackingIndex = 0;
                objectBeingTracked = tillingObjects[currentTrackingIndex];
            }
        }
    }



    private float GetObjectXWorldPosition (SpriteRenderer _spriteRenderer)
    {
        float spriteXSize = _spriteRenderer.bounds.size.x;
        Vector2 spriteExtremePosition = _spriteRenderer.transform.position + new Vector3(spriteXSize / 2, 0, 0);

        return spriteExtremePosition.x;
    }

    private float GetObjectXViewportPosition(SpriteRenderer _spriteRenderer)
    {
        Vector2 spriteExtremePosition = new Vector2(GetObjectXWorldPosition(_spriteRenderer),0);

        Debug.DrawLine(this.transform.position, spriteExtremePosition);

        float spriteXViewportPosition = gameCamera.WorldToViewportPoint(spriteExtremePosition).x;
        return spriteXViewportPosition;
    }

}
