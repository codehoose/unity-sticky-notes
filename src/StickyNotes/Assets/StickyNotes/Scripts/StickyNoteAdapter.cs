using System.Linq;
using System.Collections.Generic;
using System;

public static class StickyNoteAdapter
{
    public static IList<JsonStickyNote> Adapt(IEnumerable<IStickyNote> notes)
    {
        var list = new List<JsonStickyNote>();

        list.AddRange(notes.Select(n => new JsonStickyNote()
        {
            id = n.Id,
            bugText = n.BugText,
            position = n.Position,
            x = n.Position.x,
            y = n.Position.y,
            z = n.Position.z,   
            scene = n.Scene,
            timeStamp = n.Timestamp.ToString("s")
        }));

        return list;
    }

    public static IList<IStickyNote> Adapt(JsonNoteCollection collection)
    {
        List<IStickyNote> notes = new List<IStickyNote>();

        foreach (var note in collection.stickyNotes)
        {
            var sticky = new StickyNote()
            {
                Id = note.id,
                BugText = note.bugText,
                Position = new UnityEngine.Vector3(note.x, note.y, note.z),
                Scene = note.scene,
                Timestamp = Convert.ToDateTime(note.timeStamp)
            };

            notes.Add(sticky);
        }

        return notes;
    }
}
