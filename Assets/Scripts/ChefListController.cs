using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChefListController : MonoBehaviour
{
    //public IsWonChef isWonChef;
    //public UIManager uiManager;
    //public SpawnManager spawnManager;

    // Start is called before the first frame update
    //    private void Awake()

    //    {


    //        LoadCheflist();

    //    }
    //    private void Start()
    //    {
    //        //ShowMyChef();
    //    }
    //    public void ShowMyChef()
    //    {


    //        if (isWonChef.ChefList != null && isWonChef.ChefList.Count > 0)
    //        {
    //            string chefPrefabName = isWonChef.ChefList[0].itemPrefabName;
    //            GameObject currentChef = spawnManager.GetPrefabByName(chefPrefabName);
    //            if (currentChef != null)
    //            {
    //                Instantiate(currentChef, transform.position, Quaternion.identity);
    //            }
    //            else
    //            {
    //                Debug.Log("playerprefab bulunamad�");
    //            }



    //        }
    //        else
    //        {
    //            Debug.Log("ChefList bo� veya ChefList[0] null");
    //        }


    //    }
    //    public void SaveCheflist()
    //    {
    //        string data = JsonUtility.ToJson(isWonChef);
    //        PlayerPrefs.SetString("ChefList", data);
    //        Debug.Log("Liste kaydediliyor...");
    //    }
    //    public void LoadCheflist()
    //    {
    //        isWonChef = JsonUtility.FromJson<IsWonChef>(PlayerPrefs.GetString("ChefList"));
    //        Debug.Log("Liste y�kleniyor...");
    //    }

    //    public void AddItem(string itemName, string  itemPrefabName, int itemValue)
    //    {
    //        Item newItem= new Item();
    //        newItem.itemName = itemName;
    //        newItem.itemValue = itemValue;
    //        newItem.itemPrefabName= itemPrefabName;
    //        isWonChef.ChefList.Add(newItem);
    //        SaveCheflist();
    //    }
    //    public void ClearCheflist()
    //    {
    //        isWonChef.ChefList.Clear();
    //        SaveCheflist(); // Listenin g�ncellenmi� halini kaydetmek i�in �a�r� yapabilirsiniz
    //        Debug.Log("ChefList temizlendi.");
    //    }




    //}
    //[System.Serializable]
    //public class IsWonChef
    //{
    //    public List<Item> ChefList = new List<Item>();
    //}
    //[System.Serializable]
    //public class  Item
    //{
    //    public string itemName;
    //    public string itemPrefabName;
    //    public int itemValue;
}


