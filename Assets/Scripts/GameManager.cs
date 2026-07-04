using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0;
    public float timeLeft = 60f;

    public TMP_Text scoreText;
    public TMP_Text timeText;
    public GameObject finalPanel;
    public TMP_Text finalScoreText;

    private bool gameEnded = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        finalPanel.SetActive(false);
        UpdateUI();
    }

    private void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            EndGame();
        }

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        if (gameEnded) return;

        score += amount;
        UpdateUI();
    }

    public void EndGame()
    {
        gameEnded = true;
        finalPanel.SetActive(true);
        finalScoreText.text = "Pontuação final: " + score;
    }

    private void UpdateUI()
    {
        scoreText.text = "Pontos: " + score;
        timeText.text = "Tempo: " + Mathf.CeilToInt(timeLeft);
    }
}