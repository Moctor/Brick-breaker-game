using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Ball : MonoBehaviour
{
    public float ballInitialVelocity = 600.0f;

    private Rigidbody rb;
    private bool ballInPlay;
    private Vector3 playerPos = new Vector3(0, -8.3f, 0);
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //fais le lien entre le script et le rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
        if(Input.GetButtonDown("Fire1") && ballInPlay == false) // si j'appuie sur le bouton de la souris et que il n'y a pas de ball en jeu 
        {
            transform.parent = null; //remet le paddle et la balle a son point de départ
            ballInPlay = true; // on dit que la balle est en jeu
            rb.isKinematic = false; // on retire la balle de l'état kinematic afin que le moteur physique d'unity s'applique sur la balle
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity,0)); // on ajoute une force sur l'axe x et y
        }
    }

    void Deplacement()
    {
        if(ballInPlay == false)
        {
            float positionX = transform.position.x + (Input.GetAxis("Mouse X")); //permet d'avoir la position de la souris sur l'axe x
            playerPos = new Vector3(Mathf.Clamp(positionX, -8.0f, 8.0f), -8.3f, 0); //permet de limiter le player pour pas qu'il sorte de la map 
            transform.position = playerPos; //permet a ce que le paddle suive la position de la souris
        }
    }
}
