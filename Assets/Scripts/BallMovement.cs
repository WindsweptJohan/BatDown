using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballSpeed;
    public Rigidbody rb;

    private Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    public void ApplyForce(Vector3 direction)
    {
        //Function called from scripts like wall, bat and hitblock to apply force
        rb.linearVelocity = direction * ballSpeed;
    }

    public void ResetBall()
    {
        //Resets ball to default position after out of bounds
        rb.linearVelocity = Vector3.zero;
        transform.position = defaultPosition;
    }

    public void ForceDestroy()
    {
        Destroy(gameObject);
    }
}
