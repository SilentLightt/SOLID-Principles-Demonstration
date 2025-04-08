using UnityEngine;

public static class TagUtility
{
    public static void TryTagNearby(Transform tagger, float tagRange, TagPlayerRole taggerRole)
    {
        Collider[] hitColliders = Physics.OverlapSphere(tagger.position, tagRange);
        foreach (Collider hit in hitColliders)
        {
            TagPlayerRole otherRole = hit.GetComponent<TagPlayerRole>();
            if (otherRole != null && otherRole.CurrentRole == TagPlayerRole.Role.Runner)
            {
                TransferTag(taggerRole, otherRole);
                break;
            }
        }
    }

    private static void TransferTag(TagPlayerRole oldTaya, TagPlayerRole newTaya)
    {
        oldTaya.BecomeRunner();
        newTaya.BecomeTaya();

        // Remove old tagger component and assign appropriate new one
        Object.Destroy(oldTaya.GetComponent<ITagHandler>() as Component);

        if (newTaya.IsAI)
            newTaya.gameObject.AddComponent<TagAITagger>();
        else
            newTaya.gameObject.AddComponent<TagPlayerTagger>();
    }
}
