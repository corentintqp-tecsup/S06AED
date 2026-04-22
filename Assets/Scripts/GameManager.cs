using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MyStack<string> nameStack = new();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    // [Button]
    public void PushToStack(string value)
    {
        nameStack.Push(value);
    }

    // [Button]
    public void PopFromStack()
    {
        Debug.Log(nameStack.Pop());
    }

    // [Button]
    public void PeekStack()
    {
        Debug.Log(nameStack.Peek());
    }

    [Button]
    public void ClearStack()
    {
        nameStack.Clear();
        Debug.Log("Stack cleared");
    }

    [Button]
    public void Count() => Debug.Log($"Stack count: {nameStack.Count}");
}
