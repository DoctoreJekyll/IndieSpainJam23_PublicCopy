using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "My Scriptables/New Dialog")]
public class DialogScriptable : ScriptableObject
{
    [Header("[Values]")]
    public string characterName;
    [TextArea]
    public string dialogText;
    public AudioClip voiceSFX;
    public Sprite characterPortrait;

}
