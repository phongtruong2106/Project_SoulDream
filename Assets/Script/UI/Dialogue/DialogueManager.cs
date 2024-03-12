using System.Collections;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
public class DialogueManager : NewMonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] public GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueNameText;
    
    private const string SPEAKER_TAG = "speaker";

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
        if(dialoguePanel != null)
        {
            dialogueIsPlaying = false;
            dialoguePanel.SetActive(false);
        }
        
    }

    protected virtual void Update()
    {

        if(!dialogueIsPlaying)
        {
            return;
        }     
        Invoke("ContinueStory", 3f);
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
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode()); 
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriately parsed: " + tag);
            }
             string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch(tagKey)
            {
                case SPEAKER_TAG:
                    dialogueNameText.text = tagValue;
                    break;
                default:
                    Debug.LogWarning("tag came in but is not currently being handle: " + tag);
                    break;
            }
        }
    }
}