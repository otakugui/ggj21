using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    //meu pc batata n roda sem isso, depois pode tirar isso do prefab.
    private GameController _GameController;

    private Light luz;
    private bool isStartBlink;

    void Start()
    {
        _GameController = FindObjectOfType(typeof(GameController)) as GameController;
        luz = GetComponentInChildren<Light>();
        luz.enabled = false;
    }

    private void Update()
    {
        if(_GameController.climate != ClimateState.WINDY)
        {
            StopCoroutine("BlinkTimes");
        }
    }

    private void OnBecameVisible()
    {
        luz.enabled = true;
    }

    private void OnBecameInvisible()
    {
        luz.enabled = false;
    }

    public void Blink()
    {
        isStartBlink = true;
        StartCoroutine("BlinkTimes");
    }

    IEnumerator BlinkTimes()
    {
        for(int i = 0; i <= _GameController.blinkTimes; i++)
        {
            luz.intensity = Random.Range(_GameController.minIntensity, _GameController.maxIntensity);
            yield return new WaitForSeconds(_GameController.blinkTime);
        }

        luz.intensity = _GameController.defaultItensity;
        isStartBlink = false;
    }
}
