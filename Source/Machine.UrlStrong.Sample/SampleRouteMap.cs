using Machine.UrlStrong.RouteModel;

namespace Machine.UrlStrong.Sample
{
  public static class Routes
  {
    public static Root root { get { return new Root();}}

    public class Root : ISupportGet
    {
      public User user
      {
        get { return new User(this); }
      }

      public Home home
      {
        get { return new Home(this); }
      }

      public Foo foo
      {
        get { return new Foo(this); }
      }

      public Yadda_id_blah yadda_blah(object id)
      {
        return new Yadda_id_blah(this, id);
      }

      public class Home : ISupportGet
      {
        public Home(Root root)
        {
        }
      }

      public class User
      {
        public User(Root root)
        {
        }

        public _id_ this[object id]
        {
          get
          {
            return new _id_(this, id);
          }
        }

        public class _id_ : ISupportGet
        {
          readonly User _parent;
          readonly object _id;

          public _id_(User user, object id)
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
            readonly _id_ _parent;

            public Friend(_id_ parent)
            {
              _parent = parent;
            }

            public List list
            {
              get { return new List(this); }
            }

            public _friendId_ this[object friendId]
            {
              get
              {
                return new _friendId_(this, friendId);
              }
            }

            public class List : ISupportGet
            {
              readonly Friend _parent;

              public List(Friend parent)
              {
                _parent = parent;
              }
            }

            public class _friendId_ : ISupportGet, ISupportPost
            {
              readonly Friend _parent;
              readonly object _friendId;

              public _friendId_(Friend parent, object friendId)
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
        public Foo(Root root)
        {
        }

        public _id_ this[object id]
        {
          get { return new _id_(this, id); }
        }

        public class _id_ : ISupportGet
        {
          readonly Foo _parent;
          readonly object _id;

          public _id_(Foo parent, object id)
          {
            _parent = parent;
            _id = id;
          }

          public _id2_ this[object id2]
          {
            get { return new _id2_(this, id2); }
          }

          public class _id2_ : ISupportGet
          {
            readonly _id_ _parent;
            readonly object _id2;

            public _id2_(_id_ parent, object id2)
            {
              _parent = parent;
              _id2 = id2;
            }

            public Bar bar
            {
              get { return new Bar(this); }
            }

            public class Bar : ISupportGet
            {
              readonly _id2_ _parent;

              public Bar(_id2_ parent)
              {
                _parent = parent;
              }
            }
          }
        }
      }

      public class Yadda_id_blah : ISupportGet
      {
        readonly object _id;

        public Yadda_id_blah(Root parent, object id)
        {
          _id = id;
        }
      }
    }
  }
}