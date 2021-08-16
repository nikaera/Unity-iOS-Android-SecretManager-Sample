public interface ISecretManager
{
    /// <summary>
    /// 指定したキーで値を保存する関数
    /// </summary>
    /// <param name="key">キー</param>
    /// <param name="value">値</param>
    /// <returns>保存に成功したかどうか</returns>
    bool Put(string key, string value); 
    
    /// <summary>
    /// 指定したキーの値を取得する関数
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>指定したキーで設定された値、無ければ null</returns>
    string Get(string key);
    
    /// <summary>
    /// 指定したキーの値を削除する関数
    /// </summary>
    /// <param name="key">キー</param>
    /// <returns>削除に成功したかどうか</returns>
    bool Delete(string key);
}