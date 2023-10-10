using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTF<T> : StackTDA<T>
{
    private Stack<T> stack = new Stack<T>();
    int _index = 0;
    public void InitPila()
    {
        throw new System.NotImplementedException();
    }
    public void Stack(T item)
    {
        stack.Push(item);
        _index++;
    }
    public void Unstack()
    {
        if(stack.Count > 0)
        {
            stack.Pop();
            _index--;
        }
        else
        {
            Debug.Log("Empty");
        }
    }
    public bool EmptyStack()
    {
        return _index == 0;
    }
    public T Top()
    {
        if(stack.Count > 0)
        {
            return stack.Peek();
        }
        return default(T);
    }
}