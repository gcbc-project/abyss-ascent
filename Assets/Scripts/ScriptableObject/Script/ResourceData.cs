using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "New Resource")]
public class ResourceData : ScriptableObject
{
    [Header("Info")]
    public string _resourceName;
    public string _resourceDescription;
    public Sprite _resourceIcon;
}
