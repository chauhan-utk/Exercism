using System;

public class Node<T>
{
    public T Data;
    public Node<T> back;
    public Node<T> front;

    public Node(T value)
    {
        Data = value;
        back = null;
        front = null;
    }
}

public class Deque<T>
{
    private Node<T> backNode;
    private Node<T> frontNode;

    public Deque()
    {
        backNode = null;
        frontNode = null;
    }

    public void Push(T value)
    {
        if (this.backNode == null)
        {
            this.backNode = new Node<T>(value);
            this.frontNode = this.backNode;
        }
        else
        {
            backNode.back = new Node<T>(value);
            backNode.back.front = backNode;
            backNode = backNode.back;
        }
    }

    public T Pop()
    {
        T value = backNode.Data;
        if (backNode == frontNode)
        {
            backNode = null;
            frontNode = null;
        }
        else
        {
            backNode = backNode.front;
            backNode.back.front = null;
            backNode.back = null;
        }
        return value;
    }

    public void Unshift(T value)
    {
        if (this.frontNode == null)
        {
            frontNode = new Node<T>(value);
            backNode = frontNode;
        }
        else
        {
            frontNode.front = new Node<T>(value);
            frontNode.front.back = frontNode;
            frontNode = frontNode.front;
        }
    }

    public T Shift()
    {
        T value = frontNode.Data;
        if (frontNode == backNode)
        {
            backNode = null;
            frontNode = null;
        }
        else
        {
            frontNode = frontNode.back;
            frontNode.front.back = null;
            frontNode.front = null;
        }
        return value;
    }
}