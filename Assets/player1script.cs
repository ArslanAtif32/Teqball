using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed of movement
    public float shootPower = 10f;
    public Rigidbody football;

    private void Update()
    {
        // Handle horizontal player movement (A and D keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Handle vertical player movement (W and S keys)
        float moveVertical = Input.GetAxis("Vertical");

        // Create movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Handle shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFootball();
        }
    }

    private void ShootFootball()
    {
        // Add force to the football to shoot it
        football.AddForce(Vector3.forward * shootPower, ForceMode.Impulse);
    }
}
