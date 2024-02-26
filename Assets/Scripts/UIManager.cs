using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Net.NetworkInformation;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;
using JetBrains.Annotations;
using UnityEditorInternal.VersionControl;
using UnityEditor;
using static SpawnManager;


public class UIManager : MonoBehaviour
{
    public TMP_Text timeText, scoreText;
    public TMP_Text hammerText,greetings;
    private Board_Controller theBoard;
    public GameObject roundOverScreen,levelSelectButton;
    public TMP_Text winScore, winText;
    public GameObject winStars1,winStars2,winStars3;
    public string LevelSelect;
    public GameObject pauseScreen;
    public string GetMore;
    public PizzaController pCont;
    string levelName = PizzaController.currentLevelName;
    public Sprite avatar;
    public GameObject myAvatar;
    public Sprite newAvatar;
    public string Restaurant;
    public UnityEngine.UI.Image avatarImage;
    public SpawnManager spawnManager;
    public GameObject currentAvatarPrefab;
    //public IsWonChef isWonChef;
    public ChefListController chefListController;
    public Vector3 spawnChefPoistion;
  





    //public RoundManager roundManager;
    private void Awake()
    {
        theBoard = FindObjectOfType<Board_Controller>();
        pCont = FindObjectOfType<PizzaController>();
        //greetings.gameObject.SetActive(false);
       
       
    }

    // Start is called before the first frame update
    void Start()
    {
        chefListController = FindObjectOfType<ChefListController>();

        //SceneManager.sceneLoaded += OnSceneLoaded;

        winStars1.SetActive(false);
        winStars2.SetActive(false);
        winStars3.SetActive(false);
       
        //chefListController.LoadCheflist();
      





    }
    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (scene.name != "Restaurant")
    //    {
    //        // Restoran sahnesi yüklendi, istediðiniz metodu çaðýrabilirsiniz
    //        GameManager.Instance.SpawnHighestCountAvatar(spawnChefPoistion);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseUnPause();
        }
        Debug.Log("cehf göster");
       
    }
    public void PauseUnPause() 
    {
        if (!pauseScreen.activeInHierarchy)
        { 
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Schuffle() 
    {

        theBoard.ShuffleBoard();
    }
  
    public void GoToLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(LevelSelect);    
        if (SceneManager.GetActiveScene().name==levelName) 
        {
            pCont.PizzaUpdate();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void TryAgain()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
    public void GetMoreLevel()
    {
        SceneManager.LoadScene(GetMore);
    }
    public void GoToRestaurant()
    {
       SceneManager.LoadScene(Restaurant);
    }
    public void ChosenChef   ()
    {
        
        if (pCont.currentCoin > 49 && spawnManager != null )
         {
            pCont.currentCoin -= 50;
            scoreText.text = pCont.currentCoin.ToString();
          int  randomIndex=UnityEngine.Random.Range(0,spawnManager.avatars.Length-1);
            SpawnManager.PrefabData targetrChef = spawnManager.avatars[randomIndex];
            Instantiate(targetrChef.prefab, currentAvatarPrefab.transform.position, Quaternion.identity);
            spawnManager.IncreaseInitialCountAvatars(randomIndex,5);
            //chefListController.AddItem("NewItem", targetrChef.prefab.name, 0);
            //chefListController.SaveCheflist();
          spawnManager.SaveAvatarInitialCounts();
            
        }
        

    }
   
    
   



}

