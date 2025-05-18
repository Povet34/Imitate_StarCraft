using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Transform cameraTarget;
    [SerializeField] float keyboardPaneSpeed = 5;

    private void Update()
    {
        Vector2 moveAmount = Vector2.zero;

        if(Keyboard.current.upArrowKey.isPressed)
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
