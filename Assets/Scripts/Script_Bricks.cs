using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Bricks : MonoBehaviour
{
    public GameObject brick;

    public int longueurGrille = 5;
    public int largeurGrille = 4;

    private void Start()
    {
        for (float i = 0; i <= longueurGrille; i++) //ligne horizontal
        {
            for (float j = 0; j <= largeurGrille; j++) //ligne vertical
            {
               brick = Instantiate(brick, new Vector3(transform.position.x + (2.5f * i), transform.position.y + (1.5f *j), transform.position.z),transform.rotation) as GameObject; // crée les briques sur les axe horizontal et vertical et fais en sorte quelles soient chacune des objet uniques
            }
        }
    }
}
