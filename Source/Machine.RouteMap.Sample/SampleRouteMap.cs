using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.RouteMap.RouteModel;
using Machine.RouteMap.Sample.Controllers;
using Machine.RouteMap.Sample.RouteModel;

namespace Machine.RouteMap.Sample
{
  public class root
  {
    public static User user
    {
      get { return new User(); }
    }

    public static Home home
    {
      get { return new Home(); }
    }

    public static Foo foo
    {
      get { return new Foo(); }
    }
  }

  namespace RouteModel
  {
    public class Home : ISupportGet
    {
    }

    public class User
    {
      public WithId this[object id]
      {
        get
        {
          return new WithId(this, id);
        }
      }

      public class WithId : ISupportGet
      {
        readonly User _parent;
        readonly object _id;

        public WithId(User user, object id)
        {
          _parent = user;
          _id = id;
        }

        public Friend friend
        {
          get { return new Friend(this); }
        }

        public class Friend
        {
          readonly User.WithId _parent;

          public Friend(User.WithId parent)
          {
            _parent = parent;
          }

          public List list
          {
            get { return new List(this); }
          }

          public WithId this[object friendId]
          {
            get
            {
              return new WithId(this, friendId);
            }
          }

          public class List
          {
            readonly Friend _parent;

            public List(Friend parent)
            {
              _parent = parent;
            }
          }

          public class WithId : ISupportGet, ISupportPost
          {
            readonly Friend _parent;
            readonly object _friendId;

            public WithId(Friend parent, object friendId)
            {
              _parent = parent;
              _friendId = friendId;
            }
          }
        }
      }
    }

    public class Foo
    {
      public WithIdAndId2 this[object id, object id2]
      {
        get { return new WithIdAndId2(this, id, id2); }
      }
      
      public class WithIdAndId2
      {
        readonly Foo _parent;
        readonly object _id;
        readonly object _id2;

        public WithIdAndId2(Foo parent, object id, object id2)
        {
          _parent = parent;
          _id = id;
          _id2 = id2;
        }

        public Bar bar
        {
          get { return new Bar(this); }
        }

        public class Bar : ISupportGet
        {
          readonly WithIdAndId2 _parent;

          public Bar(WithIdAndId2 parent)
          {
            _parent = parent;
          }
        }
      }
    }
  }
}