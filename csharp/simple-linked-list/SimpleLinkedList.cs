using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Node<T>
{
    public T data { get; set; }
    public Node<T> next { get; set; }
}

public class SimpleLinkedList<T> : IEnumerable<T>
{
    T data { get; set; }
    SimpleLinkedList<T> next { get; set; }
    public SimpleLinkedList(T value)
    {
        data = value;
        next = null;
    }

    public SimpleLinkedList(IEnumerable<T> values)
    {
        SimpleLinkedList<T> tmp = null;
        foreach(T value in values)
        {
            if (tmp == null)
            {
                this.data = value;
                this.next = null;
                tmp = this;
            }
            else if (tmp.next == null)
            {
                tmp.next = new SimpleLinkedList<T>(value);
                tmp = tmp.next;
            }
            else
            {
                throw new IndexOutOfRangeException(string.Format("something wrong with tmp value: {0}", value));
            }
        }
    }

    public T Value 
    { 
        get
        {
            return data;
        } 
    }

    public SimpleLinkedList<T> Next
    { 
        get
        {
            return next;
        } 
    }

    public SimpleLinkedList<T> Add(T value)
    {
        SimpleLinkedList<T> tmp = this;
        while (tmp.next != null)
        {
            tmp = tmp.next; // move to the end of the list
        }
        tmp.next = new SimpleLinkedList<T>(value);
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        SimpleLinkedList<T> tmp = this;
        while (tmp != null)
        {
            T returnVal = tmp.Value;
            tmp = tmp.next;
            yield return returnVal;
        }
        yield break;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}