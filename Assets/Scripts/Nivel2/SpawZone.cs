using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawZone : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;

    public string placeName;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();
        //si el nombre del lugar actual no corresponde al lugar que quiere
        //ir no siga con el código
        if (!thePlayer.nextPlacesName.Equals(placeName))
        {
            return;
        }
        thePlayer.transform.position = this.transform.position;
        theCamera.transform.position = new Vector3(this.transform.position.x,
                                                    this.transform.position.y,
                                                    theCamera.transform.position.z);
        thePlayer.lastMovement = facingDirection;
    }
}
