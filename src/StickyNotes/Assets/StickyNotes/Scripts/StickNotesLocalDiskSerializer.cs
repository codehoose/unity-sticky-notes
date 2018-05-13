using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

public class StickNotesLocalDiskSerializer : MonoBehaviour, IStickyNoteSerializer
{
    string pathToFile;

    void Awake()
    {
        pathToFile = Path.Combine(Application.dataPath, "../stickynotes.json");
    }

    public IEnumerable<IStickyNote> Load()
    {
        var json = File.Exists(pathToFile) ? File.ReadAllText(pathToFile) : null;

        if (string.IsNullOrEmpty(json))
            return new IStickyNote[] { };

        var jsonNoteCollection = JsonUtility.FromJson<JsonNoteCollection>(json);

        List<IStickyNote> notes = new List<IStickyNote>();

        foreach (var note in jsonNoteCollection.stickyNotes)
        {
            var sticky = new StickyNote()
            {
                BugText = note.bugText,
                Position = note.position,
                Scene = note.scene,
                Timestamp = Convert.ToDateTime(note.timeStamp)
            };

            notes.Add(sticky);
        }

        return notes;
    }

    public void Save(IEnumerable<IStickyNote> notes)
    {
        var list = new List<JsonStickyNote>();

        list.AddRange(notes.Select(n => new JsonStickyNote()
            {
                bugText = n.BugText,
                position = n.Position,
                scene = n.Scene,
                timeStamp = n.Timestamp.ToString()
            }));

        var notesData = new JsonNoteCollection();
        notesData.stickyNotes = list.ToArray();

        var json = JsonUtility.ToJson(notesData);

        File.WriteAllText(pathToFile, json);
    }
}
