using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "New Resource")]
public class ResourceData : ScriptableObject
{
    [Header("Info")]
    public string ResourceName;
    public string ResourceDescription;
    public Sprite ResourceIcon;
}
