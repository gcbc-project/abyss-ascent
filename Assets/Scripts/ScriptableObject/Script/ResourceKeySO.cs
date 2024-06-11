using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "New Resource/key")]
public class ResourceKeySO : ResourceSO
{
    [Header("Key")]
    public string KeyId;
}
