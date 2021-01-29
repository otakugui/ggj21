﻿using System.Collections;
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

    [Header("Lamp Config")]
    public List<LampController> allLamps;

    public int blinkTime; //tempo
    public int blinkTimes; //quantidade de vezes
    public float minIntensity = 0.1f;
    public float maxIntensity = 0.6f;
    public float defaultItensity = 0.9f;

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

            case ClimateState.WINDY:
                Windy();
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
        cam.backgroundColor = skyColor[0];
        particles.SetActive(true);

        foreach(LampController light in allLamps)
        {
            light.Blink();
        }
    }

    void Day()
    {
        cam.backgroundColor = skyColor[1];
        particles.SetActive(false);
    }
}