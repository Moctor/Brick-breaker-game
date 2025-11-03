using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Script_OrganisateurGame : MonoBehaviour
{
    public GameObject paddle; 
    public GameObject bricks;
    public GameObject ball;

    public int countBricks = 30;
    public int lives = 3;
    public static int score;
    public static int highScore;

    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private GameObject clonePaddle;
    private GameObject cloneBricks;
    private GameObject cloneBall;
    public static Script_OrganisateurGame instance = null;



    private void Awake()
    {
        highScoreText.text = "Highscore: " + highScore; //affiche le texte highscore
        scoreText.text = "Score: " + score; //affiche le texte score
        livesText.text = "Lives: " + lives; //affiche le texte lives

        

    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) // si l'instance est null on l'instancie
        {
            instance = this;
        }
        else if (instance != this) // sinon si l'instance n'est pas celle-ci détruit le gameobject
        {
            Destroy(gameObject);
        }
        Setup();
        

    }

    public void Setup() //crée le setup de base de notre scene
    {
        clonePaddle = Instantiate(paddle, new Vector3(transform.position.x + 6.0f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject; // fais apparaitre un clone paddle aux positions du paddle avec + 6 sur l'axe x et la meme rotation en tant que game oject unique
        cloneBricks = Instantiate(bricks, transform.position,Quaternion.identity) as GameObject; // fais apparaitre les briques à leurs positions et rotations
        cloneBall = Instantiate(ball, new Vector3(paddle.transform.position.x, paddle.transform.position.y + 1f, paddle.transform.position.z), Quaternion.identity) as GameObject; // fais apparaitre un clone paddle aux positions du paddle avec + 6 sur l'axe x et la meme rotation en tant que game oject unique

    }

    private void SetupPaddle() // permet de relancer uniquement le paddle et pas toute la scene
    {
        clonePaddle = Instantiate(paddle, new Vector3(transform.position.x + 6.0f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject; // fais apparaitre un clone paddle aux positions du paddle avec + 6 sur l'axe x et la meme rotation en tant que game oject unique
        cloneBall = Instantiate(ball, new Vector3(transform.position.x + 6.0f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject; // fais apparaitre un clone paddle aux positions du paddle avec + 6 sur l'axe x et la meme rotation en tant que game oject unique

    }

    private void SetupBrick()
    {
        cloneBricks = Instantiate(bricks, transform.position, Quaternion.identity) as GameObject; // fais apparaitre les briques à leurs positions et rotations
    }

    public void DestroyBricks() //lorsque qu'une brique est détruite
    {
        countBricks--; // decremente le nombre de briques de 1 quand il y en a une de détruite
        score++; //incremente de 1 le score
        scoreText.text = "Score: " + score; // permet d'actualiser le texte du score

        AllBrickDestroy();
    }

    public void LoseLife() // lorsque l'on perd une vie
    {
        lives--; // decremente le nombre de vie de 1 lorsqu'on perd une  vie (la balle touche le sol)
        livesText.text = "Lives : " + lives; // permet d'actualiser le texte des lifes qui nous restent avec la valeur int de lives
        Destroy(clonePaddle); //détruit le paddle
        SetupPaddle();   // reconstruit le paddle
        CheckGameOver(); //appel la fonction CheckGameOver
    }


    private void Reset() // permet de relancer la scene
    {
        SceneManager.LoadScene("SampleScene"); // reload la scene qui se nomme samplescene
    }

    void CheckGameOver()
    {
        if (lives < 1) // si les lives sont plus petits que 1
        {
            score = 0; // remet le score à 0
            Reset();  //effectue la fonction reset
        }
    }

    void AllBrickDestroy()
    {
        if (countBricks <= 0 ) // check si il n'y a plus de brick
        {
            Destroy(clonePaddle); //detruit le clone paddle
            Destroy(cloneBricks); //detruit le clone bricks
            Destroy(cloneBall); //détruit le clone ball
            SetupPaddle(); // detruit le paddle
            SetupBrick(); // detruit les bricks
            countBricks = 30; //remet le count a 30
            if (lives < 3) //check si il a moins de 3 vies
            {
                lives++; // incremente de 1 son nombre de vie
                livesText.text = "Lives: " + lives; //affiche le texte lives
            }
        }
    }
    private void Update()
    {
        if (score > highScore) // si le score est plus grand que le highscore
        {
            highScore = score; // le highscore devient le score
            highScoreText.text = "Highscore: " + highScore; //actualise le texte du highscore
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // si le bouton esc est pressé 
        {
            Application.Quit(); //quite l'application (le jeu)
        }
    }
}
