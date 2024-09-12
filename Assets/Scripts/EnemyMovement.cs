using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public LayerMask groundLayer;
    public GameObject coinPrefab;

    private Rigidbody2D rb;
    private int direction = 1;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        rb.velocity = new Vector2(speed * direction, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            Debug.Log(collision.gameObject.name);
            direction *= -1;
        }
    }

    public void Death()
    {
        Debug.Log("Enemy killed!");
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
