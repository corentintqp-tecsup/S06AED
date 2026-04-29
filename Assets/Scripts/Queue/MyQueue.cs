using System;

public class MyQueue<T>
{
    #region Properties
    private int count;
    private QueueNode<T> head;
    private QueueNode<T> tail;
    #endregion

    #region Methods
    public virtual void Enqueue(T value)
    {
        QueueNode<T> newNode = new QueueNode<T>(value);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.SetNext(newNode);
            tail = newNode;
        }
        count++;
    }

    public virtual T Dequeue()
    {
        if (head == null)
            throw new Exception("Queue is empty.");
        T temp = head.Value;
        head = head.Next;
        count--;
        if (head == null)
            tail = null;
        return temp;
    }

    public virtual T Peek()
    {
        if (head == null)
            throw new Exception("Queue is empty.");
        return head.Value;
    }
    #endregion

    #region Getters
    public int Count => count;
    public QueueNode<T> Head => head;
    public QueueNode<T> Tail => tail;
    #endregion
}
