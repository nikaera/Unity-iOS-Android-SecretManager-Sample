using UnityEngine;
using UnityEngine.UI;

public class SecretManagerTest : MonoBehaviour
{
    [SerializeField]
    private InputField keyInput;
    
    [SerializeField]
    private InputField valueInput;

    public void OnClickGetButton()
    {
        valueInput.text = SecretManager.Get(keyInput.text);
        
        Debug.Log($"Get: {keyInput.text}: {valueInput.text}");
    }
    public void OnClickPutButton ()
    {
        var success = SecretManager.Put(keyInput.text, valueInput.text);
        
        var status = success ? "Success!" : "Failed...";
        Debug.Log($"Put: {status}");
        
    }
    public void OnClickDeleteButton()
    {
        var success = SecretManager.Delete(keyInput.text);
        
        var status = success ? "Success!" : "Failed...";
        Debug.Log($"Delete: {status}");
    }
}
