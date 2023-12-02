namespace pamiw_pwa.Security;

public class AuthState
{
    public bool IsAuthenticated { get; private set; }
    public event Action OnChange;

    public void SetAuth(bool auth)
    {
        IsAuthenticated = auth;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
