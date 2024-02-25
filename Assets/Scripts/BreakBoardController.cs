using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBoardController : MonoBehaviour
{
    private LevelManager levelInfoProvider; // Level bilgilerini sa�layan script
    public LevelManager[] levelControllers; // Level kontrolc�leri
    public int numberOfObjects;
    public GameObject[] objects;
    
    public List<int>levels=new List<int>();

    private int currentLevelIndex = 1; // Ba�lang�� seviye indeksi

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
        for (int i = 0;i <levelControllers.Length; i++)
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



    public void SelectLevel(int levelIndex)
    {
        currentLevelIndex = levelIndex;
        // Se�ilen seviyede board'� olu�turun
        SpawnBoard(currentLevelIndex);
    }

    void SpawnBoard(int levelIndex)
    {
         currentLevelIndex = levels.Count;

       
        numberOfObjects = currentLevelIndex * numberOfObjects/2;
        // Seviye bilgilerini kullanarak nesneleri spawn et
        for (int i = 0; i < numberOfObjects; i++)
        {
            GameObject selectedPrefab =  objects[Random.Range(0,  objects.Length)];
            Instantiate(selectedPrefab, new Vector3(i,0, 0), Quaternion.identity);
            
        }
    }
}
