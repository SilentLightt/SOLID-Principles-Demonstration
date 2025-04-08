using UnityEngine;

public class TagSystem : MonoBehaviour
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

    private void AttemptTag()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, tagRange);
        foreach (Collider hit in hitColliders)
        {
            TagPlayerRole otherPlayer = hit.GetComponent<TagPlayerRole>();
            if (otherPlayer != null && otherPlayer.CurrentRole == TagPlayerRole.Role.Runner)
            {
                TransferTagging(otherPlayer);
                break;
            }
        }
    }
    private void TransferTagging(TagPlayerRole newTaya)
    {
        // Remove LPTagSystem from current Taya
        Destroy(this);

        // Swap roles
        newTaya.BecomeTaya();
        playerRole.BecomeRunner();

        // Add LPTagSystem to the new Taya
        newTaya.gameObject.AddComponent<TagSystem>();
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, tagRange);
    }
}
