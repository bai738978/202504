using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NaughtyAttributes;
using TMPEffects.Components;
using Unity.VisualScripting.IonicZip;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dialog : MonoBehaviour
{
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

    [SerializeField]
    private TMPWriter tmpWirter;

    [Button("播放下一段對話")]
    public void PlayNextDialog()
    {
        if (dialogTexts.Count == 0)
        {
            Debug.LogError("錯誤，因為沒有對話資料");
            return;
        }
     if (dialogIndex + 1 == dialogTexts.Count)
     dialogIndex++;
     SetText(dialogTexts[dialogIndex]);
     PlayWriter();
    }
    private List<string> dialogTexts;
    private int dialogIndex = 0;
    
    public void SetTexts(List<string> text)
    {
        dialogTexts = text;
    }

    public void StartDialog()
    {
        dialogIndex = 0;
        SetText(dialogTexts[dialogIndex]);
        PlayWriter();
    }
[SerializeField]
private TMPWriter tmpWriter;

[SerializeField]
private PlayerInput playerInput;

 private void Start()
 {
     var interacetAction = playerInput.actions.FindAction("Interact");
     interacetAction.performed += InteracetActionOnperformed;
 }

 private void OnDisable()
 {
     var interacetAction = playerInput.actions.FindAction("Interact");
     interacetAction.performed -= InteracetActionOnperformed;
 }
 private void InteracetActionOnperformed(InputAction.CallbackContext obj)
 {
     Debug.Log("互動鍵按下");
     if (tmpWirter.IsWriting == false && dialogIndex + 1 == dialogTexts.Count)
     {
         CloseDialog();
         return;
     }
     if (tmpWirter.IsWriting) StartDialog();
     else if (tmpWirter.IsWriting == false) PlayNextDialog();
     
     
 }

 private void CloseDialog()
 {
     gameObject.SetActive(false);
 }
}

