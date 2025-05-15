using NaughtyAttributes;
using TMPEffects.Components;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private TMPWriter tmpWirter;

    [Button("執行打字機效果")]
    public void PlayWriter()
    {
        tmpWirter.RestartWriter();
    }

    [Button("跳過打字機效果")]
    private void SkipWriter()
    {
        tmpWirter.SkipWriter();
    }

    public void SetText(string dialogtext)
    {
        tmpWirter.SetText(dialogtext);
    }
}
