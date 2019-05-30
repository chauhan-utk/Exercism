using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var ordered = new SortedList<int, TreeBuildingRecord>();

        foreach (var record in records)
        {
            ordered.Add(record.RecordId, record);
        }

        records = ordered.Values;

        var trees = new Dictionary<int, Tree>();
        var previousRecordId = -1;

        foreach (var record in records)
        {   
            var t = new Tree { Children = new List<Tree>(), Id = record.RecordId, ParentId = record.ParentId };
            if (trees.ContainsKey(record.RecordId))
                throw new ArgumentException();

            if ((t.Id == 0 && t.ParentId != 0) ||
                (t.Id != 0 && t.ParentId >= t.Id) ||
                (t.Id != 0 && t.Id != previousRecordId + 1))
            {
                throw new ArgumentException();
            }

            trees.Add(record.RecordId, t);

            ++previousRecordId;
        }
        
        if (trees.Count == 0)
        {
            throw new ArgumentException();
        }

        for (int i = 1; i < trees.Count; i++)
        {
            var t = trees[i];
            var parent = trees[t.ParentId];
            parent.Children.Add(t);
        }

        var r = trees[0];
        return r;
    }
}