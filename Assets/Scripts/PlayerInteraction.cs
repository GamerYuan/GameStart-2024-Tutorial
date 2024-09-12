using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Level complete!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Player died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coins"))
        {
            Debug.Log("Coins collected!");
            score += 50;
            scoreText.text = "Score: " + score;
            Debug.Log("Score: " + score);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Debug.Log("Enemy killed!");
            score += 100;
            scoreText.text = "Score: " + score;
            Debug.Log("Score: " + score);
            Destroy(collision.transform.parent.gameObject);
            playerMovement.Jump();
        }
    }
}
