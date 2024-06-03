using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {Health, Stamina, Jumping};
    public Type type;
    public int value;

}
