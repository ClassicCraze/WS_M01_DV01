 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
// 1
 using UnityEngine.SceneManagement;
 
 // 2
 public static class Utilities 
 {
     // 3
     public static int playerDeaths = 0;

     // 1
     public static string UpdateDeathCount(ref int countReference)
     {
         // 2
         countReference += 1;
         return "Next time you'll be at number " + countReference;
     }

     // 4
     public static void RestartLevel()
     {
         SceneManager.LoadScene(0);
         Time.timeScale = 1.0f;

         // 3
         Debug.Log("Player deaths: " + playerDeaths);
         string message = UpdateDeathCount(ref playerDeaths);
         Debug.Log("Player deaths: " + playerDeaths);
     }

     // 1
     public static bool RestartLevel(int sceneIndex) 
      {
         // 2
         SceneManager.LoadScene(sceneIndex);
         Time.timeScale = 1.0f;
 
         // 3
         return true;
     }
 }