using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractID : MonoBehaviour
{

    public enum InteractType
    {
        BALLON,
        RALO
    }

    public InteractType type;
    public int qntEmotes;
    public Sprite[] emotes;
    [HideInInspector]public int idInteract;
    [HideInInspector]public int idEmote;

    public Transform exitRalo;

    private void Start()
    {  
        switch(type)
        {
            case InteractType.BALLON:
                idInteract = 0;
                break;

            case InteractType.RALO:
                idInteract = 1;
                break;
        }
    }
}
