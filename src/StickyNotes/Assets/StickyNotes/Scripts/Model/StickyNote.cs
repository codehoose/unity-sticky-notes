using System;
using UnityEngine;

[Serializable]
public class StickyNote : IStickyNote
{
    public int Id { get; set; }

    public string Scene { get; set; }

    public string BugText { get; set; }

    public Vector3 Position { get; set; }

    public DateTime Timestamp { get; set; }
}
