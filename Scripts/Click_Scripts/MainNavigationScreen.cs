using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainNavigationScreen : MonoBehaviour {

    public GameObject ButtonClicked;
    public GameObject LevelText;

    public string LevelTextString;

    public GameObject Grass;
    public GameObject Desert;
    public GameObject Beach;

    public GameObject GrassSelect;
    public GameObject DesertSelect;
    public GameObject BeachSelect;

    public GameObject[] CurrentButtonGroup;

    public GameObject GrassStageLockScreen;
    public GameObject DesertStageLockScreen;
    public GameObject BeachStageLockScreen;

    public int LevelOnButtonCastToInt;
    public int LevelButtonStage = 0;
    public int LevelToBeLoaded;


    // Use this for initialization
    public void Start()
    {
       
    }




    public void LevelCompletionCheck()
    {
        //Debug.Log("A1");
        CurrentButtonGroup = GameObject.FindGameObjectsWithTag("ButtonGroup");
        //Debug.Log("A2");
        //CurrentButtonGroup[0] = BeachSelect;
        //CurrentButtonGroup[1] = GrassSelect;
        //CurrentButtonGroup[2] = DesertSelect;
        int buttoncounter = 0;
        for (var i = 0; i < CurrentButtonGroup.Length; i++)
        {
            foreach (GameObject child in CurrentButtonGroup)
            {
                int y = 0;
                //Debug.Log("Child A name: " + child.name);

                foreach (Transform grandchild in child.transform)
                {
                   
                    //Debug.Log("Child B name: " + grandchild.name);

                    foreach (Transform grandgrandchild in grandchild)
                    {
                        int x = 0;
                         //if y = 15, no stages completed
                        if (grandgrandchild.name == "LevelNumber")
                        {
                            //Debug.Log("Found Text - X = " + x);
                            LevelTextString = grandchild.transform.GetChild(x).gameObject.GetComponent<Text>().text;
                            int LevelTextInt = 0;
                            int.TryParse(grandchild.transform.GetChild(x).gameObject.GetComponent<Text>().text, out LevelTextInt);
                            //Debug.Log("Level TEXT INT AFTER PARSE:" + LevelTextInt);
                            

                            if (Desert.activeInHierarchy == true)
                            {
                                LevelTextInt = LevelTextInt  - 1;
                            }
                            else if (Beach.activeInHierarchy == true)
                            {
                                LevelTextInt = LevelTextInt + 9;
                            }
                            else if (Grass.activeInHierarchy == true)
                            {
                                LevelTextInt = LevelTextInt + 19;
                            }

                            //Debug.Log("Checking Level - " + LevelTextInt);
                            int LevelStatus = PlayerPrefs.GetInt("Level " + (LevelTextInt) + " Status");


                            if (LevelStatus == 1 || grandchild.transform.name == "DesertLevelSelect (1)")
                            {
                                
                                if (PlayerPrefs.GetInt("Level " + (LevelTextInt + 1) + " Status") == 1)
                                {
                                    //Debug.Log("Level" + LevelTextInt + " has been completed");
                                    float bestgrapplecount = PlayerPrefs.GetFloat("Level " + (LevelTextInt + 1));
                                    grandchild.transform.GetChild(x + 1).gameObject.GetComponent<Text>().text = "Grapples: " + bestgrapplecount;

                                } else
                                {
                                    grandchild.transform.GetChild(x + 1).gameObject.GetComponent<Text>().text = "";
                                }
                            }
                            else
                            {
                                y++;
                                if (grandchild.transform.name != "DesertLevelSelect (1)")
                                {
                                    
                                    grandchild.transform.GetChild(x).gameObject.GetComponent<Text>().text = "LOCKED";
                                    grandchild.transform.gameObject.GetComponent<Button>().interactable = false;
                                    grandchild.transform.GetChild(x+1).gameObject.GetComponent<Text>().text = "";
                                    //Button.interactable = false;
                                }

                                //Debug.Log("Level" + LevelTextString + " has not been completed");
                            }

                            buttoncounter++;

                            //Debug.Log("Y = " + y);

                            if (y == 15 && child.name.Contains("Desert") == false)
                            {
                                
                                if (child.name.Contains("Grass"))
                                {
                                    GrassStageLockScreen.SetActive(true);
                                    BlankOutButtonText();
                                }
                                else if (child.name.Contains("Beach"))
                                {
                                    BeachStageLockScreen.SetActive(true);
                                    BlankOutButtonText();
                                }

                            }
                            else if (buttoncounter == 15)
                            {
                                //disable all lock screens
                                //Debug.Log("Disabled lock screens");
                                GrassStageLockScreen.SetActive(false);
                                DesertStageLockScreen.SetActive(false);
                            }
 
                        }

                        x++;
                    }
                }
            }
        }
       // y = 0;
    }
    
    public void BlankOutButtonText ()
    {
        foreach (GameObject child2 in CurrentButtonGroup)
        {

            foreach (Transform grandchild2 in child2.transform)
            {

                //Debug.Log("Child B name: " + grandchild.name);

                foreach (Transform grandgrandchild2 in grandchild2)
                {
                    int z = 0;
                    //if y = 15, no stages completed
                    if (grandgrandchild2.name == "LevelNumber")
                    {
                        //Debug.Log("Found Text - X = " + x);
                        grandchild2.transform.GetChild(z).gameObject.GetComponent<Text>().text = "LOCKED";
                        grandchild2.transform.GetChild(z + 1).gameObject.GetComponent<Text>().text = "";

                    }
                }
            }
        }
    }

    public void LevelLoadButtonClicked ()
    {
        ButtonClicked = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(ButtonClicked.name);


        if (Desert.activeInHierarchy == true)
        {
            LevelButtonStage = 0;
        }
        else if (Beach.activeInHierarchy == true)
        {
            LevelButtonStage = 10;
        }
        else if (Grass.activeInHierarchy == true)
        {
            LevelButtonStage = 20;
        }

        int i = 0;
        foreach (Transform child in ButtonClicked.transform)
        {
            if (child.name == "LevelNumber")
            {
                //Debug.Log(i);
                LevelText = ButtonClicked.transform.GetChild(i).gameObject;
                //Debug.Log("Found text child...");
            }

            i += 1;
        }

        int.TryParse(LevelText.GetComponent<Text>().text, out LevelOnButtonCastToInt);
        //Debug.Log("Level Number is: " + LevelText.GetComponent<Text>().text);
        LevelToBeLoaded = SceneManager.GetActiveScene().buildIndex + LevelOnButtonCastToInt + LevelButtonStage;
        //Debug.Log("Loading Level: " + LevelToBeLoaded);
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + LevelOnButtonCastToInt + LevelButtonStage));

    }

    public void StageNavigationBack ()
    {
        if (Desert.activeInHierarchy == true)
        {
            //Do Nothing
        }
        else if (Beach.activeInHierarchy == true)
        {
            Desert.SetActive(true);
            Beach.SetActive(false);
            LevelCompletionCheck();
        }
        else if (Grass.activeInHierarchy == true)
        {
            Beach.SetActive(true);
            Grass.SetActive(false);
            LevelCompletionCheck();
        }

       
    }

    public void StageNavigationForwad ()
    {
        
        if (Desert.activeInHierarchy == true)
        {
            Beach.SetActive(true);
            Desert.SetActive(false);
            
           
        }
        else if (Beach.activeInHierarchy == true)
        {
            Grass.SetActive(true);
            Beach.SetActive(false);
            
            
        }
        else if (Grass.activeInHierarchy == true)
        {
            //Do Nothing
        }

        
    }

}
