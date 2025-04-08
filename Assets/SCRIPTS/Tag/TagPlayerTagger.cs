using UnityEngine;

public class TagPlayerTagger : MonoBehaviour, ITagHandler
{
    public float tagRange = 2f;
    public KeyCode tagKey = KeyCode.E;

    private TagPlayerRole playerRole;

    private void Start()
    {
        playerRole = GetComponent<TagPlayerRole>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(tagKey) && playerRole.CanTag())
        {
            AttemptTag();
        }
    }

    public void AttemptTag()
    {
        TagUtility.TryTagNearby(transform, tagRange, playerRole);
    }
}
