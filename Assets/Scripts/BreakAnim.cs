using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BreakAnim : MonoBehaviour
{
    public GetMoreRoundManager moMng;
    public Animator animator;
    public ParticleSystem breakParticle;
   
   
    

    // Start is called before the first frame update
    void Start()
    {
        moMng = FindObjectOfType<GetMoreRoundManager>();
        if (animator != null)
        {
            animator = GetComponent<Animator>();
        }



    }

    // Update is called once per frame
    void Update()
    {
        AnimStop();
        BreakPosition();
       

    }
    public void BreakPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            ParticleSystem particleInstance = Instantiate(breakParticle, mousePosition,Quaternion.identity);
            particleInstance.Play();
            

            transform.position = mousePosition;
            PlayBreakAnimation();
            




        }
    }
    public void PlayBreakAnimation()
    {
        if (animator != null && animator.runtimeAnimatorController != null)
        {
            animator.SetTrigger("BreakAnim");
        }
    }
    public void AnimStop()
    {
        if (moMng.moreRoundTime <= 0) 
        {
            animator.enabled=false;
            Debug.Log("durdur");
        }
    }
   
   
}
