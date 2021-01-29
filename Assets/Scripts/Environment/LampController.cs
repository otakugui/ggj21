using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    //meu pc batata n roda sem isso, depois pode tirar isso do prefab.
    private Light luz;
    
    void Start()
    {
        luz = GetComponentInChildren<Light>();
        luz.enabled = false;
    }

    private void OnBecameVisible()
    {
        luz.enabled = true;
    }

    private void OnBecameInvisible()
    {
        luz.enabled = false;
    }
}
