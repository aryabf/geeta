using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenuAnimation : MonoBehaviour
{

    // Main Menu
    public Image playButton;
    public Image upgradeButton;
    public Image settingsButton;
    public Image creditsButton;
    public Image quitButton;
    public TMP_Text title;
    public GameObject geetaAndFriends;

    // Select Weapon
    public GameObject geetaFrame;
    public GameObject weaponFrame;
    public TMP_Text selectWPText;
    public GameObject violinButton;
    public GameObject harpButton;
    public GameObject saxButton;
    public GameObject guitarButton;
    public GameObject fluteButton;
    public GameObject gendangButton;
    public Image selectButton;
    public Image backSelectButton;

    // Select Stage
    public Image middlePink;
    public TMP_Text selectStageText;
    public GameObject selectStage;
    public GameObject selectLevel;
    public Button startButton;
    public Button backStageButton;

    // private RectTransform playButtonTf;
    // private RectTransform upgradeButtonTf;
    // private RectTransform settingsButtonTf;
    // private RectTransform creditsButtonTf;
    // private RectTransform quitButtonTf;

    // private RectTransform titleTf;
    // private RectTransform geetaTf;

    // private Vector3 playStartPos;
    // private Vector3 upgradeStartPos;
    // private Vector3 settingsStartPos;
    // private Vector3 creditsStartPos;
    // private Vector3 quitStartPos;

    // private Vector3 titleStartPos;
    // private Vector3 geetaStartPos;

    // private bool allowPlayMove = false;
    // private bool allowUpgradeMove = false;
    // private bool allowSettingsMove = false;
    // private bool allowCreditsMove = false;
    // private bool allowQuitMove = false;
    // private bool allowTitleMove = false;
    // private bool allowGeetaMove = false;

    // private float moveSpeed = 800f;

    private bool allowPress = true;

    private GOCust playButtonObj;
    private GOCust upgradeButtonObj;
    private GOCust settingsButtonObj;
    private GOCust creditsButtonObj;
    private GOCust quitButtonObj;
    private GOCust titleObj;
    private GOCust geetaObj;

    private GOCust geetaFrameObj;
    private GOCust weaponFrameObj;
    private GOCust selectWPTextObj;
    private GOCust violinButtonObj;
    private GOCust harpButtonObj;
    private GOCust saxButtonObj;
    private GOCust guitarButtonObj;
    private GOCust fluteButtonObj;
    private GOCust gendangButtonObj;
    private GOCust selectButtonObj;
    private GOCust backSelectButtonObj;

    private GOCust middlePinkObj;
    private GOCust selectStageTextObj;
    private GOCust selectStageObj;
    private GOCust selectLevelObj;
    private GOCust startButtonObj;
    private GOCust backStageButtonObj;

    public AudioSource buttonPress;

    public Image gambarStage;
    public Sprite[] spriteStage;

    public TMP_Text stageText;
    public TMP_Text startText;

    public GameObject stageLock;

    public TMP_Text levelValue;

    public GameObject levelLock;

    private int index;
    private int level = 1;

    private string[] initData = {"0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0",};
    private string[] currentData;

    // Start is called before the first frame update
    void Start()
    {

        allowPress = false;

        if (!File.Exists("geetadata.txt")) {
            File.Create("geetadata.txt").Close();
            File.WriteAllLines("geetadata.txt", initData);
        }
        currentData = File.ReadAllLines("geetadata.txt");

        Time.timeScale = 1f;

        playButtonObj = new GOCust(playButton);
        upgradeButtonObj = new GOCust(upgradeButton);
        settingsButtonObj = new GOCust(settingsButton);
        creditsButtonObj = new GOCust(creditsButton);
        quitButtonObj = new GOCust(quitButton);
        titleObj = new GOCust(title);
        geetaObj = new GOCust(geetaAndFriends);

        geetaFrameObj = new GOCust(geetaFrame);
        weaponFrameObj = new GOCust(weaponFrame);
        selectWPTextObj = new GOCust(selectWPText);
        violinButtonObj = new GOCust(violinButton);
        harpButtonObj = new GOCust(harpButton);
        saxButtonObj = new GOCust(saxButton);
        guitarButtonObj = new GOCust(guitarButton);
        fluteButtonObj = new GOCust(fluteButton);
        gendangButtonObj = new GOCust(gendangButton);
        selectButtonObj = new GOCust(selectButton);
        backSelectButtonObj = new GOCust(backSelectButton);

        middlePinkObj = new GOCust(middlePink);
        selectStageTextObj = new GOCust(selectStageText);
        selectStageObj = new GOCust(selectStage);
        selectLevelObj = new GOCust(selectLevel);
        startButtonObj = new GOCust(startButton);
        backStageButtonObj = new GOCust(backStageButton);

        // playStartPos = playButtonTf.position;
        // upgradeStartPos = upgradeButtonTf.position;
        // settingsStartPos = settingsButtonTf.position;
        // creditsStartPos = creditsButtonTf.position;
        // quitStartPos = creditsButtonTf.position;
        // geetaStartPos = geetaTf.position;
        // titleStartPos = titleTf.position;

        playButtonObj.rt.position += new Vector3(400, 0, 0); playButtonObj.offScreenPos = playButtonObj.rt.position;
        upgradeButtonObj.rt.position += new Vector3(400, 0, 0); upgradeButtonObj.offScreenPos = upgradeButtonObj.rt.position;
        settingsButtonObj.rt.position += new Vector3(400, 0, 0); settingsButtonObj.offScreenPos = settingsButtonObj.rt.position;
        creditsButtonObj.rt.position += new Vector3(400, 0, 0); creditsButtonObj.offScreenPos = creditsButtonObj.rt.position;
        quitButtonObj.rt.position += new Vector3(400, 0, 0); quitButtonObj.offScreenPos = quitButtonObj.rt.position;
        titleObj.rt.position += new Vector3(0, 400, 0); titleObj.offScreenPos = titleObj.rt.position;
        geetaObj.rt.position += new Vector3(0, -400, 0); geetaObj.offScreenPos = geetaObj.rt.position;

        geetaFrameObj.rt.position += new Vector3(-600, 0, 0); geetaFrameObj.offScreenPos = geetaFrameObj.rt.position;
        weaponFrameObj.rt.position += new Vector3(600, 0, 0); weaponFrameObj.offScreenPos = weaponFrameObj.rt.position;
        selectWPTextObj.rt.position += new Vector3(0, 400, 0); selectWPTextObj.offScreenPos = selectWPTextObj.rt.position;
        violinButtonObj.rt.position += new Vector3(0, 400, 0); violinButtonObj.offScreenPos = violinButtonObj.rt.position;
        harpButtonObj.rt.position += new Vector3(0, 400, 0); harpButtonObj.offScreenPos = harpButtonObj.rt.position;
        saxButtonObj.rt.position += new Vector3(0, 400, 0); saxButtonObj.offScreenPos = saxButtonObj.rt.position;
        guitarButtonObj.rt.position += new Vector3(0, -400, 0); guitarButtonObj.offScreenPos = guitarButtonObj.rt.position;
        fluteButtonObj.rt.position += new Vector3(0, -400, 0); fluteButtonObj.offScreenPos = fluteButtonObj.rt.position;
        gendangButtonObj.rt.position += new Vector3(0, -400, 0); gendangButtonObj.offScreenPos = gendangButtonObj.rt.position;
        selectButtonObj.rt.position += new Vector3(0, -400, 0); selectButtonObj.offScreenPos = selectButtonObj.rt.position;
        backSelectButtonObj.rt.position += new Vector3(0, -400, 0); backSelectButtonObj.offScreenPos = backSelectButtonObj.rt.position;

        middlePinkObj.rt.position += new Vector3(0, 800, 0); middlePinkObj.offScreenPos = backSelectButtonObj.rt.position;
        selectStageTextObj.rt.position += new Vector3(0, 400, 0); selectStageTextObj.offScreenPos = selectStageTextObj.rt.position;
        selectStageObj.rt.position += new Vector3(0, 400, 0); selectStageObj.offScreenPos = selectStageObj.rt.position;
        selectLevelObj.rt.position += new Vector3(0, -400, 0); selectLevelObj.offScreenPos = selectLevelObj.rt.position;
        startButtonObj.rt.position += new Vector3(0, -400, 0); startButtonObj.offScreenPos = startButtonObj.rt.position;
        backStageButtonObj.rt.position += new Vector3(0, -400, 0); backStageButtonObj.offScreenPos = backStageButtonObj.rt.position;
        // playButtonTf.position = playButtonTf.position + new Vector3(400, 0, 0);
        // upgradeButtonTf.position = upgradeButtonTf.position + new Vector3(400, 0, 0);
        // settingsButtonTf.position = settingsButtonTf.position + new Vector3(400, 0, 0);
        // creditsButtonTf.position = creditsButtonTf.position + new Vector3(400, 0, 0);
        // quitButtonTf.position = quitButtonTf.position + new Vector3(400, 0, 0);
        // titleTf.position = titleTf.position + new Vector3(0, 400, 0);
        // geetaTf.position = geetaTf.position + new Vector3(0, -400, 0);

        gambarStage.sprite = spriteStage[index];
        stageLock.SetActive(false);
        levelLock.SetActive(false);
        StartCoroutine(MainMenuIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (titleObj.allowMove) titleObj.Move();
        if (geetaObj.allowMove) geetaObj.Move();
        if (playButtonObj.allowMove) playButtonObj.Move();
        if (upgradeButtonObj.allowMove) upgradeButtonObj.Move();
        if (settingsButtonObj.allowMove) settingsButtonObj.Move();
        if (creditsButtonObj.allowMove) creditsButtonObj.Move();
        if (quitButtonObj.allowMove) quitButtonObj.Move();
        if (geetaFrameObj.allowMove) geetaFrameObj.Move();
        if (weaponFrameObj.allowMove) weaponFrameObj.Move();
        if (selectWPTextObj.allowMove) selectWPTextObj.Move();
        if (violinButtonObj.allowMove) violinButtonObj.Move();
        if (harpButtonObj.allowMove) harpButtonObj.Move();
        if (saxButtonObj.allowMove) saxButtonObj.Move();
        if (guitarButtonObj.allowMove) guitarButtonObj.Move();
        if (fluteButtonObj.allowMove) fluteButtonObj.Move();
        if (gendangButtonObj.allowMove) gendangButtonObj.Move();
        if (selectButtonObj.allowMove) selectButtonObj.Move();
        if (backSelectButtonObj.allowMove) backSelectButtonObj.Move();
        if (middlePinkObj.allowMove) middlePinkObj.Move();
        if (selectStageTextObj.allowMove) selectStageTextObj.Move();
        if (selectStageObj.allowMove) selectStageObj.Move();
        if (selectLevelObj.allowMove) selectLevelObj.Move();
        if (startButtonObj.allowMove) startButtonObj.Move();
        if (backStageButtonObj.allowMove) backStageButtonObj.Move();
    }

    public IEnumerator MainMenuIn()
    {
        allowPress = false;
        titleObj.allowMove = true;
        yield return new WaitForSeconds(0.5f);
        geetaObj.allowMove = true;
        yield return new WaitForSeconds(0.3f);
        playButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        upgradeButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        settingsButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        creditsButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        quitButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        allowPress = true;
    }

    public IEnumerator BackFromSelectWeapon()
    {
        allowPress = false;
        backSelectButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        selectButtonObj.allowMove = true;
        selectWPTextObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        geetaFrameObj.allowMove = true;
        weaponFrameObj.allowMove = true;
        saxButtonObj.allowMove = true;
        gendangButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        harpButtonObj.allowMove = true;
        fluteButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        violinButtonObj.allowMove = true;
        guitarButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.3f);

        titleObj.allowMove = true;
        yield return new WaitForSeconds(0.5f);
        geetaObj.allowMove = true;
        yield return new WaitForSeconds(0.3f);
        playButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        upgradeButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        settingsButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        creditsButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        quitButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        allowPress = true;
    }

    public IEnumerator PlayFromMain()
    {
        allowPress = false;
        quitButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        creditsButtonObj.allowMove = true;
        geetaObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        settingsButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        titleObj.allowMove = true;
        upgradeButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        playButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.2f);

        geetaFrameObj.allowMove = true;
        weaponFrameObj.allowMove = true;
        yield return new WaitForSeconds(0.2f);
        violinButtonObj.allowMove = true;
        guitarButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        harpButtonObj.allowMove = true;
        fluteButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        saxButtonObj.allowMove = true;
        gendangButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        selectWPTextObj.allowMove = true;
        selectButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        backSelectButtonObj.allowMove = true;
        allowPress = true;
    }

    private IEnumerator SelectFromWeapon()
    {
        allowPress = false;
        backSelectButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        selectButtonObj.allowMove = true;
        selectWPTextObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        saxButtonObj.allowMove = true;
        gendangButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        harpButtonObj.allowMove = true;
        fluteButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        violinButtonObj.allowMove = true;
        guitarButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.3f);

        middlePinkObj.allowMove = true;
        yield return new WaitForSeconds(0.2f);
        selectStageObj.allowMove = true;
        selectLevelObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        selectStageTextObj.allowMove = true;
        startButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        backStageButtonObj.allowMove = true;
        allowPress = true;
    }

    private IEnumerator BackFromStage()
    {
        allowPress = false;
        backStageButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        selectStageTextObj.allowMove = true;
        startButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        selectStageObj.allowMove = true;
        selectLevelObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        middlePinkObj.allowMove = true;
        yield return new WaitForSeconds(0.2f);
        
        violinButtonObj.allowMove = true;
        guitarButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        harpButtonObj.allowMove = true;
        fluteButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        saxButtonObj.allowMove = true;
        gendangButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        selectWPTextObj.allowMove = true;
        selectButtonObj.allowMove = true;
        yield return new WaitForSeconds(0.1f);
        backSelectButtonObj.allowMove = true;
        allowPress = true;
    }

    public void StartBackFromStage()
    {
        if (allowPress) {
            StartCoroutine(BackFromStage());
            if (!buttonPress.isPlaying) buttonPress.Play(0);
        }
    }

    public void StartSelectFromWeapon()
    {
        if (allowPress) {
            StartCoroutine(SelectFromWeapon());
            if (!buttonPress.isPlaying) buttonPress.Play(0);
        }
    }

    public void StartPlayFromMain()
    {
        if (allowPress) {
            StartCoroutine(PlayFromMain());
            if (!buttonPress.isPlaying) buttonPress.Play(0);
        }
    }

    public void StartBackFromSelectWeapon() {
        if (allowPress) {
            StartCoroutine(BackFromSelectWeapon());
            if (!buttonPress.isPlaying) buttonPress.Play(0);
        }
    }

    public void OnLeftArrowClick()
    {
        // Decrease the sprite index
        index--;
        
        // Wrap around to the end of the sprite array if needed
        if (index < 0)
        {
            index = spriteStage.Length - 1;
        }

        // Update the image sprite
        gambarStage.sprite = spriteStage[index];
        stageText.text = $"Stage {index + 1}";
        hideShowLock(index);
        hideShowLevelLock(index, level);
    }

    public void OnRightArrowClick()
    {
        // Increase the sprite index
        index++;
        
        // Wrap around to the start of the sprite array if needed
        if (index >= spriteStage.Length)
        {
            index = 0;
        }

        // Update the image sprite
        gambarStage.sprite = spriteStage[index];
        stageText.text = $"Stage {index + 1}";
        hideShowLock(index);
        hideShowLevelLock(index, level);
    }

    private void hideShowLock(int indexPrm)
    {
        List<int> unlock = new List<int>();
        unlock.Add(0);
        for (int i = 0; i < 15; i++) {
            if (i % 3 == 2) {
                if (currentData[i] == "1") unlock.Add((i/3) + 1);
            }
        }
        if (unlock.Contains(indexPrm)) {
            stageLock.SetActive(false);
            gambarStage.color = new Color(1f, 1f, 1f, 1f);
            startButton.interactable = true;
            startButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            startText.color = new Color(0.36f, 0.18f, 0.1f, 1f);
        } else {
            stageLock.SetActive(true);
            gambarStage.color = new Color(1f, 1f, 1f, 0.5f);
            startButton.interactable = false;
            startButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            startText.color = new Color(0.36f, 0.18f, 0.1f, 0.5f);
        }
    }

    public void OnLeftArrowLevelClick()
    {
        // Decrease the sprite index
        level--;
        
        // Wrap around to the end of the sprite array if needed
        if (level < 1)
        {
            level = 3;
        }

        // Update the image sprite
        levelValue.text = $"{level}";
        hideShowLevelLock(index, level);
    }

    public void OnRightArrowLevelClick()
    {
        // Increase the sprite index
        Debug.Log("Clicked!");
        level++;
        
        // Wrap around to the start of the sprite array if needed
        if (level > 3)
        {
            level = 1;
        }

        // Update the image sprite
        levelValue.text = $"{level}";
        hideShowLevelLock(index, level);
    }

    private void hideShowLevelLock(int index, int levelPrm)
    {
        List<int> unlock = new List<int>();
        index *= 3;
        for (int i = index; i < index + 3; i++) {
            if (i > 0) {
                if (currentData[i - 1] == "1") unlock.Add((i % 3) + 1);
            }
        }  
        // Debug.Log($"{index}, {levelPrm}");
        if (unlock.Contains(levelPrm) || (index == 0 && levelPrm == 1)) {
            levelLock.SetActive(false);
            // gambarStage.color = new Color(1f, 1f, 1f, 1f);
            startButton.interactable = true;
            startButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            startText.color = new Color(0.36f, 0.18f, 0.1f, 1f);
        } else {
            levelLock.SetActive(true);
            // gambarStage.color = new Color(1f, 1f, 1f, 0.5f);
            startButton.interactable = false;
            startButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            startText.color = new Color(0.36f, 0.18f, 0.1f, 0.5f);
        }
    }

    public void PlayGame() {
        int levelPlay = (index * 3) + (level);
        switch (levelPlay) {
            case 1: 
                SceneManager.LoadScene(2);
                break;
            case 2: SceneManager.LoadScene(3);
                break;
            case 3: SceneManager.LoadScene(4);
                break;
            default: SceneManager.LoadScene(1);
                break;
        }
    }

    // public IEnumerator MovePlayButton()
    // {
        
    // }

    // private void MovePlay()
    // {
    //     if (playButtonTf.position.x >= playStartPos.x) {
    //         float moveAmount = -20;
    //         Vector3 newPosition = playButtonTf.position + new Vector3(moveAmount, 0f, 0f);
    //         playButtonTf.position = newPosition;
    //     } else {
    //         allowPlayMove = false;
    //     }
    // }

    // private void MoveUpgrade()
    // {
    //     if (upgradeButtonTf.position.x >= upgradeStartPos.x) {
    //         float moveAmount = -20;
    //         Vector3 newPosition = upgradeButtonTf.position + new Vector3(moveAmount, 0f, 0f);
    //         upgradeButtonTf.position = newPosition;
    //     } else {
    //         allowUpgradeMove = false;
    //     }
    // }

    // private void MoveSettings()
    // {
    //     if (settingsButtonTf.position.x >= settingsStartPos.x) {
    //         float moveAmount = -20;
    //         Vector3 newPosition = settingsButtonTf.position + new Vector3(moveAmount, 0f, 0f);
    //         settingsButtonTf.position = newPosition;
    //     } else {
    //         allowSettingsMove = false;
    //     }
    // }

    // private void MoveCredits()
    // {
    //     if (creditsButtonTf.position.x >= creditsStartPos.x) {
    //         float moveAmount = -20;
    //         Vector3 newPosition = creditsButtonTf.position + new Vector3(moveAmount, 0f, 0f);
    //         creditsButtonTf.position = newPosition;
    //     } else {
    //         allowCreditsMove = false;
    //     }
    // }

    // private void MoveQuit()
    // {
    //     if (quitButtonTf.position.x >= quitStartPos.x) {
    //         float moveAmount = -20;
    //         Vector3 newPosition = quitButtonTf.position + new Vector3(moveAmount, 0f, 0f);
    //         quitButtonTf.position = newPosition;
    //     } else {
    //         allowQuitMove = false;
    //     }
    // }

    // private void MoveTitle()
    // {
    //     if (titleTf.position.y > titleStartPos.y) {
    //         float moveAmount = -10;
    //         Vector3 newPosition = titleTf.position + new Vector3(0f, moveAmount, 0f);
    //         titleTf.position = newPosition;
    //     } else {
    //         allowTitleMove = false;
    //     }
    // }

    // private void MoveGeeta()
    // {
    //     if (geetaTf.position.y < geetaStartPos.y) {
    //         float moveAmount = 10;
    //         Vector3 newPosition = geetaTf.position + new Vector3(0f, moveAmount, 0f);
    //         geetaTf.position = newPosition;
    //     } else {
    //         allowGeetaMove = false;
    //     }
    // }
}
