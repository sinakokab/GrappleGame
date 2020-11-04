using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;

public class PauseClick : MonoBehaviour, IPointerDownHandler{

    public GameObject PauseManager;


    public void OnPointerDown(PointerEventData eventData)
    {


        PauseManager.GetComponent<OptionsMenu>().Options_Menu.SetActive(true);

        //if (Advertisement.isShowing == false)//GameStateManager.GetComponent<GameStateManager>().IsAdShowing == false)
        //{
        //    Debug.Log("Paused");
        //    PauseManager.GetComponent<OptionsMenu>().Options_Menu.SetActive(true);
        //}
        //else
        //{
        //    Debug.Log("Cannot pause, ad is playing");
        //}
    }
}
