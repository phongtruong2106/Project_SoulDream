using Ink.Runtime;
using TMPro;
using UnityEngine;
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

        
        
    }
    void FixedUpdate()
    {
        this.AutoContinueDialogue();
    }

    protected virtual void AutoContinueDialogue()
    {
       if(dialogueIsPlaying)
        {
            // Đảm bảo rằng currentStory không null trước khi tiếp tục
            if(currentStory != null && currentStory.canContinue)
            {
                // Gọi phương thức ContinueStory() sau 7 giây
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

    public void ExitDialogueMode()
    {
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
            ExitDialogueMode(); 
        }
    }
}