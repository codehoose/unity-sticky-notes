using UnityEngine;
using System;

public interface IStickyNote
{
    int Id { get; set; }

    string Scene { get; set; }

    string BugText { get; set; }

    Vector3 Position { get; set; }

    DateTime Timestamp { get; set; }
}
