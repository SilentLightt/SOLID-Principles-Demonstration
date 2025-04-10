using UnityEngine;

public class TagRoleManager : MonoBehaviour
{
    public ITaggable currentTagger;
    public ITaggable currentRunner;

    public void SwitchRoles()
    {
        var temp = currentTagger;
        currentTagger = currentRunner;
        currentRunner = temp;

        Debug.Log($"Roles switched: New Tagger: {currentTagger}, New Runner: {currentRunner}");
    }
}
