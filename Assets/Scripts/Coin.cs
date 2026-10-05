using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    void Update()
    {
        // Rotate the coin
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }

            Destroy(gameObject);
        }
    }
}