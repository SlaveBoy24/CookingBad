using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject _dialogueWindow;
    [SerializeField] private TextMeshProUGUI _dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] _choices;
    [SerializeField] private TextMeshProUGUI[] _choicesText;
    private int _choiceIndex;
    private bool _choiceExist;

    private Story _currentStory;
    private bool _dialogueIsPlaying;

    private static DialogueManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("There is more than 1 DialohueManager in the scene");
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        _choiceExist = false;
        _dialogueIsPlaying = false;
        _dialogueWindow.SetActive(false);

        // get all of the choices text
        _choicesText = new TextMeshProUGUI[_choices.Length];
        int index = 0;
        foreach (GameObject choice in _choices)
        {
            _choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        _currentStory = new Story(inkJSON.text);
        _dialogueIsPlaying = true;
        _dialogueWindow.SetActive(true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        _dialogueIsPlaying = false;
        _dialogueWindow.SetActive(false);
        _dialogueText.text = "";
    }

    public void ContinueStory()
    {
        if (_choiceExist)
        {
            _currentStory.ChooseChoiceIndex(_choiceIndex);
            _choiceExist = false;
        }

        if (_currentStory.canContinue)
        {
            _dialogueText.text = _currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = _currentStory.currentChoices;

        if (currentChoices.Count != 0)
            _choiceExist = true;

        if (currentChoices.Count > _choices.Length)
            Debug.LogWarning("There is more choices than Dialohue Window has: " + currentChoices.Count);

        int index = 0;
        //
        foreach (Choice choice in currentChoices)
        {
            _choices[index].gameObject.SetActive(true);
            _choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < _choices.Length; i++)
        {
            _choices[i].gameObject.SetActive(false);
        }
    }

    public void DoChoice(int choiceIndex)
    {
        _choiceIndex = choiceIndex;
    }
}
