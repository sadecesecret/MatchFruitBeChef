using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using static SpawnManager;

[CreateAssetMenu(fileName = "SpawnManager", menuName = "ScriptableObjects/SpawnManager", order = 1)]
public class SpawnManager : ScriptableObject
{
    [System.Serializable]
    public struct PrefabData
    {
        public GameObject prefab;
        public int initialCount;

    }

    public PrefabData[] prefabs;
    public PrefabData[] avatars;
   
   
    public void IncreaseInitialCount(int index, int amount)
    {
        if (index >= 0 && index < prefabs.Length)
        {
            prefabs[index].initialCount += amount;
        }
    }
  

 
    


}


