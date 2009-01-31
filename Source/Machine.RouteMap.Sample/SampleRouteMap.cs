using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.RouteMap.RouteModel;
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
  }
}
