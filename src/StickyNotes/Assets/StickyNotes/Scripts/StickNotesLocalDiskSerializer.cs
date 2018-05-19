using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class StickNotesLocalDiskSerializer : MonoBehaviour, IStickyNoteSerializer
{
    string pathToFile;

    public bool IsReady { get { return true; } }

    void Awake()
    {
        pathToFile = Path.Combine(Application.dataPath, "../stickynotes.json");
    }

    public void Delete(IStickyNote stickNote) { }

    public IEnumerable<IStickyNote> Load()
    {
        var json = File.Exists(pathToFile) ? File.ReadAllText(pathToFile) : null;

        if (string.IsNullOrEmpty(json))
            return new IStickyNote[] { };

        var jsonNoteCollection = JsonUtility.FromJson<JsonNoteCollection>(json);
        var notes = StickyNoteAdapter.Adapt(jsonNoteCollection);

        return notes;
    }

    public void Save(IStickyNote current, IEnumerable<IStickyNote> notes)
    {
        var list = StickyNoteAdapter.Adapt(notes);
        var json = StickyNoteJson.ToJson(list);

        File.WriteAllText(pathToFile, json);
    }
}
