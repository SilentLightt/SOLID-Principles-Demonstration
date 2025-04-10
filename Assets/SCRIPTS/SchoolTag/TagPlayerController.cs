using UnityEngine;

public class TagPlayerController : MonoBehaviour, ITaggable
{
    [SerializeField] private TagRoleManager roleManager;

    public bool IsTagger => roleManager.currentTagger == this;

    public void OnTagged()
    {
        if (!IsTagger)
        {
            Debug.Log("Player was tagged!");
            roleManager.SwitchRoles();
        }
    }
}
