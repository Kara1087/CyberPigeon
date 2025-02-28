using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Instance unique du GameManager (pattern Singleton)
    public static GameManager instance;
    
    // Référence au composant TextMeshProUGUI pour afficher le score (à assigner dans l'Inspector)
    [SerializeField] private TextMeshProUGUI scoreText;
    
    // Référence au panneau Game Over (à assigner dans l'Inspector)
    [SerializeField] private GameObject gameOverScreen;
    
    // Référence au GameObject background (celui qui possède le SpriteRenderer)
    [SerializeField] private GameObject background;
    
    // Variable pour stocker le score
    private int score = 0;

    // Awake est appelé avant Start pour initialiser le Singleton
    private void Awake()
    {
        // S'il y a une instance, et que ce n'est pas moi, supprime-moi.
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }
    
    // Start est appelé avant la première exécution d'Update
    private void Start()
    {
        // Désactive le Game Over Screen au démarrage
        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);
        UpdateScoreText();
    }
    
    
    
    // Met à jour l'affichage du score en convertissant l'entier en chaîne
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
    
    
    
    
    // Méthode publique pour augmenter le score et mettre à jour l'interface
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }
    
    
    
    // Cette méthode est appelée pour déclencher l'état Game Over
    public void GameOver()
    {
            gameOverScreen.SetActive(true);
        
        // Met en pause le jeu en stoppant le temps
        Time.timeScale = 0f;
    }
    
    // Méthode pour redémarrer le jeu
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}