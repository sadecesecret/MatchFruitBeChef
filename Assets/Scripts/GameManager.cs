using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int levelScores;
    public List<GameObject>wonPizza=new List<GameObject>();
    public List<string> levelNames=new List<string>();
    public List<Sprite> avatars = new List<Sprite>();
    public List<GameObject> isWonAvatar = new List<GameObject>();

   
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public  List<Tuple<Sprite, int>> isWonAvatarUpgraded = new List<Tuple<Sprite, int>>();
    public int nextSortOrder = 0;

 
    

  public void AddGameObjectIsWon(GameObject newAvatar)
    {
        isWonAvatar.Add(newAvatar);
    }

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    

}
