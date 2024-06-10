using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "New Resource")]
public class ResourceSO : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;
    public Sprite Icon;
}
