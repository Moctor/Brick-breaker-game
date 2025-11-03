using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Paddle : MonoBehaviour
{
    
    private Vector3 playerPos = new Vector3 (0,-9.5f,0);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float positionX = transform.position.x + (Input.GetAxis("Mouse X")); //permet d'avoir la position de la souris sur l'axe x
        playerPos = new Vector3(Mathf.Clamp(positionX, -8.0f, 8.0f), -9.5f, 0); //permet de limiter le player pour pas qu'il sorte de la map 
        transform.position = playerPos; //permet a ce que le paddle suive la position de la souris
    }
}
