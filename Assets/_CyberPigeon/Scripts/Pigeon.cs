using UnityEngine;
using System.Collections;

public class Pigeon : MonoBehaviour
{
    // Référence au composant Rigidbody2D attaché au Pigeon.
    // Permet de contrôler la physique (mouvement, collisions, etc.).
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameManager gameManager; // à assigner dans l'Inspector
    private bool isGameOver = false;

    // Force appliquée pour propulser le pigeon vers le haut.
    // [SerializeField] permet de modifier cette valeur dans l'Inspector sans la rendre publique.
    [SerializeField] private float pigeonUpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update est appelée une fois par frame.
    void Update()
    {
        // Si le jeu est terminé, le pigeon ne traite plus les commandes
        if (isGameOver)
        {
            return;
        }
        
        // Vérifie si l'utilisateur appuie sur la touche Espace.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Applique une vitesse vers le haut au Rigidbody2D.
            // La vélocité linéaire est définie sur la direction "up" multipliée par la force définie.
            rb.linearVelocity = Vector2.up * pigeonUpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         
        // Appel dela méthode GameOver via la référence assignée
        GameManager.instance.GameOver();
        if (gameManager != null)
        {
            gameManager.GameOver();
        }

        isGameOver = true;
        // Ici, le pigeon ne sera plus contrôlable et continuera à subir la gravité.
    }
}