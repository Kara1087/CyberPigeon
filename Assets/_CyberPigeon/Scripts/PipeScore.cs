using UnityEngine;

public class PipeScore : MonoBehaviour
{
    private bool scored = false; // Pour éviter de marquer plusieurs fois le même pipe

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!scored && collision.CompareTag("Player"))
        {

            GameManager.instance.AddScore(1);
            scored = true;
            // Recherche le GameObject avec le tag "GameManager"
            GameObject gmObject = GameObject.FindGameObjectWithTag("GameManager");
            if (gmObject != null)
            {
                // Récupère le composant GameManager sur cet objet
                GameManager gm = gmObject.GetComponent<GameManager>();
                /*if (gm != null)
                {
                    gm.AddScore(1);
                }*/
            }
        }
    }
}