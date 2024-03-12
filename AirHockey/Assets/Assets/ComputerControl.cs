using UnityEngine;

public class ComputerPaddleController : MonoBehaviour
{
    public Transform ball; 
    public float paddleSpeed = 5f;

    public float boundY = 2.25f;

    void Update()
    {
        float targetY = Mathf.MoveTowards(transform.position.y, ball.position.y, paddleSpeed * Time.deltaTime);

        transform.position = new Vector2(transform.position.x, targetY);

        var pos = transform.position;

        if (pos.y > boundY) {
            pos.y = boundY;
        } 
        else if (pos.y < -boundY) {
            pos.y = -boundY;
        }

        transform.position = pos;
        
    }
}
