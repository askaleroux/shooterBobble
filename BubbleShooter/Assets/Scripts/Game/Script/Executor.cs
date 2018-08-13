using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResumable
{

    bool Finished { get; }
    void Resume(float delta);
}


public interface IExecutor : IResumable
{
    void Add(IResumable resumable);
}


public class Executor : IExecutor, ICollection<IResumable>
{
    private List<IResumable> _resumables = new List<IResumable>();
    public bool Finished { get { return _resumables.Count == 0; } }
    public bool Empty { get { return _resumables.Count == 0; } }

    public int Count
    {
        get { return _resumables.Count; }
    }

    bool ICollection<IResumable>.IsReadOnly
    {
        get { return false; }
    }

    public Executor()
    {
        
    }

    public void Resume(float delta)
    {
        for (int i = _resumables.Count - 1; i >= 0; --i)
        {
            _resumables[i].Resume(delta);
        }

        _resumables.RemoveAll(r => r.Finished);
    }

 
    public void Add(IResumable resumable)
    {
        _resumables.Add(resumable);
    }

    public bool Remove(IResumable resumable)
    {
        return _resumables.Remove(resumable);
    }

    public void Clear()
    {
        _resumables.Clear();
    }

    public bool Contains(IResumable item)
    {
        return _resumables.Contains(item);
    }

    void ICollection<IResumable>.CopyTo(IResumable[] array, int arrayIndex)
    {
        _resumables.CopyTo(array, arrayIndex);
    }

    IEnumerator<IResumable> IEnumerable<IResumable>.GetEnumerator()
    {
        return _resumables.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _resumables.GetEnumerator();
    }

    public List<IResumable>.Enumerator GetEnumerator()
    {
        return _resumables.GetEnumerator();
    }
}
