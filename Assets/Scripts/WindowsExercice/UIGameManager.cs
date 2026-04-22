using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class UIGameManager : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public WindowsManager manager = new();

    private void Awake()
    {
        inputs = new();
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.UI.Escape.performed += HideCurrentPanel;
        manager.onElementAdded += OnElementAdded;
        manager.onElementRemoved += OnElementRemoved;
    }

    private void OnElementAdded(Window window)
    {
        window.window.SetActive(true);
        window.window.transform.SetAsLastSibling();
    }

    private void OnElementRemoved(Window window)
    {
        window.window.SetActive(false);
        window.window.transform.SetAsFirstSibling();
    }

    private void HideCurrentPanel(InputAction.CallbackContext context)
    {
        Window window = manager.Pop();
        if (window.window.activeSelf)
            window.window.SetActive(false);
        else
            HideCurrentPanel(context);
    }

    public void BtnOpenPanel(GameObject panel)
    {
        Window window = new(panel);
        manager.Push(window);
    }

    [Button]
    public void PeekFromScrach()
    {
        Debug.Log(manager.Peek().window.name);
    }

    [Button]
     public void Count() => Debug.Log($"Stack count: {manager.Count}");

}
