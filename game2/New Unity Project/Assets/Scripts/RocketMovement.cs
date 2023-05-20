using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100.0f;
    [SerializeField] float rotationThrust = 100.0f;
    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Entered the Rocket Movement Script");

        rb = GetComponent<Rigidbody> ();
        audioSource = GetComponent <AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce( Vector3.up * mainThrust * Time.deltaTime); // (0, 1, 0)
            // Debug.Log("Pressed Space - Thrusting");
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }

        else 
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Debug.Log("Rotating left");
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            // Debug.Log("Rotating Right");
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
}
