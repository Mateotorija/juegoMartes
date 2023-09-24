using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTF<T> : StackTDA
{
    private Stack<Wave> stack = new Stack<Wave>();
    int _index = 0;
    public void InitPila()
    {
        throw new System.NotImplementedException();
    }
    public void Stack(Wave item)
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
    public Wave Top()
    {
        if(stack.Count > 0)
        {
            return stack.Peek();
        }
        return null;
    }
}