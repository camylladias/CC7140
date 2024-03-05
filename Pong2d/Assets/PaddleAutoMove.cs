using UnityEngine;

public class PaddleAutoMove : MonoBehaviour
{
    public float speed = 10.0f;
    public float boundY = 2.25f;
    private Rigidbody2D rb2d;
    private bool playerMoved = false; // Indica se o jogador já se moveu
    private float moveDirection = 1; // Direção do movimento da raquete

    // Referência ao Rigidbody da raquete do jogador para detectar movimento
    public Rigidbody2D playerRigidbody;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verifica se o jogador já se moveu
        if (!playerMoved)
        {
            // Considera qualquer movimento vertical como início de jogo
            if (Mathf.Abs(playerRigidbody.velocity.y) > 0.1)
            {
                playerMoved = true;
            }
        }
        else
        {
            MovePaddle();
        }
    }

    void MovePaddle()
    {
        // Movimenta a raquete automaticamente para cima e para baixo
        if (transform.position.y >= boundY)
        {
            moveDirection = -1; // Muda a direção para baixo
        }
        else if (transform.position.y <= -boundY)
        {
            moveDirection = 1; // Muda a direção para cima
        }

        rb2d.velocity = new Vector2(0, moveDirection * speed);
    }
}
