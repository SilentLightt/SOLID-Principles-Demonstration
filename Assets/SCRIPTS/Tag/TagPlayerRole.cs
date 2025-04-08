using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TagPlayerRole : MonoBehaviour
{
    public enum Role { Taya, Runner }
    public Role CurrentRole = Role.Runner;

    public bool IsAI = false; // Set in Inspector or dynamically

    private bool canTag = true;
    private Renderer playerRenderer;
    private Color originalColor;
    private Color tayaColor = Color.red;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
    }

    public void BecomeTaya()
    {
        CurrentRole = Role.Taya;
        StartCoroutine(TayaCooldown());
    }

    public void BecomeRunner()
    {
        CurrentRole = Role.Runner;
        canTag = false;
        playerRenderer.material.color = originalColor;
    }

    private IEnumerator TayaCooldown()
    {
        canTag = false;
        playerRenderer.material.color = Color.Lerp(originalColor, tayaColor, 0.5f);
        yield return new WaitForSeconds(2f);
        canTag = true;
        playerRenderer.material.color = tayaColor;
    }

    public bool CanTag() => canTag && CurrentRole == Role.Taya;
}