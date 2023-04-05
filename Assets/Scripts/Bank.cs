using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{    
     [SerializeField] int startingBalance = 150;
     [SerializeField] int currentBalance;
     public int CurrentBalance { get { return currentBalance; } }

     [SerializeField] TextMeshProUGUI displayBalance;

     void Awake() 
     {
          currentBalance = startingBalance;
          UpdateDisplay();
     }

     void Update() 
     {
          if(currentBalance >= 500)
          {
               LoadWinScene();
          }  
     }

   
     public void Deposit(int amount)
     {
          currentBalance += Mathf.Abs(amount);
          UpdateDisplay();
     }

     public void Withdraw(int amount)
     {
          currentBalance -= Mathf.Abs(amount);
          UpdateDisplay();

          if(currentBalance < 0)
          {
               //Lose the game
               ReloadScene();
          }

          
     }

   void UpdateDisplay()
   {
          displayBalance.text = "Gold: " + currentBalance;
   }

   void ReloadScene()
   {
          Scene currentScene = SceneManager.GetActiveScene();
          SceneManager.LoadScene(currentScene.buildIndex);
   }

   public void LoadWinScene()
   {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }


}
