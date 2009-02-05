using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using Moq.Language.Flow;

namespace Machine.Route66.Specs
{
  public static class Mock
  {
    private static Dictionary<object, object> mockMap;

    static Mock()
    {
      mockMap = new Dictionary<object, object>(new ReferenceComparer());
    }

    public static T Create<T>() where T : class
    {
      var mock = new Mock<T>();
      mockMap[mock.Object] = mock;

      return mock.Object;
    }

    public static Mock<T> GetMock<T>(T @object) where T : class
    {
      if (!mockMap.ContainsKey(@object))
      {
        throw new ArgumentException(@object.ToString() + " is not a mock!", "object");
      }

      return (Mock<T>)mockMap[@object];
    }

    public static void ClearMap()
    {
      mockMap.Clear();
    }

    private class ReferenceComparer : IEqualityComparer<object>
    {
      public bool Equals(object x, object y)
      {
        return ReferenceEquals(x, y);
      }

      public int GetHashCode(object obj)
      {
        return obj.GetType().GetHashCode();
      }
    }

    public static ISetup Stub<T>(this T mock, Expression<Action<T>> expression) where T : class
    {
      var wrapper = GetMock(mock);
      return wrapper.Setup(expression);
    }

    public static ISetup<TResult> Stub<T, TResult>(this T mock, Expression<Func<T, TResult>> expression) where T : class
    {
      var wrapper = GetMock(mock);
      return wrapper.Setup(expression);
    }

    public static void ShouldHaveReceived<T>(this T mock, Expression<Action<T>> expression) where T : class
    {
      var wrapper = GetMock(mock);
      wrapper.Verify(expression);
    }

    public static void ShouldHaveReceived<T, TResult>(this T mock, Expression<Func<T, TResult>> expression) where T : class
    {
      var wrapper = GetMock(mock);
      wrapper.Verify(expression);
    }
  }
}