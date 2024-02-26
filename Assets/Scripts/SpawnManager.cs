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
        public string prefabName;

    }

    public PrefabData[] prefabs;
    public PrefabData[] avatars;

    private  string AvatarsInitialCountKey = "AvatarInitialCounts";
    private void Awake()
    {
            LoadAvatarInitialCounts();
        //GameManager.Instance.SpawnHighestCountAvatar(GameManager.Instance.position);
    }
    public void SaveAvatarInitialCounts()
    {
        // Sadece initialCount verilerini sakla
        List<int> initialCounts = new List<int>();
        foreach (var avatar in avatars)
        {
            initialCounts.Add(avatar.initialCount);
        }

        // initialCount verilerini JSON formatýna dönüþtürüp PlayerPrefs üzerinde sakla
        string jsonData = JsonUtility.ToJson(initialCounts);
        PlayerPrefs.SetString(AvatarsInitialCountKey, jsonData);
        PlayerPrefs.Save();
    }
    public void LoadAvatarInitialCounts()
    {
        if (PlayerPrefs.HasKey(AvatarsInitialCountKey))
        {
            // PlayerPrefs'ten initialCount verilerini al ve avatars dizisine uygula
            string jsonData = PlayerPrefs.GetString(AvatarsInitialCountKey);
            List<int> initialCounts = JsonUtility.FromJson<List<int>>(jsonData);

            if (initialCounts != null && initialCounts.Count == avatars.Length)
            {
                for (int i = 0; i < avatars.Length; i++)
                {
                    avatars[i].initialCount = initialCounts[i];
                }
            }
            else
            {
                Debug.LogError("Failed to load avatar initial counts from PlayerPrefs or the data is incomplete!");
            }
        }
    }



    //public GameObject GetPrefabByName(string prefabNameChef)
    //{
    //    foreach (PrefabData data in avatars)
    //    {
    //        if (data.prefabName == prefabNameChef)
    //        {
    //            return data.prefab;
    //        }
    //    }
    //    return null;
    //}
    public void IncreaseInitialCount(int index, int amount)
    {
        if (index >= 0 && index < prefabs.Length)
        {
            prefabs[index].initialCount += amount;
        }
    }
    public void IncreaseInitialCountAvatars(int index, int amount)
    {
        if (index >= 0 && index <avatars.Length)
        {
            avatars[index].initialCount += 5;
            Debug.Log("puankaydedildi");
            
        }
    }






}


