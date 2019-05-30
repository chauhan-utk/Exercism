using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Node : IEnumerable, IComparable
{
    public string name { get; set; }
    public Dictionary<string, string> attributes { get; set; }
    public Node(string name)
    {
        this.name = name;
        this.attributes = new Dictionary<string, string>();
    }

    public void Add(string a, string b)
    {
        attributes[a] = b;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return this.name;
    }

    public int CompareTo(object obj)
    {
        var node2 = obj as Node;
        return this.name.CompareTo(node2.name);
    }
}

public class Edge : IEnumerable, IComparable
{
    private string a;
    private string b;
    private Dictionary<string, string> attributes;

    public Edge(string a, string b)
    {
        this.a = a;
        this.b = b;
        this.attributes = new Dictionary<string, string>();
    }

    public void Add(string a, string b)
    {
        attributes[a] = b;
    }

    public int CompareTo(object obj)
    {
        var edge2 = obj as Edge;
        return this.a.CompareTo(edge2.a);
    }

    public IEnumerator GetEnumerator()
    {
        yield return this.a;
    }
}

public class Attr : IEnumerable, IComparable
{
    private string key;
    private string value;
    
    public Attr(string key, string value)
    {
        this.key = key;
        this.value = value;
    }

    public int CompareTo(object obj)
    {
        var attrb2 = obj as Attr;
        return this.key.CompareTo(attrb2.key);
    }

    public IEnumerator GetEnumerator()
    {
        yield return key;
    }
}

public class Graph : IEnumerable
{
    private List<Attr> attr;
    private List<Edge> edges;
    private List<Node> nodes;
    public Attr[] Attrs { get {
            return attr.ToArray();
        } }
    public Edge[] Edges { get {
            return edges.ToArray();
        } }
    public Node[] Nodes { get {
            return nodes.ToArray();
        } }

    public Graph()
    {
        attr = new List<Attr>();
        edges = new List<Edge>();
        nodes = new List<Node>();
    }

    public void Add(Node node)
    {
        nodes.Add(node);
        nodes.Sort();
    }

    public void Add(Edge edge)
    {
        edges.Add(edge);
        edges.Sort();
    }

    public void Add(string a, string b)
    {
        attr.Add(new Attr(a, b));
        attr.Sort();
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var val in Nodes)
            yield return val;
        foreach (var val in Edges)
            yield return val;
        foreach (var val in Attrs)
            yield return val;
        yield break;
    }
}