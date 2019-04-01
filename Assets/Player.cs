using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 50f;
    [Tooltip("In m")] [SerializeField] float xRange = 22f;
    [Tooltip("In m")] [SerializeField] float yRangeMax = 17f;
    [Tooltip("In m")] [SerializeField] float yRangeMin = 14f;

    [SerializeField] float positionPitchFactor = -1.3f;
    [SerializeField] float controlPitchFactor = -14f;

    [SerializeField] float positionYawFactor = 1.3f;
    [SerializeField] float controlYawFactor = 15f;

    [SerializeField] float controlRollFactor = -25f;

    float yThrow;
    float xThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDueToControlThrow;

        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yoffset = yThrow * Speed * Time.deltaTime;
        float xoffset = xThrow * Speed * Time.deltaTime;

        float rawNewYPos = yoffset + transform.localPosition.y;
        float rawNewXPos = xoffset + transform.localPosition.x;
        float clampedYpos = Mathf.Clamp(rawNewYPos, -yRangeMin, yRangeMax);
        float clampedXpos = Mathf.Clamp(rawNewXPos, -xRange, xRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
