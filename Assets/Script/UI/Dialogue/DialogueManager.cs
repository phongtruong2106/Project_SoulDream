using System.Collections;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class DialogueManager : NewMonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    protected Story currentStory;
    protected bool dialogueIsPlaying;

    private static DialogueManager instance;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    protected override void Start()
    {
        base.Start();
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    protected virtual void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }     
        this.AutoContinueDialogue();
    }
    protected virtual void AutoContinueDialogue()
    {
       if(dialogueIsPlaying)
        {
            if(currentStory != null && currentStory.canContinue)
            {

                Invoke("ContinueStory", 3f);
            }
            else
            {
                ExitDialogueMode();
            }
        }
        
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    public IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    protected virtual void ContinueStory()
    {
        if(currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogueMode()); 
        }
    }
}