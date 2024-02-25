using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreakableBoardControllerNew : MonoBehaviour
{ 
    public GameObject roundOver;
    private LevelManager levelInfoProvider; // Level bilgilerini sa�layan script
    public LevelManager[] levelControllers; // Level kontrolc�leri
    public int numberOfObjects;
    public GameObject[] objects;
    public GameObject bgTilePrefab;


    public List<int> levels = new List<int>();

    private int currentLevelIndex = 0; // Ba�lang�� seviye indeksi

    void Start()
    {
        levelInfoProvider = GetComponent<LevelManager>();
        
    

        // Ba�lang�� seviyesinde board'� olu�turun
        SpawnBoard(currentLevelIndex);

        // Level butonlar�n�n interactable �zelli�ini g�ncelle
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
        GameObject[] remainingObjects = GameObject.FindGameObjectsWithTag("PlayerHit"); // "YourObjectTag" etiketini kullan�n
        return remainingObjects.Length == 0;
        
    }

    void NextLevel()
    {
        currentLevelIndex++;
        if (currentLevelIndex < levels.Count)
        {
            // Bir sonraki seviyede board'� olu�turun
            SpawnBoard(currentLevelIndex);
        }
        else
        {
            // T�m seviyeler tamamland�ysa oyunu bitir, istedi�iniz di�er i�lemleri yapabilirsiniz.
            Debug.Log("Oyun bitti!");
        }
    }

    

    void SpawnBoard(int levelIndex)
    {
        numberOfObjects=UnityEngine.Random.Range(7,30);
        // D�zenli s�ra ile nesnelerin olu�turulmas�
        int rowCount = 6; // Her s�radaki nesne say�s�
        int columnCount = Mathf.CeilToInt((float)numberOfObjects / rowCount); // Toplam s�tun say�s�

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


