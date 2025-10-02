using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    
    private float horizontalInput;

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput != 0)
            MovePlayer();
    }

    private void MovePlayer()
    {
        transform.position += Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;
    }
}
