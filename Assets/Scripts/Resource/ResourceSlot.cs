using UnityEngine;
using UnityEngine.UI;

public class ResourceSlot : MonoBehaviour
{
    public ResourceData _data;
    public Inventory _inventory;
    public Image _icon;
    private Outline _outline;
    public int _index;

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
        if (_data != null)
        {
            _icon.gameObject.SetActive(true);
            _icon.sprite = _data._resourceIcon;
        }
    }

    public void Clear()
    {
        _data = null;
        _icon.gameObject.SetActive(false);
        _outline.enabled = false;
    }

    public void OnClickButton()
    {
        _inventory.SelectItem(_index);
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
