using System.Collections.Generic;

public interface IStickyNoteSerializer
{
    void Save(IEnumerable<IStickyNote> notes);

    IEnumerable<IStickyNote> Load();
}
