using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject followTarget;
    [SerializeField] private Vector3 targetPosicion;
    [SerializeField] private float cameraSpeed = 4.0f;

    private Camera _camera;
    private Vector3 minLimits, maxLimits;

    private float halfWidth,halfHeigth;
    void Start()
    {

        
    }
    
    void Update()
    {
        targetPosicion = new Vector3(followTarget.transform.position.x,
                                    followTarget.transform.position.y,
                                    this.transform.position.z);

        this.transform.position = Vector3.Lerp(this.transform.position,
                                                targetPosicion,
                                                cameraSpeed * Time.deltaTime);
        
        float clampX = Mathf.Clamp(this.transform.position.x,
                                    minLimits.x + halfWidth, 
                                    maxLimits.x -halfWidth);

        float clampY = Mathf.Clamp(this.transform.position.y,
                                    minLimits.y + halfHeigth,
                                    maxLimits.y - halfHeigth);
        
        this.transform.position = new Vector3(clampX, clampY, this.transform.position.z);
    }

    public void ChangeLimits(BoxCollider2D newCameraLimits)
    {
        minLimits = newCameraLimits.bounds.min;
        maxLimits = newCameraLimits.bounds.max;
        _camera = GetComponent<Camera>();
        halfWidth = _camera.orthographicSize;
        halfHeigth = halfWidth / Screen.width * Screen.height;
    }
}
