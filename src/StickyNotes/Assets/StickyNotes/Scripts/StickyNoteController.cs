using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class StickyNoteController : MonoBehaviour
{
    IStickyNoteSerializer serializer;

    Dictionary<IStickyNoteBugItem, IStickyNote> notes;
    IStickyNoteBugItem currentNote;

    CanvasGroup canvasGroup;
    bool lastInteractable;

    [Tooltip("Tag your player in this field to mark it as a Sticky Note interested party")]
    public Transform mobile;

    [Tooltip("The bug report prefab")]
    public GameObject bugReportPrefab;

    public Button defaultButton;

    public InputField bugText;

    public void BugTrigger_Entered(IStickyNoteBugItem bugItem)
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
        currentNote = gameObject.GetByInterfaceInChildren<IStickyNoteBugItem>();

        notes[currentNote] = new StickyNote()
        {
            Position = position,
            BugText = "Add Text Here",
            Scene = SceneManager.GetActiveScene().name,
            Timestamp = DateTime.Now
        };

        SetCurrentNote(notes[currentNote]);
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
        SetCurrentNote(notes[currentNote]);
        serializer.Save(notes.Values);
    }

    void Awake()
    {
        notes = new Dictionary<IStickyNoteBugItem, IStickyNote>();
        canvasGroup = GetComponent<CanvasGroup>();
        serializer = gameObject.GetByInterface<IStickyNoteSerializer>();
        lastInteractable = canvasGroup.interactable;

        LoadExistingNotes();

        StartCoroutine(WatchInteractable());
    }

    void LoadExistingNotes()
    {
        var existingNotes = serializer.Load();

        foreach (var note in existingNotes)
        {
            var gameObject = Instantiate(bugReportPrefab, note.Position, Quaternion.identity);

            var cn = gameObject.GetByInterfaceInChildren<IStickyNoteBugItem>();
            notes[cn] = note;
            cn.Set(note);
        }
    }

    void Start()
    {
        var stickyNoteMoble = mobile.gameObject.AddComponent<StickyNoteMobile>();
        stickyNoteMoble.controller = this;
    }

    void SetCurrentNote(IStickyNote bug)
    {
        if (currentNote == null)
            return;

        currentNote.Set(bug);
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
