using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        
        // Ensure the ball has a sphere collider
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider == null)
        {
            sphereCollider = gameObject.AddComponent<SphereCollider>();
        }

        // Optionally, apply a custom physics material for the ball
        // PhysicsMaterial2D ballMaterial = new PhysicsMaterial2D();
        // ballMaterial.bounciness = 0.6f; // Adjust based on desired bounce
        // ballMaterial.friction = 0.1f; // Adjust based on desired interaction
        // sphereCollider.sharedMaterial = ballMaterial;
    }
}
