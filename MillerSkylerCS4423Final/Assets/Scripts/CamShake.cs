using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
        // Transform of the GameObject you want to shake
    private Transform transform;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0.1f;
    private float dampingSpeed = .8f;
    Vector3 initialPosition;
    
    public void TriggerShake() {
    shakeDuration = .2f;
    }

    void Awake() {
    if (transform == null) {
        transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable() {
    initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0) {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        } else {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }
}
