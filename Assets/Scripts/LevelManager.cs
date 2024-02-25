using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public Button level1Button, level2Button, level3Button, level4Button,level5Button,level6Button,level7Button,level8Button,level9Button,level10Button, level11Button;
    public Button level12Button, level13Button, level14Button, level15Button, level16Button, level17Button, level18Button, level19Button,level20Button;
    public static bool levelController1, levelController2,levelController3,levelController4, levelController5,levelController6, levelController7,levelController8,levelController9, levelController10;
    public static bool levelController11, levelController12, levelController13, levelController14, levelController15, levelController16, levelController17, levelController18, levelController19, levelController20;
    public Button[] levelButtons;
    public bool[] levelControllers;
    private void Awake()
    {
        levelController1 =true;
    }
    void Start()
    {
        //level1Controller = true;
        levelButtons = new Button[]
       {
            level1Button,
            level2Button,
            level3Button,
            level4Button,
            level5Button,
            level6Button,
            level7Button,
            level8Button,
            level9Button,
            level10Button,
            level11Button,
            level12Button,
            level13Button,
            level14Button,
            level15Button,
            level16Button,
            level17Button,
            level18Button,
            level19Button,
            level20Button,
        };

        levelControllers = new bool[]
        {
            levelController1,
            levelController2,
            levelController3,
            levelController4,
            levelController5,
            levelController6,
            levelController7,
            levelController8,
            levelController9,
            levelController10,
            levelController11,
            levelController12,
            levelController13,
            levelController14,
            levelController15,
            levelController16,
            levelController17,
            levelController18,
            levelController19,
            levelController20,
        };

        UpdateLevelButtons();
    }
    public void UpdateLevelButtons()
    {
        for (int i = 0; i < levelControllers.Length; i++)
        {
            if (levelControllers[i] == true)
            {
                levelButtons[i].interactable = true;
            }
        }
    }
    // Update is called once per frame
   
}
