using UnityEngine;
using Cinemachine;

/// <summary>
/// Class taking care of turning on and off virtual camera.
/// To use properly set up virtual camera inside of the room with this script on and trigger collider being boundry of the room.
/// </summary>
public class RoomCameraController : MonoBehaviour
{
    private readonly string PLAYER_TAG = "Player";

    /// <summary>
    /// Virtual camera should follow Player's transform and have set up confiner 2D extension with collider as a bounding shape. Camera's GameObject should be set off.
    /// </summary>
    [SerializeField]
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera.Follow = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ShouldCameraSwitch(collision))
        {
            virtualCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ShouldCameraSwitch(collision))
        {
            virtualCamera.gameObject.SetActive(false);
        }
    }

    private bool ShouldCameraSwitch(Collider2D collision)
    {
        return collision.CompareTag(PLAYER_TAG);
    }
}