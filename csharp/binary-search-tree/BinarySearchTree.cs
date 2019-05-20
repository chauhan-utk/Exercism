using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BinarySearchTree : IEnumerable<int>
{
    private BinarySearchTree m_left = null;
    private BinarySearchTree m_right = null;
    private int m_val = int.MinValue;
    public BinarySearchTree(int value)
    {
        TryInsertNode(value);
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        foreach(var val in values)
        {
            TryInsertNode(val);
        }    
    }

    private void TryInsertNode(int val)
    {
        if (m_val == int.MinValue)
        {
            m_val = val;
        }
        else if (m_val >= val)
        {
            TryInsertLeftNode(val);
        }
        else
        {
            TryInsertRightNode(val);
        }
    }

    private void TryInsertLeftNode(int val)
    {
        if (m_left == null) m_left = new BinarySearchTree(val);
        else m_left.Add(val);
    }

    private void TryInsertRightNode(int value)
    {
        if (m_right == null) m_right = new BinarySearchTree(value);
        else m_right.Add(value);
    }

    public int Value
    {
        get
        {
            return m_val;
        }
    }

    public BinarySearchTree Left
    {
        get
        {
            return m_left;
        }
    }

    public BinarySearchTree Right
    {
        get
        {
            return m_right;
        }
    }

    public BinarySearchTree Add(int value)
    {
        TryInsertNode(value);
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        BinarySearchTree inOrderTravers = this;
        if (inOrderTravers.Left != null)
        {
            foreach (var val in inOrderTravers.Left)
                yield return val;
        }
        yield return inOrderTravers.Value;
        if (inOrderTravers.Right != null)
        {
            foreach (var val in inOrderTravers.Right)
                yield return val;
        }
        yield break;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}