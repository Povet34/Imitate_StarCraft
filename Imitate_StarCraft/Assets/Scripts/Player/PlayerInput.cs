using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RTS
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] Transform cameraTarget;
        [SerializeField] float keyboardPaneSpeed = 5;
        [SerializeField] CinemachineCamera cinemachineCamera;
        [SerializeField] float zoomSpeed = 1;
        [SerializeField] float minZoomDistance = 7.5f;
        [SerializeField] float maxZoomDistance = 15f;

        CinemachineFollow cinemachineFollow;
        float zoomStartTime;
        Vector3 startingFollowOffset;


        private void Awake()
        {
            if(!cinemachineCamera.TryGetComponent(out cinemachineFollow))
            {
                Debug.LogError("CinemachineCamera does not have a CinemachineFollow component.");
                return;
            }

            startingFollowOffset = cinemachineFollow.FollowOffset;
        }
            
        private void Update()
        {
            HandleZooming();
            HandlePanning();
        }

        void HandleZooming()
        {
            if(ShouldSetZoomStartTime())
            {
                zoomStartTime = Time.time;
            }

            float zoomTime = Mathf.Clamp01(Time.time - zoomStartTime) * zoomSpeed; 
            Vector3 targetFollowOffset = cinemachineFollow.FollowOffset;

            if(Keyboard.current.endKey.isPressed)
            {
                targetFollowOffset.y = minZoomDistance;
            }
            else
            {
                targetFollowOffset.y = maxZoomDistance;
            }

            cinemachineFollow.FollowOffset = Vector3.Slerp(cinemachineFollow.FollowOffset, targetFollowOffset, zoomTime);
        }

        bool ShouldSetZoomStartTime()
        {
            return Keyboard.current.endKey.wasPressedThisFrame || Keyboard.current.endKey.wasReleasedThisFrame;
        }

        void HandlePanning()
        {
            Vector2 moveAmount = Vector2.zero;

            if (Keyboard.current.upArrowKey.isPressed)
            {
                moveAmount.y += keyboardPaneSpeed;
            }
            if (Keyboard.current.downArrowKey.isPressed)
            {
                moveAmount.y -= keyboardPaneSpeed;
            }
            if (Keyboard.current.leftArrowKey.isPressed)
            {
                moveAmount.x -= keyboardPaneSpeed;
            }
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                moveAmount.x += keyboardPaneSpeed;
            }

            cameraTarget.position += new Vector3(moveAmount.x, 0, moveAmount.y) * Time.deltaTime;
        }
    }
}


