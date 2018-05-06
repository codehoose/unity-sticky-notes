using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class StickyNoteController : MonoBehaviour
{
    Dictionary<StickyNoteWorldBugItem, StickyNote> notes;
    StickyNoteWorldBugItem currentNote;

    CanvasGroup canvasGroup;
    bool lastInteractable;

    [Tooltip("Tag your player in this field to mark it as a Sticky Note interested party")]
    public Transform mobile;

    [Tooltip("The bug report prefab")]
    public GameObject bugReportPrefab;

    public Button defaultButton;

    public InputField bugText;

    public void BugTrigger_Entered(StickyNoteWorldBugItem bugItem)
    {
        currentNote = bugItem;
    }

    public void BugTrigger_Leave()
    {
        currentNote = null;
    }

    public void AddButton_Click()
    {
        // Spawn a prefab ~ 2m forward of our current position;
        var position = mobile.position + mobile.forward * 2f;
        var gameObject = Instantiate(bugReportPrefab, position, Quaternion.identity);
        currentNote = gameObject.GetComponentInChildren<StickyNoteWorldBugItem>();

        notes[currentNote] = new StickyNote()
        {
            Position = currentNote.transform.position,
            BugText = "Add Text Here",
            Scene = SceneManager.GetActiveScene().name
        };

        SetCurrentNote(notes[currentNote].BugText);
    }

    public void RemoveButton_Click()
    {
        if (currentNote == null)
            return;

        notes.Remove(currentNote);
        currentNote.DestroyMe();
        currentNote = null;
    }

    public void SaveButton_Click()
    {
        if (currentNote == null)
            return;

        notes[currentNote].BugText = bugText.text;
        SetCurrentNote(bugText.text);
    }

    void Awake()
    {
        notes = new Dictionary<StickyNoteWorldBugItem, StickyNote>();
        canvasGroup = GetComponent<CanvasGroup>();
        lastInteractable = canvasGroup.interactable;

        StartCoroutine(WatchInteractable());
    }

    void Start()
    {
        var stickyNoteMoble = mobile.gameObject.AddComponent<StickyNoteMobile>();
        stickyNoteMoble.controller = this;
    }

    void SetCurrentNote(string bugText)
    {
        if (currentNote == null)
            return;

        currentNote.SetBugText(bugText);
    }

    IEnumerator WatchInteractable()
    {
        while (true)
        {
            if (lastInteractable != canvasGroup.interactable)
            {
                lastInteractable = canvasGroup.interactable;
                if (lastInteractable)
                {
                    EventSystem.current.SetSelectedGameObject(defaultButton.gameObject);

                    bugText.text = currentNote == null ? "" : notes[currentNote].BugText;
                }
            }

            yield return null;
        }
    }
}
