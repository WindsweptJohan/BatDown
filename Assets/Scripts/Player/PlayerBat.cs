using UnityEngine;

public class PlayerBat : MonoBehaviour
{
    public float hitSphereRadius;
    public LayerMask ballLayerMask;

    public float swingCooldown = 1f;
    private float currentSwingCooldown;
    

    // Update is called once per frame
    private void Update()
    {
        if (currentSwingCooldown > 0)
        {
            //Swing cooldown after swing
            currentSwingCooldown -= Time.deltaTime;
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //Check if ball is inside sphere radius
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, hitSphereRadius, ballLayerMask);
            foreach (var hit in hitColliders)
            {
                if (hit.TryGetComponent(out BallMovement ball))
                {
                    //Calculate ball direction and apply force in that direction
                    var direction = ball.transform.position - this.transform.position;
                    ball.ApplyForce(direction.normalized);
                    
                    //Apply swing cooldown
                    currentSwingCooldown = swingCooldown;
                    DrawDebugSphere();
                }
            }
        }
    }
    
    private void DrawDebugSphere()
    {
        //Draws debug lines for testing hit range
        Debug.DrawLine(this.transform.position + Vector3.right * hitSphereRadius, transform.position - Vector3.right * hitSphereRadius, Color.red, 5f);
        Debug.DrawLine(this.transform.position + Vector3.forward * hitSphereRadius, transform.position - Vector3.forward * hitSphereRadius, Color.red, 5f);
    }
}
