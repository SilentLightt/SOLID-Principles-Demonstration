using UnityEngine;

public interface ITaggable
{
    void OnTagged();
    bool IsTagger { get; }
}

