using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreakableBoardControllerNew : MonoBehaviour
{ 
    public GameObject roundOver;
    private LevelManager levelInfoProvider; // Level bilgilerini saðlayan script
    public LevelManager[] levelControllers; // Level kontrolcüleri
    public int numberOfObjects;
    public GameObject[] objects;
    public GameObject bgTilePrefab;


    public List<int> levels = new List<int>();

    private int currentLevelIndex = 0; // Baþlangýç seviye indeksi

    void Start()
    {
        levelInfoProvider = GetComponent<LevelManager>();
        
    

        // Baþlangýç seviyesinde board'ý oluþturun
        SpawnBoard(currentLevelIndex);

        // Level butonlarýnýn interactable özelliðini güncelle
        GetTotalLevels();
    }

    public int GetTotalLevels()
    {
        for (int i = 0; i < levelControllers.Length; i++)
        {
            if (levelControllers[i] == true)
            {
                levels.Add(i);
            }
        }

        return levels.Count;
    }

    private void LateUpdate()
    {
        GetTotalLevels();

        
    }

    public bool AllObjectsDestroyed()
    {
        GameObject[] remainingObjects = GameObject.FindGameObjectsWithTag("PlayerHit"); // "YourObjectTag" etiketini kullanýn
        return remainingObjects.Length == 0;
        
    }

    void NextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < levels.Count)
        {
            // Bir sonraki seviyede board'ý oluþturun
            SpawnBoard(currentLevelIndex);
        }
        else
        {
            // Tüm seviyeler tamamlandýysa oyunu bitir, istediðiniz diðer iþlemleri yapabilirsiniz.
            Debug.Log("Oyun bitti!");
        }
    }

    

    void SpawnBoard(int levelIndex)
    {
        numberOfObjects=UnityEngine.Random.Range(7,30);
        // Düzenli sýra ile nesnelerin oluþturulmasý
        int rowCount = 6; // Her sýradaki nesne sayýsý
        int columnCount = Mathf.CeilToInt((float)numberOfObjects / rowCount); // Toplam sütun sayýsý

        for (int row = 0; row < rowCount; row++)
        {
            for (int col = 0; col < columnCount; col++)
            {
                int index = row * columnCount + col;
               

                if (index < numberOfObjects)
                {
                    // Nesneleri spawn et
                    GameObject selectedPrefab = objects[Random.Range(0, objects.Length)];
                    Instantiate(selectedPrefab, new Vector3(col * 1.32f, row * 1.2f, 0), Quaternion.identity);
                    Vector3 pos = new Vector3(col * 1.32f, row * 1.2f, 0);
                    GameObject bgTile = Instantiate(bgTilePrefab, pos, Quaternion.identity);
                    bgTile.transform.parent = selectedPrefab.transform;
                    bgTile.name = "BG Tile - " + row + "," + columnCount;
                }
            }
        }
    }
}


