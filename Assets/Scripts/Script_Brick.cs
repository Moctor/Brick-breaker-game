using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Brick : MonoBehaviour
{

    Script_OrganisateurGame myOrganisateurGame;

    // Start is called before the first frame update
    void Start()
    {
        myOrganisateurGame = GameObject.Find("OrganisateurGame").GetComponent<Script_OrganisateurGame>(); //permet d'avoir une référence à mon script_organisateur jeu pour avoir accès à ses fonctions et varibales
    }

    private void OnCollisionEnter(Collision collision)
    {
        myOrganisateurGame.DestroyBricks(); // appel la fonction DestroyBricks
        Destroy(gameObject); // detruit le game object à la collision
    }
}
