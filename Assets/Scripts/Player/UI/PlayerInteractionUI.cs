using TMPro;
using UnityEngine;

public class PlayerInteractionUI : MonoBehaviour
{
    [SerializeField] GameObject _uiContainer;
    [SerializeField] TMP_Text _promptText;

    private void Start()
    {
        PlayerManager.Instance.Player.Interaction.OnInterectEnterEvent += OnInterectEnter;
        PlayerManager.Instance.Player.Interaction.OnInterectExitEvent += OnInterectExit;
        CameraManager.Instance.OnChangeView += SetUIPos;
        _uiContainer.SetActive(false);
    }

    private void OnInterectEnter(IInteractable interactable)
    {
        _promptText.text = interactable.GetInteractPrompt();
        _uiContainer.SetActive(true);
    }

    private void OnInterectExit(IInteractable interactable)
    {
        _uiContainer.SetActive(false);
    }

    private void SetUIPos(ViewType type)
    {
        if (type == ViewType.SideScrolling)
        {
            _uiContainer.transform.localPosition = new Vector3(160, 30, 0);
        }
        else
        {
            _uiContainer.transform.localPosition = new Vector3(240, -100, 0);
        }
    }
}
