using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    private PlayerController _PlayerController;
    private GameController _GameController;
    private InteractID currentInteractable;

    [HideInInspector]public int idInteract; //passado pelo script InteractID nos objetos interativos
    private bool isInteractable;


    void Start()
    {
        _PlayerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            isInteractable = true;
            //Ativar sinal de interação
            currentInteractable = other.GetComponent<InteractID>();
            idInteract = currentInteractable.idInteract;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInteractable == true)
        {
            Action();
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            isInteractable = false;
        }
    }

    void Action()
    {
        switch(idInteract)
        {
            case 0:
                if (_GameController.ballon.activeSelf == false)
                {
                    _GameController.OpenBallon();

                    _GameController.currentSprites.Clear();
                    foreach (Sprite s in currentInteractable.emotes)
                    {
                        _GameController.currentSprites.Add(s);
                    }

                    _GameController.UpdateEmotes(currentInteractable.qntEmotes);
                }
                else
                {
                    _GameController.CloseBallon();
                }
                break;

            case 1:
                _PlayerController.Teleport(currentInteractable.exitRalo);
                break;
        }
    }

}
