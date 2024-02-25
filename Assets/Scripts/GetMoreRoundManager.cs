using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetMoreRoundManager : MonoBehaviour
{
    public float moreRoundTime = 60f;
    public UIManager uiMng;
    public BrokenController brokenController;
    public BreakableBoardControllerNew boardC;
    public RoundManager roundManager;
  
    public int pizzaScore=0;
    public int currentScore;
    public int pizzaBonus = 1000;
    public int objectBonus = 100;
    public int maxNumber = int.MinValue;
   




    // Start is called before the first frame update
    private void Awake()
    {
            uiMng = FindObjectOfType<UIManager>(); 
        brokenController=FindObjectOfType<BrokenController>();
        roundManager=FindObjectOfType<RoundManager>();
      
        moreRoundTime = UnityEngine.Random.Range(10, 50);
        boardC=FindObjectOfType<BreakableBoardControllerNew>();

    }
    public void TimeController()
    {
        
       
            if (moreRoundTime > 0)
            {
            moreRoundTime -= Time.deltaTime;
                if (moreRoundTime <= 0 )
                {
                    moreRoundTime = 0;
                    //roundManager.WinCheck();
                    uiMng.roundOverScreen.SetActive(true);

                    //uiMng.roundOverScreen.SetActive(true);
                    uiMng.winScore.text=currentScore.ToString();

                    


                }
             }
            if (boardC.AllObjectsDestroyed())
            {
            moreRoundTime = 0;
            //roundManager.WinCheck();
            uiMng.roundOverScreen.SetActive(true);
            uiMng.winScore.text = currentScore.ToString();
        }
        uiMng.timeText.text = moreRoundTime.ToString("0.0") + "s";
    }
    
    // Update is called once per frame
    void Update()
    {
        TimeController();
        PizzaBonus();
       
    }
    public void PizzaBonus()
    {
        if(brokenController.juiceWin) 
        {
            Debug.Log("pizzabonus");
            currentScore=currentScore+pizzaBonus+3*objectBonus;
            uiMng.scoreText.text = currentScore.ToString();
            uiMng.hammerText.text = "".ToString();
            GameManager.Instance.levelScores=(currentScore);

        }
    }

   
   
}
