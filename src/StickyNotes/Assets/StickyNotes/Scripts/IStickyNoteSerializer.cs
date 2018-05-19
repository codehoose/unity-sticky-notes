using System.Collections.Generic;

public interface IStickyNoteSerializer
{
    bool IsReady { get; }

    void Save(IStickyNote current, IEnumerable<IStickyNote> notes);

    IEnumerable<IStickyNote> Load();

    void Delete(IStickyNote stickyNote);
}
