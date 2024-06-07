using UnityEngine;
using UnityEngine.UI;

public class ResourceSlot : MonoBehaviour
{
    [HideInInspector] public ResourceData Data;
    [HideInInspector] public Inventory Inventory;
    [HideInInspector] public int Idx;

    [SerializeField] Image _icon;

    Outline _outline;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        _outline.enabled = false;
    }

    public void Set()
    {
        if (Data != null)
        {
            _icon.gameObject.SetActive(true);
            _icon.sprite = Data._resourceIcon;
        }
    }

    public void Clear()
    {
        Data = null;
        _icon.gameObject.SetActive(false);
        _outline.enabled = false;
    }

    public void OnClickButton()
    {
        Inventory.SelectItem(Idx);
    }

    public void EnableOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = true;
        }
    }

    public void DisableOutline()
    {
        if (_outline != null)
        {
            _outline.enabled = false;
        }
    }
}
