using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    public enum BreakableType { Ice, Can }
    public BreakableType brType;
    public BrokenController bro;    
    public int breakCount = 0;
    public int currentBreakCount = 0;
    public bool isBroken = false;
    public GameObject materialPrefab;
    


    private void Awake()
    {
        bro = FindObjectOfType<BrokenController>();
       

    }
   

    private void OnMouseDown()
    {
        currentBreakCount++;
       

        if (currentBreakCount >= breakCount)
        {
            isBroken = true;
            StartCoroutine(DestroyGameObject());
            //WinMaterial(materialPrefab);
            WinBlueberry(materialPrefab);
            WinStrawberry(materialPrefab);
            
            SFXManager.instance.IceBreak();
        }
                
    }
   

    private IEnumerator DestroyGameObject()
    {
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
        //gameObject.SetActive(false);

    }
    public void WinBlueberry(GameObject prefab)
    {
        if (materialPrefab.name=="Fruit_Blue_1") 
        { 
            GameObject wonBlue=Instantiate(materialPrefab, transform.position, Quaternion.identity);
            bro.isWonBlueberry.Add(wonBlue);
            
        }
    }
    public void WinStrawberry(GameObject prefab)
    {
        if (materialPrefab.name == "Fruit_Red_1")
        {
            GameObject wonStraw = Instantiate(materialPrefab, transform.position, Quaternion.identity);
            bro.isWonStrawberry.Add(wonStraw);
           
        }
    }
   

}
