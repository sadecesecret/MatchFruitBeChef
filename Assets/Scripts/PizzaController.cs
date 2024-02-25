using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;


public class PizzaController : MonoBehaviour
{
    public GameObject pizza;
    public int pizzaAmount;
    public int AvatorCoin=0;
    public int currentCoin=0;
    
    
    public UIManager uMng;
    public int refillPizza;
    public static string currentLevelName = "Restaurant";
    // Start is called before the first frame update
    void Start()
    {
        pizzaAmount = GameManager.Instance.wonPizza.Count;
        uMng=FindObjectOfType<UIManager>();
        ScoreToCoin();
        uMng.timeText.text = pizzaAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (pizzaAmount >1)
        {
            pizzaAmount--;
            uMng.timeText.text=pizzaAmount.ToString();

            currentCoin = currentCoin + 50;
            uMng.scoreText.text = currentCoin.ToString();

        }
        else if (pizzaAmount <1)
        {
            uMng.hammerText.text = "You don't have enough Pizza.".ToString();
        }
    }
    public void ScoreToCoin()
    {
        currentCoin = GameManager.Instance.levelScores / 100 + GameManager.Instance.wonPizza.Count;
        GameManager.Instance.wonPizza.Clear();
        GameManager.Instance.levelScores = 0;
        uMng.scoreText.text=currentCoin.ToString();
    }
    public void PizzaUpdate()
    {

        refillPizza = currentCoin;
        for (int i= 0; i < refillPizza;i++)
        {
            GameObject refillPizza = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            GameManager.Instance.wonPizza.Add(refillPizza);
        }
             
    }
}
