using UnityEngine;

public class TagAITagger : MonoBehaviour, ITagHandler
{
    public float tagRange = 2f;
    public float checkInterval = 1f;

    public TagPlayerRole aiRole;
    private float timer;

    private void Start()
    {
        aiRole = GetComponent<TagPlayerRole>();
        aiRole = FindFirstObjectByType<TagPlayerRole>();
    }

    private void Update()
    {
        if (!aiRole.CanTag()) return;

        timer += Time.deltaTime;
        if (timer >= checkInterval)
        {
            AttemptTag();
            timer = 0f;
        }
    }
    // public OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform, tagRange);
    // }
    public void AttemptTag()
    {
        TagUtility.TryTagNearby(transform, tagRange, aiRole);
    }
}
