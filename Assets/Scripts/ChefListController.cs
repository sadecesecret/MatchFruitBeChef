using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefListController : MonoBehaviour
{
    public IsWonChef isWonChef;
    public UIManager uiManager;
    // Start is called before the first frame update
    private void Awake()

    {
       
        LoadCheflist();
      
    }
    private void Start()
    {
        ShowMyChef();
    }
    public void ShowMyChef()
    {

        
           if (isWonChef.ChefList != null && isWonChef.ChefList.Count > 0)
            {
                GameObject currentChef = isWonChef.ChefList[0].itemObject;
                
                Instantiate(currentChef,transform.position, Quaternion.identity);
                Debug.Log("cehf göster");
            }
            else
            {
                Debug.Log("ChefList boþ veya ChefList[0] null");
            }

        
    }
    public void SaveCheflist()
    {
        string data = JsonUtility.ToJson(isWonChef);
        PlayerPrefs.SetString("ChefList", data);
        Debug.Log("Liste kaydediliyor...");
    }
    public void LoadCheflist()
    {
        isWonChef = JsonUtility.FromJson<IsWonChef>(PlayerPrefs.GetString("ChefList"));
        Debug.Log("Liste yükleniyor...");
    }
    public void AddItem(string itemName, GameObject  itemobject, int itemValue)
    {
        Item newItem= new Item();
        newItem.itemName = itemName;
        newItem.itemValue = itemValue;
        newItem.itemObject= itemobject;
        isWonChef.ChefList.Add(newItem);
        SaveCheflist();
    }
}
[System.Serializable]
public class IsWonChef
{
    public List<Item> ChefList = new List<Item>();
}
[System.Serializable]
public class  Item
{
    public string itemName;
    public GameObject itemObject;
    public int itemValue;
}


