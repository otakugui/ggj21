using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    GAMEPLAY,
    DIALOG
}
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

    [Header("Máquina de estados")]
    public GameState gameState;
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

    [Header("Dialogo Canvas")]
    public int idAnimal;
    public GameObject ballon;
    public Image bgBallon;
    public Image[] emote;

    public Sprite[] ballons;
    public List<Sprite> currentSprites;

    private void Start()
    {
        cam = Camera.main;
        climate = ClimateState.DEFAULT;
        DefaultClimate();
        ballon.SetActive(false);

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

    #region Climate
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

    #endregion

    public void OpenBallon()
    {
        ballon.SetActive(true);
        bgBallon.sprite = ballons[idAnimal];
        ChangeState(GameState.DIALOG);
    }

    public void CloseBallon()
    {
        ballon.SetActive(false);
        ChangeState(GameState.GAMEPLAY);
    }
    
    void ChangeState(GameState newState)
    {
        gameState = newState;
    }

    public void UpdateEmotes(int qtdEmote)
    {
        print(qtdEmote);
        for(int i = 0; i < qtdEmote; i++)
        {
            print(i);
            emote[i].gameObject.SetActive(true);
            emote[i].sprite = currentSprites[i];
        }
    }
}