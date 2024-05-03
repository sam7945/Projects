using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float amplitude = 1f;
    public float frequency = 1f;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position based on a sine wave
        float time = Time.time * frequency;
        float offset = Mathf.Sin(time) * amplitude;
        Vector3 newPosition = initialPosition + (transform.up * offset);

        // Move the tentacle towards the target
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Rotate the tentacle towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        // Update the tentacle position
        transform.position = newPosition;
    }
}
