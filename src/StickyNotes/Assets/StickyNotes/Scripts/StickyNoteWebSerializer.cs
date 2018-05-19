using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class StickyNoteWebSerializer : MonoBehaviour, IStickyNoteSerializer
{
    string sceneName;
    IList<IStickyNote> stickyNotes;

    public string baseUrl = "http://localhost/";

    public bool IsReady { get; private set; }

    void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    IEnumerator Start()
    {
        var url = baseUrl + "fetchnotes.php?scene=" + sceneName;

        WWW www = new WWW(url);
        yield return www;

        var json = www.text;

        if (string.IsNullOrEmpty(json))
        {
            stickyNotes = new IStickyNote[] { };
            yield break;
        }

        var jsonNoteCollection = JsonUtility.FromJson<JsonNoteCollection>(json);

        if (!string.IsNullOrEmpty(jsonNoteCollection.error))
        {
            stickyNotes = new IStickyNote[] { };
            yield break;
        }

        stickyNotes = StickyNoteAdapter.Adapt(jsonNoteCollection);
        IsReady = true;
    }

    public void Delete(IStickyNote stickyNote)
    {
        StartCoroutine(DeleteNote(stickyNote));
    }

    public IEnumerable<IStickyNote> Load()
    {
        return stickyNotes;
    }

    public void Save(IStickyNote current, IEnumerable<IStickyNote> notes)
    {
        var list = StickyNoteAdapter.Adapt(new IStickyNote[] { current });
        var json = StickyNoteJson.ToJson(list);

        StartCoroutine(WriteToDatabase(current, json));
    }

    IEnumerator DeleteNote(IStickyNote note)
    {
        var url = baseUrl + "delete.php?id=" + note.Id;
        WWW www = new WWW(url);
        yield return www;
    }

    IEnumerator WriteToDatabase(IStickyNote stickyNote, string json)
    {
        var url = baseUrl + "insert.php";

        WWWForm form = new WWWForm();
        form.AddField("notes", json);

        WWW www = new WWW(url, form);
        yield return www;

        var jsonNoteCollection = JsonUtility.FromJson<JsonNoteCollection>(www.text);
        if (!string.IsNullOrEmpty(jsonNoteCollection.error))
        {
            Debug.LogWarning(jsonNoteCollection.error);
        }
        else
        {
            stickyNote.Id = jsonNoteCollection.newId;
        }
    }
}
