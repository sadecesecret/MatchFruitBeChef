using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public UnityEngine.UI.Button soundOn, soundDown;
    public string levelToLoad;
    
    private void Start()
    {
        soundOn.gameObject.SetActive(false);
        soundDown.gameObject.SetActive(false);
        UpdateSound();

    }
    public void StartGame() 
    
    { 
        SceneManager.LoadScene(levelToLoad);
    }
    public void QuitGame() 
    {
        Application.Quit();
    }
    public void Settings()
    {
        soundOn.gameObject.SetActive(true);
        soundDown.gameObject.SetActive(true);
    }
    public void OpenSound()
    {
        // Ses durumunu PlayerPrefs ile kaydet (1 olarak)
        PlayerPrefs.SetInt("SoundOn", 1);
        PlayerPrefs.Save();

        // Ses durumuna göre AudioListener'ý ayarla
        UpdateSound();
        Debug.Log("sesgelevek");
    }

    public void CloseSound()
    {
        // Ses durumunu PlayerPrefs ile kaydet (0 olarak)
        PlayerPrefs.SetInt("SoundOn", 0);
        PlayerPrefs.Save();

        // Ses durumuna göre AudioListener'ý ayarla
        UpdateSound();
        Debug.Log("sesgelmeyevek");
    }

    void UpdateSound()
    {
        // PlayerPrefs'ten ses durumunu kontrol et
        int soundState = PlayerPrefs.GetInt("SoundOn", 1);

        // SoundOn deðeri 1 ise sesi aç, 0 ise kapat
        AudioListener.volume = soundState == 1 ? 1 : 0;
    }
}
