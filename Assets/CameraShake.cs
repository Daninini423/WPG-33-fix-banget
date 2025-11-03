using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Vector3 shakeOffset = Vector3.zero;
    private bool isShaking = false;
    private float shakeDuration;
    private float shakeMagnitude;
    private float shakeTimer;

    public Vector3 GetShakeOffset()
    {
        return shakeOffset;
    }

    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        shakeTimer = 0f;
        isShaking = true;
    }

    void LateUpdate()
    {
        if (isShaking)
        {
            shakeTimer += Time.deltaTime;
            if (shakeTimer < shakeDuration)
            {
                float x = Random.Range(-1f, 1f) * shakeMagnitude;
                float y = Random.Range(-1f, 1f) * shakeMagnitude;
                shakeOffset = new Vector3(x, y, 0);
            }
            else
            {
                shakeOffset = Vector3.zero;
                isShaking = false;
            }
        }
    }
}
