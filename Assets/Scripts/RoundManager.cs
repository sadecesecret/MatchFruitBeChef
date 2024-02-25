using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public float roundTime = 60f;
    private UIManager uiMan;
    private bool endingRound = false;
    private Board_Controller board;
    public int currentScore;
    public float displayScore;
    public float scoreSpeed;
    public int scoreTarget1, scoreTarget2, scoreTarget3;
    public LevelManager levelManager;
    public GetMoreRoundManager getMore;
    public string getMoreLevel;
    private void Awake()
    {
            uiMan=FindObjectOfType<UIManager>();
        board= FindObjectOfType<Board_Controller>();
        levelManager = FindObjectOfType<LevelManager>();
        getMore= FindObjectOfType<GetMoreRoundManager>();   
        if (SceneManager.GetActiveScene().name == getMoreLevel)
        {
            roundTime = getMore.moreRoundTime;
        }
       

        
    }
    
    // Update is called once per frame
    void Update()
    {
       if (roundTime > 0)
        {
            roundTime-= Time.deltaTime;
            if (roundTime <=0)
            {
                roundTime=0;
                
                endingRound = true;
                

            }
        }

        if (endingRound && board.currentState==Board_Controller.BoardState.move)
        {
            WinCheck();
            endingRound = false;
            Debug.Log("bitiþekranýçalýþstý");
        }

        uiMan.timeText.text=roundTime.ToString("0.0") + "s";
        displayScore=Mathf.Lerp(displayScore,currentScore,scoreSpeed*Time.deltaTime);
        uiMan.scoreText.text = displayScore.ToString("0");


    }
    

    public void WinCheck()
    {
        Debug.Log("wincheckcalisti");

        uiMan.roundOverScreen.SetActive(true);
        uiMan.winScore.text = currentScore.ToString();
        if (currentScore >=scoreTarget3)
        {
            uiMan.winText.text = "Congratulations! ";
            uiMan.winStars1.SetActive(true);
            uiMan.winStars3.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name+"_Star1", 1);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star3", 2);
            uiMan.levelSelectButton.SetActive(true);
                    
        }
        else if (currentScore >= scoreTarget2)
        {
            uiMan.winText.text = "Congratulations! ";
            uiMan.winStars2.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star2", 2);
            uiMan.levelSelectButton.SetActive(true);

        }
        else if (currentScore >= scoreTarget1)
        {
            uiMan.winText.text = "Congratulations! ";
            uiMan.winStars1.SetActive(true);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_Star1", 1);
            uiMan.levelSelectButton.SetActive(false);
        }
        else
        {
            uiMan.winText.text = "Oh no!No stars for you!Try again?";
            uiMan.levelSelectButton.SetActive(false);
        }
        SFXManager.instance.PlayRoundOver();
        
    }
}
