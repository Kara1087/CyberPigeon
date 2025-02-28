using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    // Référence au prefab du pipe à instancier.
    // Grâce à [SerializeField], tu peux assigner le prefab dans l'Inspector.
    [SerializeField] private GameObject pipe;

    // Intervalle de temps (en secondes) entre chaque apparition d'un pipe.
    [SerializeField] private float spawnRate = 2;

    // Timer utilisé pour suivre le temps écoulé depuis le dernier spawn.
    private float timer = 0;

    // Décalage vertical pour varier aléatoirement la position de spawn sur l'axe Y.
    [SerializeField] private float heightOffset = 2;

    // Start est appelée une fois au démarrage du script.
    void Start()
    {
        // Instancie immédiatement le premier pipe lors du démarrage.
        SpawnPipe();
    }

    // Update est appelée une fois par frame.
    void Update()
    {
        // Incrémente le timer avec le temps écoulé depuis la dernière frame.
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Une fois que le temps écoulé atteint spawnRate, on instancie un nouveau pipe.
            SpawnPipe();
            // On réinitialise le timer.
            timer = 0;
        }
    }

    // Méthode pour instancier un pipe à une position aléatoire sur l'axe Y.
    private void SpawnPipe()
    {
        // Calcul du point le plus bas et le plus haut de spawn autour de la position du spawner.
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        
        // Détermination d'une position aléatoire sur l'axe Y tout en conservant la position X et Z du spawner.
        Vector3 randomPosition = new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z);
        
        // Instanciation du prefab pipe à la position calculée avec une rotation par défaut (Quaternion.identity).
        Instantiate(pipe, randomPosition, Quaternion.identity);
    }
}