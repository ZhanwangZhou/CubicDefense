using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameOverUI gameOverUI;
    public TextMeshProUGUI lifePointText;
    private int maxLifePoint = 5;
    private int lifePoint;


    private void Start()
    {
        lifePoint = maxLifePoint;
    }
    private void Awake()
    {
        Instance = this;
    }

    public void Fail()
    {
        gameOverUI.Show("Game Over");
        EnemySpawner.Instance.StopSpawn();
    }
    public void Success()
    {
        gameOverUI.Show("Mission Success");
        EnemySpawner.Instance.StopSpawn();
    }

    public void Restart()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void decreaseLifePoint(int amount)
    {
        lifePoint -= amount;
        lifePoint = lifePoint < 0? 0: lifePoint;
        lifePointText.text = lifePoint + " / " + maxLifePoint;
        if(lifePoint == 0) {
            Fail();
        }
    }
}
