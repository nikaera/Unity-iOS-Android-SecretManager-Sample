using UnityEngine;

/// <summary>
///     利用するネイティブコードは <c>Assets/Plugins/Android/SecretManager.java</c> に記載
/// </summary>
/// <remarks>
///     <a href="https://developer.android.com/reference/androidx/security/crypto/EncryptedSharedPreferences">EncryptedSharedPreferences</a>
/// </remarks>
class EncryptedSharedPreferences: ISecretManager
{
    private readonly AndroidJavaObject _secretManager;
    public EncryptedSharedPreferences()
    {
        var activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
            .GetStatic<AndroidJavaObject>("currentActivity");
        var context = activity.Call<AndroidJavaObject>("getApplicationContext");
        _secretManager = new AndroidJavaObject("com.nikaera.SecretManager", context);
    }
    
    #region ISecretManager

    public bool Put(string key, string value)
    {
        return _secretManager.Call<bool>("put", key, value);
    }

    public string Get(string key)
    {
        return _secretManager.Call<string>("get", key);
    }

    public bool Delete(string key)
    {
        return _secretManager.Call<bool>("delete", key);
    }
    
    #endregion
}