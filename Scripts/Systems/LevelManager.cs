using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

   [SerializeField] float sceneLoadDelay = 2f;
   ScoreKeeper scorekeeper;
   SpecialTracker specialTracker;
   CogsCounter cogsCounter;



   void Awake()
   {
   scorekeeper = FindObjectOfType<ScoreKeeper>();
   specialTracker = FindObjectOfType<SpecialTracker>();
   cogsCounter = FindObjectOfType<CogsCounter>();
   }
   
   public void LoadGame()
   {
      SceneManager.LoadScene("GamePlayScene");
      scorekeeper.ResetScore();
      specialTracker.ResetSpecial();
      cogsCounter.ResetCogs();
      
   }


   public void LoadMainMenu()
   {
   SceneManager.LoadScene("MainMenu");
   }
   
   
   public void LoadGameOver()
   {
   StartCoroutine(WaitAndLoad("GameOverScene", sceneLoadDelay));
   }
   
   
   public void QuitGame()
   {
   Debug.Log("Quiting game");
   Application.Quit();
   }
   
   
   IEnumerator WaitAndLoad(string sceneName, float delay)
   {
   yield return new WaitForSeconds(delay);
   SceneManager.LoadScene(sceneName);
   }
}
