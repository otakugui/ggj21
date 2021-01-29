using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClimateState
{
    DEFAULT,
    RAINING,
    WINDY,
    DAY
}

public class GameController : MonoBehaviour
{
    private Camera cam;

    public ClimateState climate;
    public GameObject particles;
    public Color[] skyColor; //muda a cor da camera no modo solid color

    public List<LampController> allLamps;

    private void Start()
    {
        cam = Camera.main;
        climate = ClimateState.DEFAULT;
        DefaultClimate();

        foreach(LampController lamp in FindObjectsOfType(typeof(LampController)) as LampController[])
        {
            allLamps.Add(lamp);
        }
        
    }
    private void Update()
    {
        switch(climate)
        {
            case ClimateState.DEFAULT:
                DefaultClimate();
                break;

            case ClimateState.RAINING:
                Raining();
                break;

            case ClimateState.DAY:
                Day();
                break;
        }
    }

    void DefaultClimate()
    {
        cam.backgroundColor = skyColor[0];
        particles.SetActive(false);
    }

    void Raining()
    {
        cam.backgroundColor = skyColor[0];
        particles.SetActive(true);
    }

    void Windy()
    {

    }

    void Day()
    {
        cam.backgroundColor = skyColor[1];
        particles.SetActive(false);
    }
}