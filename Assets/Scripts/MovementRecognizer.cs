using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementRecognizer : MonoBehaviour
{
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputTreshold = 0.1f;
    public AudioSource audioSource;

    private bool isMoving = false;


    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputTreshold);

        //Start the movement
        if (!isMoving && isPressed)
        {
            StartMovement();
        }
        //Ending the movement
        else if (isMoving && !isPressed)
        {
            if (audioSource.isPlaying)
            {
                //Stop the audio
                audioSource.Stop(); ;
            }
            EndMovement();
        }
        //Updating the movement
        else if (isMoving && isPressed)
        {
            if (!audioSource.isPlaying)
            {
                //Play the audio
                audioSource.Play();
            }
            UpdateMovement();
        }
    }

    void StartMovement()
    {
        Debug.Log("Start Movement");
        isMoving = true;
    }

    void EndMovement()
    {
        Debug.Log("End Movement");
        isMoving = false;
    }

    void UpdateMovement()
    {
        Debug.Log("Update Movement");
    }
}
