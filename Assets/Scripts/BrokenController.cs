using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static BreakableObjects;

public class BrokenController : MonoBehaviour
{
    [HideInInspector]
    public BreakableObjects bObj;
    public int requiredMaterialCount = 0;
    public int maxJuiceCount = 5;
    //private int collectedMaterialCount = 0;
    //public GameObject reqObj, blueberryJuiceObj,strawberryJuiceObj;
    public Transform juice1,juice2;
    public float juiceSpacing = 5f;
    public bool juiceWin;
   public SpawnManager spawnManager;
    
    
    
    public List<GameObject> isWonmaterial=new List<GameObject>();
    public List<GameObject> isWonBlueberry = new List<GameObject>();
    public List<GameObject> isWonStrawberry = new List<GameObject>();
    public List<GameObject> isWonPizza = new List<GameObject>();
    
    private void Awake()
    {
        bObj = FindObjectOfType<BreakableObjects>();
        
    }
    
    private void Update()
    {
        juiceWin = false;
        //int numberOfMaterial = isWonmaterial.Count;

        //if (numberOfMaterial >= requiredMaterialCount )
        //{
        //    //CreatePizza();


        //}
        BlueJuiceSpawn();
        StrawJuiceSpawn();
        
       
    }
    //public void CreatePizza()
    //{
    //    int juiceCount = isWonPizza.Count;
    //    Vector3 spawnPosition = juice1.position;
    //    spawnPosition.x = juice1.position.x + juiceCount * juiceSpacing;
    //    GameObject wonPizza = Instantiate(juiceObj, spawnPosition, Quaternion.identity);
    //    isWonPizza.Add(wonPizza);
    //    isWonmaterial.Clear();
    //    juiceWin = true;
    //    GameManager.Instance.wonPizza.Add(wonPizza);
    //}
   
    public void BlueJuiceSpawn()
    {
        
        // Ýlgili prefab datasýna ulaþmak için önce SpawnManager örneðine ulaþýn
        // Ardýndan, istediðiniz PrefabData öðesine ulaþabilirsiniz.
        if (spawnManager != null && spawnManager.prefabs.Length > 0)
        {
            int bbCount=isWonBlueberry.Count;
            if (bbCount >= requiredMaterialCount)
            {
            SpawnManager.PrefabData targetPrefabData = spawnManager.prefabs[1]; // Örnek olarak ilk prefab'ý seçiyoruz
            int numberOfBlueberry = targetPrefabData.initialCount; // Ýlgili prefab'ýn baþlangýç sayýsýna ulaþýyoruz
            
           
            Vector3 spawnPositionJ=juice1.position; 
            spawnPositionJ.x = juice1.position.x + numberOfBlueberry * juiceSpacing ;
            Instantiate(targetPrefabData.prefab, spawnPositionJ, Quaternion.identity);
             spawnManager.IncreaseInitialCount(1,1);
             isWonBlueberry.Clear();
             juiceWin=true;
                Debug.Log("Prefab blueberry Count: " + numberOfBlueberry);
            }
            
            
        }
    }
    public void StrawJuiceSpawn()
    {

        // Ýlgili prefab datasýna ulaþmak için önce SpawnManager örneðine ulaþýn
        // Ardýndan, istediðiniz PrefabData öðesine ulaþabilirsiniz.
        if (spawnManager != null && spawnManager.prefabs.Length > 0)
        {
            int stCount = isWonStrawberry.Count;
            if (stCount >= requiredMaterialCount)
            {
                SpawnManager.PrefabData targetPrefabData2 = spawnManager.prefabs[5]; // Örnek olarak ilk prefab'ý seçiyoruz
                int numberOfStrawberry = targetPrefabData2.initialCount; // Ýlgili prefab'ýn baþlangýç sayýsýna ulaþýyoruz
                
                
                Vector3 spawnPositionJ = juice2.position;
                spawnPositionJ.x = juice2.position.x + numberOfStrawberry * juiceSpacing;
                Instantiate(targetPrefabData2.prefab, spawnPositionJ, Quaternion.identity);
                spawnManager.IncreaseInitialCount(5, 1);
                isWonStrawberry.Clear();
                juiceWin = true;
                Debug.Log("Prefab strawberry Count: " + numberOfStrawberry);
            }


        }
    }



}
