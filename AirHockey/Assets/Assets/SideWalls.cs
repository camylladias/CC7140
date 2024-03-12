using UnityEngine;

public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball" || hitInfo.name == "Ball2")
        {
            string wallName = transform.name;

            // Encontra a instância atual de GameManager no cenário
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                // Chama o método Score() na instância de GameManager encontrada
                gameManager.Score(wallName);
            }

            // Reinicia o jogo na bola que colidiu com a parede
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
