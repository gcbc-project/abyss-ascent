public class KeyObject : ResourceObject
{

    public override string GetInteractPrompt()
    {
        string str = $"{Data.Name}";
        return str;
    }

    public override void OnInteract()
    {
        PlayerManager.Instance.Player.Input.OnAddResource?.Invoke(Data);
        Destroy(gameObject);
    }
}
