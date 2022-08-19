using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public abstract class Dialog : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] protected TextAsset inkJSON;

    [Header("Dialog UI")]
    [SerializeField]
    protected GameObject dialogPanel;

    [SerializeField]
    protected TextMeshProUGUI dialogTextDisplay;

    //Ink Stuff
    protected Story currentStory;

    //So this is read only to outside scripts
    protected bool dialogIsPlaying { get; private set; }

    protected bool inRange;

    private Player _player;

    //public AK.Wwise.Event dialogEvent;
    [SerializeField]
    private AudioClip dialogClip;
    // Start is called before the first frame update
    public virtual void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        dialogPanel.SetActive(false);
        dialogIsPlaying = false;
        _player.dialogIsPlaying = false; // set the _player dialogplaying bool 
    }

    public virtual void EnterDialog(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogIsPlaying = true;
        _player.dialogIsPlaying = true; // set the _player dialogplaying bool 
        dialogPanel.SetActive(true);
        inRange = false;

        ContinueStory();
    }

    public virtual void ExitDialogMode()
    {
        //if this happens with the same button as jump make this a coroutine and wait 0.2f
        dialogIsPlaying = false;
        _player.dialogIsPlaying = false;
        dialogPanel.SetActive(false);
        dialogTextDisplay.text = "";
     
    }

    public virtual void ContinueStory()
    {
        //if it can continue
        if (currentStory.canContinue)
        {
            //dialogEvent.Post(gameObject);
            AudioSource.PlayClipAtPoint(dialogClip, new Vector3(0, 0, -15));
            dialogTextDisplay.text = currentStory.Continue();    
        }
        //if it cant
        else
        {
            ExitDialogMode();
        }
    }

    public virtual void Update()
    {

        if (inRange == true && dialogIsPlaying == false)
        {
          EnterDialog(inkJSON);
        }

        if (!dialogIsPlaying)
        {
            return;
        }

        if (_player.GetDialogContinuePressed())
        {
            ContinueStory();
        }


    }
}