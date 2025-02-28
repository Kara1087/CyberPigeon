using UnityEngine;
using System.Collections;

public class MovePipe : MonoBehaviour
{
    // Vitesse à laquelle le pipe se déplace vers la gauche.
    [SerializeField]
    private float moveSpeed;

    // Référence au transform de la zone morte (DeadZone) dans la scène.
    // Lorsque le pipe atteint cette zone, il sera détruit.
    private Transform deadZone;

    // Start est appelée une fois au début, avant la première exécution d'Update.
    void Start()
    {
        // Recherche dans la scène le GameObject qui a le tag "DeadZone"
        // et récupère son composant Transform.
        deadZone = GameObject.FindGameObjectWithTag("DeadZone").GetComponent<Transform>();
    }

    // Update est appelée une fois par frame.
    void Update()
    {
        // Déplace le pipe vers la gauche.
        // Time.deltaTime garantit que le déplacement est fluide et indépendant du framerate.
        transform.position += Vector3.left * (Time.deltaTime * moveSpeed);

        // Vérifie si la position x du pipe est inférieure à celle de la deadZone.
        // Cela signifie que le pipe est hors de l'écran (à gauche).
        if (transform.position.x < deadZone.position.x)
        {
            // Détruit le pipe pour libérer les ressources et éviter l'accumulation d'objets hors écran.
            Destroy(gameObject);
        }
    }
}