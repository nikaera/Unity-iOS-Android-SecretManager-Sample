using UnityEngine;

/// <summary>
///     <em>Editor 利用時のみ PlayerPrefs を利用する</em>
/// </summary>
/// <remarks><see cref="KeychainService" />, <see cref="EncryptedSharedPreferences" /></remarks>
public static class SecretManager
{
#if UNITY_EDITOR
#elif UNITY_ANDROID
        private static ISecretManager _instance = new EncryptedSharedPreferences();
#elif UNITY_IOS
        private static ISecretManager _instance = new KeychainService();
#endif
        
        public static bool Put(string key, string value)
        {
#if UNITY_EDITOR
                PlayerPrefs.SetString(key, value);
                PlayerPrefs.Save();
                
                return true;
#elif UNITY_IOS || UNITY_ANDROID
                return _instance.Put(key, value);
#else
                Debug.Log("Not Implemented.");
                return false;
#endif

        }

        public static string Get(string key)
        {
#if UNITY_EDITOR
                return PlayerPrefs.GetString(key);
#elif UNITY_IOS || UNITY_ANDROID
        return _instance.Get(key);
#else
            Debug.Log("Not Implemented.");
            return null;
#endif
        }

        public static bool Delete(string key)
        {
#if UNITY_EDITOR
            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();

            return true;
#elif UNITY_IOS || UNITY_ANDROID
            return _instance.Delete(key);
#else
            Debug.Log("Not Implemented.");
            return false;
#endif
        }
}