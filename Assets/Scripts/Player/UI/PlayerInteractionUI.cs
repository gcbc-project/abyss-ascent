using TMPro;
using UnityEngine;

public class PlayerInteractionUI : MonoBehaviour
{
    [SerializeField] GameObject UIContainer;
    [SerializeField] TMP_Text PromptText;

    private void Start()
    {
        PlayerManager.Instance.Player.Interaction.OnInterectEnterEvent += OnInterectEnter;
        PlayerManager.Instance.Player.Interaction.OnInterectExitEvent += OnInterectExit;
        CameraManager.Instance.OnChangeView += SetUIPos;
        UIContainer.SetActive(false);
    }

    private void OnInterectEnter(IInteractable interactable)
    {
        PromptText.text = interactable.GetInteractPrompt();
        UIContainer.SetActive(true);
    }

    private void OnInterectExit(IInteractable interactable)
    {
        UIContainer.SetActive(false);
    }

    private void SetUIPos(ViewType type)
    {
        if (type == ViewType.SideScrolling)
        {
            UIContainer.transform.localPosition = new Vector3(160, 30, 0);
        }
        else
        {
            UIContainer.transform.localPosition = new Vector3(240, -100, 0);
        }
    }
}
