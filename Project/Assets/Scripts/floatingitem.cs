using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    public float floatHeight = 0.5f; // Height of the floating movement
    public float floatSpeed = 1f;     // Speed of the floating movement
    public float rotationSpeed = 50f; // Speed of the rotation

    private Vector3 originalPosition;

    private void Start()
    {
        // Store the original position of the object
        transform.localScale = new Vector3(0.75f,0.75f,0f);
        originalPosition = transform.position;
    }

    private void Update()
    {
        // Calculate the floating effect
        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);

        // Rotate around the Y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    public void SetPosition(Vector3 newPosition)
    {
    originalPosition = newPosition;
    }

}
