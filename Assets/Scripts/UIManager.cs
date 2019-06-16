using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Point Panel")]
    [SerializeField]
    private GameObject textPointPanel;
    [SerializeField]
    private Text textCoin, textCarrot, textPear;

    [Header ("Win UI")]
    [SerializeField]
    private GameObject winUI;

    [Header ("Death UI")]
    [SerializeField]
    private GameObject deathUI;

    [Header ("Pause UI")]
    [SerializeField]
    private GameObject pauseUI;

    public Image pauseSoundImage;


    [Header ("Play UI")]
    [SerializeField]
    private GameObject playUI;
    [SerializeField]
    private Button btnJump;
    [SerializeField]
    private Button btnFire;


    [Header ("UI Manager")]
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    Sprite muteSound, turnOnSound;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        CheckMuteSound();
    }

    public void ShowHomeUI()
    {
        MapManager.instance.currentMap = 1;
        SceneManager.LoadScene("Home");
    }

    //death
    public void ShowDeathUI()
    {
        GameManager.instance.isDead = true;
        SetFruitPoint();
        playerController.DisableCollider();
        StartCoroutine(ActiveCollider());
        playerController.isPlay = false;
        textPointPanel.SetActive(true);
        deathUI.SetActive(true);
    }

    IEnumerator ActiveCollider()
    {
        yield return new WaitForSeconds(1f);
        playerController.EnableCollider();
    }

    public void HideDeathUI()
    {
        Time.timeScale = 1;
        textPointPanel.SetActive(false);
        deathUI.SetActive(false);
    }

    //pause
    public void ShowPauseUI()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void HidePauseUI()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    //win
    public void ShowWinUI()
    {
        winUI.SetActive(true);
        SetFruitPoint();
        textPointPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideWinUI()
    {
        textPointPanel.SetActive(false);
        winUI.SetActive(false);
        Time.timeScale = 1;
    }


    //button sound
    public void PressSound()
    {
        AudioManager.instance.MuteSound();
        AudioManager.instance.isMute = !AudioManager.instance.isMute;
        CheckMuteSound();
    }

    void CheckMuteSound()
    {
        if (AudioManager.instance.isMute)
        {
            pauseSoundImage.sprite = AudioManager.instance.offSound;
        }
        else
        {
            pauseSoundImage.sprite = AudioManager.instance.onSound;
        }
    }

    //disable button jump and fire
    public void DisableJumpAndFire()
    {
        btnJump.interactable = false;
        btnFire.interactable = false;
    }

    //enable button jump and fire
    public void EnableJumpAndFire()
    {
        btnJump.interactable = true;
        btnFire.interactable = true;
    }

    //set point hit fruit to display
    void SetFruitPoint()
    {
        textCoin.text = GameManager.instance.hitCoin.ToString();
        textCarrot.text = GameManager.instance.hitCarrot.ToString();
        textPear.text = GameManager.instance.hitPear.ToString();
    }
}
