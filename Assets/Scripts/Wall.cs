using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BallMovement ball))
        {
            //Reflect ball direction
            Vector3 reflectDir = Vector3.Reflect(ball.rb.linearVelocity, transform.forward.normalized);
            
            ball.ApplyForce(reflectDir.normalized);
        }
    }

    private void OnDrawGizmos()
    {
        //Debug line to show which way is forward when placing walls in editor
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5);
    }
}
