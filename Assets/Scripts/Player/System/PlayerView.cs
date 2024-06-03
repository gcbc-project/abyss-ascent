using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int layerMask = 1 << other.gameObject.layer;
        if (layerMask == (1 << 8) || layerMask == (1 << 9))
        {
            CameraManager.Instance.SetView((ViewType)layerMask);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        int layerMask = 1 << other.gameObject.layer;
        if (layerMask == (1 << 8) || layerMask == (1 << 9))
        {
            CameraManager.Instance.SetView(ViewType.SideScrolling);
        }
    }
}
