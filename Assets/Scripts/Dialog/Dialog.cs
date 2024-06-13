using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    Quest,
    Shop
}

[CreateAssetMenu(menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public bool HasInteraction;
    public InteractionType Type;
    public string Greeting;
    [TextArea] public string[] Chat;
}
