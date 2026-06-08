using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Health")]
    public int maxHealth = 3;
    public int currentHealth;
    public Image[] healthIcons;

    [Header("Score")]
    public int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Audio")]
    public AudioClip explosionSound;
    public AudioClip playerDeathSound;
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        UpdateScoreUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    public void TakeHit()
    {
        currentHealth--;
        UpdateHealthUI();
        if (currentHealth <= 0)
            GameOver();
    }

    public void GameOver()
    {
        PlayPlayerDeathSound();
        Invoke("RestartGame", 2f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlayExplosionSound()
    {
        if (explosionSound != null)
            audioSource.PlayOneShot(explosionSound);
    }

    public void PlayPlayerDeathSound()
    {
        if (playerDeathSound != null)
            audioSource.PlayOneShot(playerDeathSound);
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            healthIcons[i].enabled = i < currentHealth;
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}