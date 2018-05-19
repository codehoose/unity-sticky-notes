using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public static class StickyNoteJson 
{
    public static string ToJson(IList<JsonStickyNote> stickyNotes)
    {
        var notesData = new JsonNoteCollection()
        {
            stickyNotes = stickyNotes.ToArray()
        };

        return JsonUtility.ToJson(notesData);
    }
}
