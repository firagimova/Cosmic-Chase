using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float rotationSpeed = 30f; // Speed of the rotation
    private Vector3 randomRotation;

    public int hp;

    // Start is called before the first frame update
    void Start()
    {
        // Generate a random rotation for each axis
        randomRotation = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        );

        // Normalize the rotation to make sure it's a direction vector
        randomRotation.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomRotation * rotationSpeed * Time.deltaTime);
    }
}
