using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Floor : MonoBehaviour
{

    public GameObject organisateurGame;
    Script_OrganisateurGame myOrganisateurGame;

    // Start is called before the first frame update
    void Start()
    {
        myOrganisateurGame = organisateurGame.GetComponent<Script_OrganisateurGame>(); //permet d'avoir une référence à mon script_organisateur jeu pour avoir accès à ses fonctions et varibales
    }


    private void OnTriggerEnter(Collider other)
    {
        myOrganisateurGame.LoseLife(); //appel la fonction loselife
    }
}
