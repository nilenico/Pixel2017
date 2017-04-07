using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Transform camTransform;

    // How long the object should shake for.
    float shakeDuration;

    // Amplitude of the shake. A larger value shakes the camera harder.
    float shakeAmount = 0.1f;
    float decreaseFactor = 1.0f;
    bool shaking = false;

    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shaking = true;
            shakeDuration = 2.5f;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            shaking = false;
        }



        if (shaking)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;            
        }
        else
        {
            if (shakeDuration > 0)
            {
                shakeDuration -= Time.deltaTime * decreaseFactor;
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            }
            else
            {
                camTransform.localPosition = originalPos;
            }
        }
    }

    IEnumerator waitFinishShake()
    {
        yield return new WaitForSeconds(0.0f);

        shakeDuration = 3.0f;

        if (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }

    }
}
