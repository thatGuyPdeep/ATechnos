using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public Vector2 moveVal;
    public Vector2 playerPos;
    public Vector3 pos;

    public float moveSpeed;

    public Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void Update()
    {
        pos =  new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime;
        transform.position += pos;
    }
}