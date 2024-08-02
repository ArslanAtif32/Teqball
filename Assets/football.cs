using UnityEngine;

public class FootballController : MonoBehaviour
{
    private Vector3 initialPosition; // To store the initial position of the football
    public float speedMultiplier = 2.0f; // To control the speed increase when hit by a player

    private void Start()
    {
        // Store the initial position of the football
        initialPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Check for collision with Player 1
        if (collision.gameObject.CompareTag("player 1"))
        {
            // Apply force towards Player 2
            Vector3 direction = (GetPlayer2Position() - transform.position).normalized;
            rb.AddForce(direction * speedMultiplier, ForceMode.Impulse);
        }
        // Check for collision with Player 2
        else if (collision.gameObject.CompareTag("player 2"))
        {
            // Apply force towards Player 1
            Vector3 direction = (GetPlayer1Position() - transform.position).normalized;
            rb.AddForce(direction * speedMultiplier, ForceMode.Impulse);
        }
        // Check for collision with ground or walls
        else if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            // Reset the football's position to its initial position
            ResetPosition();
        }
    }

    private Vector3 GetPlayer1Position()
    {
        // Get the position of Player 1
        GameObject player1 = GameObject.FindGameObjectWithTag("player 1");
        if (player1 != null)
        {
            return player1.transform.position;
        }
        return Vector3.zero;
    }

    private Vector3 GetPlayer2Position()
    {
        // Get the position of Player 2
        GameObject player2 = GameObject.FindGameObjectWithTag("player 2");
        if (player2 != null)
        {
            return player2.transform.position;
        }
        return Vector3.zero;
    }

    private void ResetPosition()
    {
        transform.position = initialPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Reset velocity
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Reset angular velocity
    }
}
