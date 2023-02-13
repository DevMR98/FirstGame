using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//es como una clase pero es vaga es cmo si fuera un combobox limitadas
public enum GameState
{
    menu,
    inTheGame,
    gameOver
}


public class GameManager : MonoBehaviour
{
    //instancia compartida
    public static GameManager sharedInstance;
    //variable tipo GameStates
    public GameState currentGameStates = GameState.menu;
    //
    public Canvas menuCanvas;
    public Canvas gameCanvas;
    public Canvas gameOver;

    public int collectedCoins=0;


    void Awake()
    {
        //igualando la instancia a la clase
        sharedInstance = this;
    }

    void Start()
    {
        currentGameStates = GameState.menu;
        menuCanvas.enabled=true;
        gameCanvas.enabled=false;
        gameOver.enabled=false;

    }

    void Update(){
        /*
        if(Input.GetButtonDown("s")){
            if(currentGameStates!=GameState.inTheGame){
                StartGame();
            } 
        }
        */
    }

    //use this star the game
    public void StartGame()
    {
        LevelGenerator.sharedInstance.GenerateInitialBlocks();
        PlayerController.sharedInstance.StartGame();
        ChangeGameState(GameState.inTheGame);
        ViewInGame.sharedInstance.UpdateHighScore();


    }

    // When the player die
    public void GameOver()
    {
        LevelGenerator.sharedInstance.RemoveAllTheBlock();
        ChangeGameState(GameState.gameOver);
        ViewGameOver.sharedInstance.UpdateUI();

    }
    //for back the main menu
    public void BackToMainMenu()
    {
        ChangeGameState(GameState.menu);
    }

    //funcion para cambiar los estadods del juego
    void ChangeGameState(GameState newGameState)
    {

        if (newGameState == GameState.menu)
        {
            //la escena de unity debera mostrar el menu principal
            menuCanvas.enabled=true;
            gameCanvas.enabled=false;
            gameOver.enabled=false;
        }
        else if (newGameState == GameState.inTheGame)
        {
            //la escena de unity debera mostrar el juego
            menuCanvas.enabled=false;
            gameCanvas.enabled=true;
            gameOver.enabled=false;

        }
        else if (newGameState == GameState.gameOver)
        {
            //la escena de unity debera mostrar el fin del juego
            menuCanvas.enabled=false;
            gameCanvas.enabled=false;
            gameOver.enabled=true;
        }

        currentGameStates = newGameState;


    }

    public void CollectedCoins(){
        collectedCoins++;
        ViewInGame.sharedInstance.UpdateCoins();
    }
}
