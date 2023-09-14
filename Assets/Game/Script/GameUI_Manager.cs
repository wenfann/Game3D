using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI_Manager : MonoBehaviour
{
    public GameManager GM;
    public TMPro.TextMeshProUGUI CoinText;
    public Slider HealthSlider;
    public GameObject UI_Pause;
    public GameObject UI_GameOver;
    public GameObject UI_GameIsFinished;
    private enum GameUI_State
    {
        GamePlay, Pause, GameOver, GameIsFinished
    }

    GameUI_State currentState;
    void Update()
    {
        HealthSlider.value = GM.playerCharacter.GetComponent<Health>().CurrentHealthPercentage;
        CoinText.text = GM.playerCharacter.Coin.ToString();
    }

    private void SwitchUIState(GameUI_State state)
    {
        UI_Pause.SetActive(false);
        UI_GameOver.SetActive(false);
        UI_GameIsFinished.SetActive(false);

        Time.timeScale = 1;

        switch (state)
        {
            case GameUI_State.GamePlay:
                break;
            case GameUI_State.Pause:
                Time.timeScale = 0;
                UI_Pause.SetActive(true);
                break;
            case GameUI_State.GameOver:
                UI_GameOver.SetActive(true);
                break;
            case GameUI_State.GameIsFinished:
                UI_GameIsFinished.SetActive(true);
                break;
        }

        currentState = state;
    }

    public void TogglePauseUI()
    {
        if (currentState == GameUI_State.GamePlay)
        {
            SwitchUIState(GameUI_State.Pause);
        }
        if (currentState == GameUI_State.Pause)
        {
            SwitchUIState(GameUI_State.GamePlay);
        }
    }
}
