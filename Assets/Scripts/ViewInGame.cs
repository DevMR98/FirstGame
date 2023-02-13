using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;
    //guardamos la etiqueta de score del canvas
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textMaxScore;
     public TextMeshProUGUI textScore;

    void Awake(){
        sharedInstance=this;
    }
    // Update is called once per frame
    void Update()
    {
        //si el GameManager se encuentra en estado inTheGame colocar el valor de las monedas recogidas
        if (GameManager.sharedInstance.currentGameStates==GameState.inTheGame)
        {
            
            //tomamos la distancia obtenida en el metodo la convrtimos a string y f0 para que entregue el dato float sin decimales
            textScore.text=PlayerController.sharedInstance.GetDistance().ToString("f0");
            
        }
    }

    public void UpdateHighScore(){
        if (GameManager.sharedInstance.currentGameStates==GameState.inTheGame){
            textMaxScore.text=PlayerPrefs.GetFloat("highscore",0).ToString("f0");
        }
    }

    public void UpdateCoins(){
         if (GameManager.sharedInstance.currentGameStates==GameState.inTheGame){
            textCoin.text=GameManager.sharedInstance.collectedCoins.ToString();
        }
    }
}
