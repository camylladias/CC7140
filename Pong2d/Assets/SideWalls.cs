using UnityEngine;
using System.Collections;
public class SideWalls : MonoBehaviour {
    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.name == "Ball" || hitInfo.name == "Ball2")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
