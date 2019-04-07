using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("Object-movement")]
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 40f;
    [Tooltip("In m")] [SerializeField] float xRange = 27f;
    [Tooltip("In m")] [SerializeField] float yRangeMax = 15f;
    [Tooltip("In m")] [SerializeField] float yRangeMin = 15f;

    [Header("Screen-position based")]
    [SerializeField] float positionPitchFactor = -0.7f;
    [SerializeField] float positionYawFactor = 0.7f;
    [Header("Control-throw based")]
    [SerializeField] float controlPitchFactor = -17f;
    [SerializeField] float controlYawFactor = 25f;
    [SerializeField] float controlRollFactor = -30f;
    [Header("Bullets")]
    [SerializeField] GameObject[] bullets;
    [SerializeField] int Damage = 10;


    bool isControlEnabled = true;

    float yThrow;
    float xThrow;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }
    void OnPlayerDeath() //called by string reference
    {
        isControlEnabled = false;
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
    private void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }
    private void SetGunsActive(bool isACtive)
    {
        foreach (GameObject bullet in bullets)
        {
            var emissionModule = bullet.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isACtive;
        }
    }
    public int DamageDeal()
    {
        return Damage;
    }

}
