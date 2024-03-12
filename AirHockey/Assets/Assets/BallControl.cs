using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

	public AudioClip paddleHitSound;
    private AudioSource audioSource; 
    private Rigidbody2D rb2d;

    // Start is called before the first frame update

    void Start(){

        rb2d = GetComponent<Rigidbody2D>();
    	//da o delay pra bolinha ser lançada
        Invoke("GoBall", 2);

		audioSource = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        
    }

    void GoBall(){

		if (paddleHitSound != null)
        {
            audioSource.clip = paddleHitSound; // Define o AudioClip a ser reproduzido
        }
		
    	float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(0.5f, 1f); // Certifique-se de que o valor y seja positivo para evitar movimento para baixo excessivo
        Vector2 force = new Vector2(randX, randY).normalized * 20f; // Normaliza o vetor e multiplica pela força desejada
        rb2d.AddForce(force);
	}

    void OnCollisionEnter2D (Collision2D coll) {
    	if(coll.collider.CompareTag("Player")){
        	Vector2 vel;
        	vel.x = rb2d.velocity.x;
        	vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
        	rb2d.velocity = vel;
    	}

		if (audioSource != null && paddleHitSound != null)
            {
                audioSource.Play(); // Reproduz o som
            }
	}

    void ResetBall(){
    	rb2d.velocity = Vector2.zero;
    	transform.position = Vector2.zero;
	}

	void RestartGame(){
    	ResetBall();
    	Invoke("GoBall", 1);
	}


}
