package com.nikaera;

import com.unity3d.player.UnityPlayerActivity;

import java.lang.Exception;

// External Dependency Manager for Unity によって、
// 必要な jar が含まれているため EncryptedSharedPreferences の利用が可能になる
import androidx.security.crypto.EncryptedSharedPreferences;
import androidx.security.crypto.MasterKey;

import android.content.Context;
import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;

import android.os.Bundle;
import android.util.Log;

public class SecretManager {
  private SharedPreferences sharedPreferences;
  
  public SecretManager(Context context) {
    try {
        // EncryptedSharedPreferences で設定値を保存する際に用いる、
        // 暗号鍵を扱うためのラッパークラスをデフォルト設定で作成する
        MasterKey masterKey = new MasterKey.Builder(context)
                .setKeyScheme(MasterKey.KeyScheme.AES256_GCM)
                .build();
                
        // EncryptedSharedPreferences のインスタンスを生成する
        // コンストラクタで作成した masterKey を指定している
        this.sharedPreferences = EncryptedSharedPreferences.create(
          context, context.getPackageName(), masterKey,
          EncryptedSharedPreferences.PrefKeyEncryptionScheme.AES256_SIV,
          EncryptedSharedPreferences.PrefValueEncryptionScheme.AES256_GCM
        );
    } catch (Exception e) {
        e.printStackTrace();
    }
  }
  
  /**
   * 指定したキーで値を保存する関数
   * @param key 値を保存する際に用いるキー
   * @param value 保存したい値
   */
  public boolean put(String key, String value) {
    SharedPreferences.Editor editor = sharedPreferences.edit();
    editor.putString(key, value);
    return editor.commit();
  }
  
  /**
   * 指定したキーで保存した値を取得する関数
   * `put` 関数で保存した値を取得するのに利用する
   * @param key 取得したい値のキー
   * @return キーに紐づく値、存在しなければ空文字が返却される
   */
  public String get(String key) {
    return sharedPreferences.getString(key, null);
  }
  
  /**
   * 指定したキーで値を削除する関数
   * @param key 削除したい値のキー
   */
  public boolean delete(String key) {
    SharedPreferences.Editor editor = sharedPreferences.edit();
    editor.remove(key);
    return editor.commit();
  }
}