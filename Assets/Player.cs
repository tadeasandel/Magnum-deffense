using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")] [SerializeField] float Speed = 4f;
    [Tooltip("In m")] [SerializeField] float xRange = 19f;
    [Tooltip("In m")] [SerializeField] float yRangeMax = 12f;
    [Tooltip("In m")] [SerializeField] float yRangeMin = 12f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yoffset = yThrow * xSpeed * Time.deltaTime;
        float xoffset = xThrow * xSpeed * Time.deltaTime;

        float rawNewYPos = yoffset + transform.localPosition.y;
        float rawNewXPos = xoffset + transform.localPosition.x;
        float clampedYpos = Mathf.Clamp(rawNewYPos, -yRangeMin, yRangeMax);
        float clampedXpos = Mathf.Clamp(rawNewXPos,-xRange, xRange);

        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
