using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PriorityQueue<EntityStats> priorityQueue =
        new((a, b) => a.speed > b.speed);

    public TextMeshProUGUI queueText;
    private string text;

    [Button]
    public void Enqueue(EntityStats stats)
    {
        priorityQueue.Enqueue(stats);
        DisplayQueue();
    }

    [Button]
    public void Dequeue()
    {
        Debug.Log("Dequeue: " + priorityQueue.Dequeue().entityName);
        DisplayQueue();
    }

    [Button]
    public void Peek()
    {
        Debug.Log("Peek: " + priorityQueue.Peek().entityName);
    }

    [Button]
    public void Clear()
    {
        Debug.Log("Queue Cleared");
        priorityQueue.Clear();
    }

    [Button]
    public void Count()
    {
        Debug.Log("Count: " + priorityQueue.Count);
    }

    public void DisplayQueue()
    {
        text = "";
        QueueNode<EntityStats> temp = priorityQueue.Head;
        while (temp != null)
        {
            text += temp.Value.entityName + " - " + temp.Value.speed + "\n";
            temp = temp.Next;
        }
        queueText.text = text;
    }

}
