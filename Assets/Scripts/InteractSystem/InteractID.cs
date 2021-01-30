using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractID : MonoBehaviour
{
    public enum InteractType
    {
        BOOK,
        RALO
    }

    public InteractType type;
    [HideInInspector]public int idInteract;

    public Transform exitRalo;

    private void Start()
    {  
        switch(type)
        {
            case InteractType.BOOK:
                idInteract = 0;
                break;

            case InteractType.RALO:
                idInteract = 1;
                break;
        }
    }
}
