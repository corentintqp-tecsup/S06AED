using System.Drawing;
using UnityEngine;

public class MyStack<T>
{
    #region Properties
    private StackNode<T> top;
    private int count;
    #endregion

    #region Public Methods
    public virtual void Push(T value)
    {
        StackNode<T> newNode = new(value);
        if (top == null)
        {
            top = newNode;
            count++;
            return;
        }

        newNode.SetNext(top);
        top = newNode;
        count++;
    }

    public virtual T Pop()
    {
        if (top == null)
            throw new System.Exception("Stack is empty");

        T tempValue = top.Value;
        top = top.Next;
        count--;
        return tempValue;
    }

    public virtual T Peek()
    {
        if (top == null)
            throw new System.Exception("Stack is empty");
        T tempValue = top.Value;
        return tempValue;
    }

    public virtual void Clear()
    {
        top = null;
        count = 0;
    }
    #endregion

    #region Getters
    public StackNode<T> Top => top;
    public int Count => count;
    #endregion
}
