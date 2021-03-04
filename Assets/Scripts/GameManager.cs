using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver,
    gameWinner,
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.inGame;
    
    public Renderer fondo;

    public static GameManager sharedInstance;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.08f, 0) * Time.deltaTime;
            
    }

    
    public void StarGame()
    {

    }

    public void GameWinner()
    {

    }

    public void GameOver()
    {
    
    }

    public void BackToMenu()
    {

    }

    private void SetGameStates(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {
          
        }else if(newGameState == GameState.inGame)
        {

        }else if(newGameState == GameState.gameOver)
        {

        }else if(newGameState == GameState.gameWinner) { 
        }

        this.currentGameState = newGameState;
    }
}
