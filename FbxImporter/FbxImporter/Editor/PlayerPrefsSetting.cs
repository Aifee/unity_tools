using UnityEngine;
using UnityEditor;

public class PlayerPrefsSetting<T> where T : new()
{
    public const string KEY = "PlayerPrefsSetting_";

    protected static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Parse();
            }
            return _instance;
        }
    }

    private bool isChanged = false;

    public bool IsChanged
    {
        get { return isChanged; }
        set { isChanged = value; }
    }

    public void Revert()
    {
        string key = KEY + typeof(T).Name;
        string json = EditorPrefs.GetString(key);
        if (string.IsNullOrEmpty(json))
        {
            _instance = new T();
        }
        else
        {
            _instance = JsonUtility.FromJson<T>(json);
        }
        IsChanged = false;
    }

    private static T Parse()
    {
        string key = KEY + typeof(T).Name;
        string json = EditorPrefs.GetString(key);
        T t = default(T);
        if (string.IsNullOrEmpty(json))
        {
            t = new T();
        }
        else
        {
            t = JsonUtility.FromJson<T>(json);
        }
        return t;
    }

    public void Save()
    {
        string json = ToString();
        string key = KEY + typeof(T).Name;
        EditorPrefs.SetString(key, json);
        IsChanged = false;
    }

    public void Clear()
    {
        string json = ToString();
        string key = KEY + typeof(T).Name;
        if (EditorPrefs.HasKey(key))
        {
            EditorPrefs.DeleteKey(key);
        }
        Revert();
    }

    public override string ToString()
    {
        string json = JsonUtility.ToJson(PlayerPrefsSetting<T>.Instance);
        return json;
    }
}