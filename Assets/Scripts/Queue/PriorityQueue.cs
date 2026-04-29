using System;
using UnityEngine;

public class PriorityQueue<T>
{
    #region Properties
    private int count;
    private QueueNode<T> head;
    private QueueNode<T> tail;

    private Func<T, T, bool> hasHigherPriority;
    #endregion

    public PriorityQueue(Func<T, T, bool> rule)
    {
        this.hasHigherPriority = rule;
    }

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
            if(hasHigherPriority(value, head.Value))
            {
                newNode.SetNext(head);
                head = newNode;
            }
            QueueNode<T> evaluator = head;
            while(evaluator.Next != null && !hasHigherPriority(value, evaluator.Next.Value))
            {
                evaluator = evaluator.Next;
            }
            newNode.SetNext(evaluator.Next);
            evaluator.SetNext(newNode);
            // tail.SetNext(newNode);
            // tail = newNode;
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

    public virtual void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
    #endregion

    #region Getters
    public int Count => count;
    public QueueNode<T> Head => head;
    public QueueNode<T> Tail => tail;
    #endregion
}
