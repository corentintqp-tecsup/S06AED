using System;
using UnityEngine;

public class WindowsManager : MyStack<Window>
{
    public Action<Window> onElementAdded;
    public Action<Window> onElementRemoved;

    public override void Push(Window value)
    {
        base.Push(value);
        onElementAdded?.Invoke(Peek());
    }

    public override Window Pop()
    {
        Window temp = base.Pop();
        if (temp.window.activeSelf)
        {
            onElementRemoved?.Invoke(temp);
        }
        return temp;
    }

}
