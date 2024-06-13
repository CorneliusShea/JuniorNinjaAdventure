using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] Dialog dialogToShow;
    [SerializeField] GameObject interactionBox;

    public Dialog DialogToShow => dialogToShow;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            DialogManager.i.NPCSelected = this; 
            interactionBox.SetActive(true);  
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DialogManager.i.NPCSelected = null;
            DialogManager.i.CloseDialogPanel();
            interactionBox.SetActive(false);
        }

    }


}
