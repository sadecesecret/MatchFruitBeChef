using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance; 
    public AudioSource gemSound, explodeSound, stoneSound, roundOverSound;
    public AudioSource breakIce;
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
   

    public void PlayGemBreak()
    {
        gemSound.Stop();

        gemSound.pitch = Random. Range(.8f,1.2f);

        gemSound.Play(); 
    }
    public void PlayExplode()
    {
        explodeSound.Stop();

        explodeSound.pitch = Random.Range(.8f, 1.2f);

        explodeSound.Play();
    }
    public void PlayStoneBreak()
    {
        stoneSound.Stop();

        stoneSound.pitch = Random.Range(.8f, 1.2f);

        stoneSound.Play();
    }
    public void PlayRoundOver()
    {
        roundOverSound.Play();
    }
    public void IceBreak()
    {
          
        breakIce.Play();
    }
    
}
