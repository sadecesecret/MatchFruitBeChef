using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int levelScores;
    public List<GameObject>wonPizza=new List<GameObject>();
    public List<string> levelNames=new List<string>();
    public List<Sprite> avatars = new List<Sprite>();
    public List<GameObject> isWonAvatar = new List<GameObject>();

    public SpawnManager spawnManager;
   
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public  List<Tuple<Sprite, int>> isWonAvatarUpgraded = new List<Tuple<Sprite, int>>();
    public int nextSortOrder = 0;
    //public GameObject chef;
    public Vector3 position;
   
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
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SpawnHighestCountAvatar(position);
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Restaurant")
        {
            // Restoran sahnesi yüklendi, istediðiniz metodu çaðýrabilirsiniz
            GameManager.Instance.SpawnHighestCountAvatar(position);
        }
    }

    public void SpawnHighestCountAvatar(Vector3 spawnPosition)
    {
        // En büyük initialCount deðerine sahip prefabýn index'ini bul
        int highestCountIndex = FindHighestCountIndex();

        if (highestCountIndex != -1)
        {
            // En büyük initialCount deðerine sahip prefabýn bilgilerini al
            GameObject prefabToInstantiate = spawnManager.avatars[highestCountIndex].prefab;
                   Quaternion spawnRotation = Quaternion.identity;

            // Prefabý sahnede oluþtur
            GameObject instantiatedPrefab = Instantiate(prefabToInstantiate, spawnPosition, spawnRotation);

            Debug.Log("Highest count avatar instantiated!");
        }
        else
        {
            Debug.Log("No avatars found in the SpawnManager!");
        }
    }

    private int FindHighestCountIndex()
    {
        int highestCount = 0;
        int highestCountIndex = -1;
        System.Collections.Generic.List<int> equalCountIndices = new System.Collections.Generic.List<int>();

        for (int i = 0; i < spawnManager.avatars.Length; i++)
        {
            if (spawnManager.avatars[i].initialCount > highestCount)
            {
                highestCount = spawnManager.avatars[i].initialCount;
                highestCountIndex = i;
            }
            else if (spawnManager.avatars[i].initialCount == highestCount)
            {
                // Eþit initialCount deðerine sahip olan prefablarý listeye ekle
                equalCountIndices.Add(i);
            }
        }
        // Eðer eþit initialCount deðerine sahip prefablar varsa, rastgele birini seç
        if (equalCountIndices.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, equalCountIndices.Count);
            highestCountIndex = equalCountIndices[randomIndex];
        }

         

        return highestCountIndex;
    }


    public void AddGameObjectIsWon(GameObject newAvatar)
    {
        isWonAvatar.Add(newAvatar);
    }

  
    

}
