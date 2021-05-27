using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePlayer : MonoBehaviour
{
    public Vector2 mousePos;
    public Vector2 gamepadPos;
    public Vector2 targetDirection;

    public bool isFiring;

    public Rigidbody rb;
    public MovePlayer mp;

    void OnLook(InputValue value)
    {
        mousePos = value.Get<Vector2>();
    }
    void OnGamepadLook(InputValue value)
    {
        gamepadPos = value.Get<Vector2>();
    }

    void Update()
    {
        //Mouse Look
        Ray cameraRay = mp.cam.ScreenPointToRay(mousePos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(pointToLook);
        }

        //Gamepad Look
        Vector3 playerDirection = Vector3.right * gamepadPos.x + Vector3.forward * gamepadPos.y;
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }
    }
}
