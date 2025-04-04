using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PuzzleCode puzzleCode;
    
    [Header("UI Elements")]
    [SerializeField] Image staminaBar;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] GameObject gameOverMenuUI;
    [SerializeField] GameObject gameWinMenuUI;
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text collectableCount;
    private float timeCounter;
    private float maxStamina;
    private bool isPaused;
    private bool runTimer = true;
    private int collectableCounter;

    
    // Start is called before the first frame update
    void Start()
    {
        if (player is not null && pauseMenuUI is not null && gameOverMenuUI is not null && gameWinMenuUI is not null)
        {
            maxStamina = player.GetStamina();
            pauseMenuUI.SetActive(false);
            gameOverMenuUI.SetActive(false);
            gameWinMenuUI.SetActive(false);
        }

        collectableCounter = puzzleCode.GetAmountOfCodes();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerStamina();
        PauseMenu();
        PlayerDeadMenu();
        UpdateTimer();
        UpadateCodeCollectableCount();
        
        if(puzzleCode is not null) 
            WinMenu();


    }

    void UpdatePlayerStamina()
    {
        if(staminaBar is not null)
            staminaBar.fillAmount = player.GetStamina() / maxStamina;
    }
    

    void WinMenu()
    {
        if (puzzleCode.GetAmountOfCodes() == 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            gameWinMenuUI.SetActive(true);
        }
    }

    void UpadateCodeCollectableCount()
    {
        collectableCount.text = $"Puzzle Codes: {player.GetCollectableCount()} / {collectableCounter}";
    }
        

    void UpdateTimer()
    {
        if (runTimer == true && timer is not null)
        {
            timeCounter += Time.deltaTime;
            DisplayTime(timeCounter);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float min = Mathf.FloorToInt(timeToDisplay / 60);
        float sec = Mathf.FloorToInt(timeToDisplay % 60);
        timer.text = string.Format("{0:00}:{1:00}", min, sec);
        
    }
    void PauseMenu()
    {
        if (pauseMenuUI is not null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                print("pausing Game");
                if (isPaused)
                {
                    UnpauseGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }

    }
    


    void PlayerDeadMenu()
    {
        if (gameOverMenuUI is not null && player is not null)
        {
            if (player.GetPlayerDead() == true)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                gameOverMenuUI.SetActive(true);
            }
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void UnpauseGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GoToGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    
    public void CloseGame()
    {
        Application.Quit();
    }
}
