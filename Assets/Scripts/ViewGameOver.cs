using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewGameOver : MonoBehaviour
{
    public static ViewGameOver sharedInstance;
    //guardamos la etiqueta de score del canvas
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textMaxScore;

    void Awake()
    {
        sharedInstance = this;
    }
    // Update is called once per frame
    void Update()
    {


    }

    public void UpdateUI()
    {
        if (GameManager.sharedInstance.currentGameStates == GameState.gameOver)
        {
            textCoin.text = GameManager.sharedInstance.collectedCoins.ToString();
            textMaxScore.text = PlayerController.sharedInstance.GetDistance().ToString("f0");
        }
    }
}
