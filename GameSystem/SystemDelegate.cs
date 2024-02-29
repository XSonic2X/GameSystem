using System;

namespace GameSystem
{
    static public class SystemDelegate
    {
        /// <summary>
        /// SystemDelegate.Invoke<T>(D.GetInvocationList(),Method);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="D"></param>
        /// <param name="action"></param>
        static public void Invoke<T>(Delegate[] D, Action<T> action)
        {
            for (int i = 0; i < D.Length; i++)
            {
                action.Invoke((T)D[i].DynamicInvoke());
            }
        }
        /// <summary>
        /// SystemDelegate.Invoke<T>(D.GetInvocationList(),Method,J);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="J"></typeparam>
        /// <param name="D"></param>
        /// <param name="action"></param>
        /// <param name="set"></param>
        static public void Invoke<T, J>(Delegate[] D, Action<T> action, J set)
        {
            for (int i = 0; i < D.Length; i++)
            {
                action.Invoke((T)D[i].DynamicInvoke(set));
            }
        }
    }
}
