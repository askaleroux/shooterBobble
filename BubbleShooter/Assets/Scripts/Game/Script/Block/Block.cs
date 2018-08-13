using Hanswu.bubble;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{

    public interface IReturn<T>
    {
        void Accept(T result);
        void Fail(Exception error);
    }

    public interface IBlock<T>
    {
        T Result { get; }
        Exception Error { get; }
        IEnumerator Do();
    }

    public struct None
    {
    }

    public class ExecuteBlock<T> : IBlock<T>, IReturn<T>
    {
        public T Result { get; private set; }
        public Exception Error { get; private set; }

        public ExecuteBlock(Func<IReturn<T>, IEnumerator> impl)
        {
            _doImpl = impl;
        }

        public void Accept(T result)
        {
            Error = null;
            Result = result;
        }

        public void Fail(Exception error)
        {
            Error = error;
        }

        Func<IReturn<T>, IEnumerator> _doImpl;

        public IEnumerator Do()
        {
            return _doImpl(this);
        }
    }
    
}