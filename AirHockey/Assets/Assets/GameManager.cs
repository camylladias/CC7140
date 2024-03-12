using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerScore1 = 0;
    public int PlayerScore2 = 0;
    public AudioSource pointScoredSound;
    public GUISkin layout;
    GameObject theBall;
    GameObject theBall2;
    public float initialBallSpeed = 5f; // Velocidade inicial da bola
    public float speedIncrement = 1f; // Incremento de velocidade após alcançar 5 pontos
    public float currentBallSpeed; // Velocidade atual da bola

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        theBall2 = GameObject.FindGameObjectWithTag("Ball2");
        currentBallSpeed = initialBallSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore1++;
            // Reproduzir som de ponto marcado
            pointScoredSound.Play();
        }
        else
        {
            PlayerScore2++;
            // Reproduzir som de ponto marcado
            pointScoredSound.Play();
        }

        // Verifica se um jogador alcançou 5 pontos e aumenta a velocidade da bola
        if (PlayerScore1 >= 2 || PlayerScore2 >= 2)
        {
            currentBallSpeed += speedIncrement;
            // Se desejar, você pode adicionar limites para a velocidade máxima da bola aqui
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            if (theBall != null)
            {
                theBall.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            }

            if (theBall2 != null)
            {
                theBall2.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
            }
        }

        if (PlayerScore1 == 6)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            if (theBall != null)
            {
                theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }

            if (theBall2 != null)
            {
                theBall2.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
}

        else if (PlayerScore2 == 6)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            if (theBall != null)
            {
                theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }

            if (theBall2 != null)
            {
                theBall2.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
        }

    }
}
