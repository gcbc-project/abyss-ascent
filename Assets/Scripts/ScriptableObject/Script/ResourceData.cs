using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "New Resource")]
public class ResourceData : ScriptableObject
{
    [Header("Info")]
    public string _resourceName;
    public string _resourceDescription;
    public MeshRenderer _resourceIcon;
}
