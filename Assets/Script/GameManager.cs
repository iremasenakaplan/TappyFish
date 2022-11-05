using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static Vector2 buttonLeft;
   public static bool gameOver;
   public GameObject gameOverPanel;

   private void Awake() 
   {
    buttonLeft=Camera.main.ScreenToWorldPoint(new Vector2(0,0)); //sol alt kose
   }

   public void RestartButton()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

    void Start()
    {
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    void Update()
    {
        
    }
}
