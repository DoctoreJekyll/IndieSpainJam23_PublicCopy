using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UI_DialogPanel : MonoBehaviour
{
    public static UI_DialogPanel instance;
    public enum dialogCharacter { KID, FATHER }
    public Action onEndDialog;

    [Header("[References]")]
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Image characterPortrait;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject continueArrow;

    [Header("[Configuration]")]
    [SerializeField] private float characterPerSecond;
    [SerializeField] private float soundPerCharacter;

    [Header("[Values]")]
    [SerializeField] private List<DialogScriptable> dialogList;
    [SerializeField] private int currentDialogIndex;
    [SerializeField] private bool typingText;
    [SerializeField] private bool onDialog;


    private void Awake()
    {
        CreateSingleton();
    }
    private void CreateSingleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && onDialog == true && typingText == false)
        {
            ShowNextDialog();
        }
    }


    public void ShowDialog(List<DialogScriptable> newDialogList)
    {
        Core.GameStateController.Instance.ChangeGameStateTo(Core.GameStateController.GameState.Pause);

        dialogList = newDialogList;
        dialogPanel.SetActive(true);
        onDialog = true;

        ShowNextDialog();
    }

    private void ShowNextDialog()
    {
        if(currentDialogIndex < dialogList.Count)
        {
            CleanDialog();
            SetCharacter();
            TypeDialog();
        }
        else
            CloseDialog();
    }


    private void TypeDialog()
    {
        AudioClip voiceSFX = dialogList[currentDialogIndex].voiceSFX;
        StartCoroutine(Coroutine_TypeDialog());

        IEnumerator Coroutine_TypeDialog()
        {
            typingText = true;
            int characterCount = 0;
            yield return new WaitForSeconds(0.25f);

            audiosource.PlayOneShot(voiceSFX);
            foreach (var c in dialogList[currentDialogIndex].dialogText)
            {
                dialogText.text += c;
                characterCount++;
                yield return new WaitForSeconds(1 / characterPerSecond);

                if(characterCount >= soundPerCharacter)
                {
                    audiosource.PlayOneShot(voiceSFX);
                    characterCount = 0;
                }
            }

            yield return new WaitForSeconds(0.20f);

            audiosource.Stop();
            typingText = false;
            currentDialogIndex++;

            if (currentDialogIndex < dialogList.Count)
                continueArrow.SetActive(true);
            else
                continueArrow.SetActive(false);
        }
    }


    private void SetCharacter()
    {
        characterPortrait.sprite = dialogList[currentDialogIndex].characterPortrait;
        characterName.text = dialogList[currentDialogIndex].characterName;
    }

    private void CloseDialog()
    {
        onDialog = false;
        currentDialogIndex = 0;

        if(onEndDialog != null)
            onEndDialog.Invoke();

        dialogPanel.SetActive(false);
    }

    private void CleanDialog()
    {
        dialogText.text = "";
        continueArrow.SetActive(false);
    }

}
