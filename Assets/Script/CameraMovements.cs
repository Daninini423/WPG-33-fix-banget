using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private CameraShake cameraShake;

    void Start()
    {
        if (target != null)
            offset = transform.position - target.position;

        cameraShake = GetComponent<CameraShake>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Posisi target utama kamera
        Vector3 desiredPosition = target.position + offset;

        // Tambahkan efek shake
        if (cameraShake != null)
            desiredPosition += cameraShake.GetShakeOffset();

        // Smooth follow
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
