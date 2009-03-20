/*
using Machine.UrlStrong;

namespace Machine.UrlStrong.Sample
{
  public static class Url
  {
    public static Root root { get { return new Root(null); } }


    public class Root : UrlPart
    {
      private UrlPart _parent;

      public Root(UrlPart parent)
      {
        _parent = parent;
      }


      public Home home
      {
        get { return new Home(this); }
      }


      public User user
      {
        get { return new User(this); }
      }


      public Foo foo
      {
        get { return new Foo(this); }
      }


      public Yadda_id_blah yadda_id_blah(object id)
      {
        return new Yadda_id_blah(this, id);
      }
    }


    public class Home : UrlPart
    {
      private UrlPart _parent;

      public Home(UrlPart parent)
      {
        _parent = parent;
      }

    }


    public class User : UrlPart
    {
      private UrlPart _parent;

      public User(UrlPart parent)
      {
        _parent = parent;
      }


      public _id_ this[object id]
      {
        get { return new _id_(this, id); }
      }


      public class _id_ : UrlPart
      {
        private UrlPart _parent;
        object _id;

        public _id_(UrlPart parent, object id)
        {
          _parent = parent;
          _id = id;
        }


        public Friend friend
        {
          get { return new Friend(this); }
        }


        public class Friend : UrlPart
        {
          private UrlPart _parent;

          public Friend(UrlPart parent)
          {
            _parent = parent;
          }


          public List list
          {
            get { return new List(this); }
          }


          public _friendId_ this[object friendId]
          {
            get { return new _friendId_(this, friendId); }
          }


          public class List : UrlPart
          {
            private UrlPart _parent;

            public List(UrlPart parent)
            {
              _parent = parent;
            }

          }


          public class _friendId_ : UrlPart
          {
            private UrlPart _parent;
            object _friendId;

            public _friendId_(UrlPart parent, object friendId)
            {
              _parent = parent;
              _friendId = friendId;
            }

          }

        }

      }

    }


    public class Foo : UrlPart
    {
      private UrlPart _parent;

      public Foo(UrlPart parent)
      {
        _parent = parent;
      }


      public _id_ this[object id]
      {
        get { return new _id_(this, id); }
      }


      public class _id_ : UrlPart
      {
        private UrlPart _parent;
        object _id;

        public _id_(UrlPart parent, object id)
        {
          _parent = parent;
          _id = id;
        }


        public _id2_ this[object id2]
        {
          get { return new _id2_(this, id2); }
        }


        public class _id2_ : UrlPart
        {
          private UrlPart _parent;
          object _id2;

          public _id2_(UrlPart parent, object id2)
          {
            _parent = parent;
            _id2 = id2;
          }


          public Bar bar
          {
            get { return new Bar(this); }
          }


          public class Bar : UrlPart
          {
            private UrlPart _parent;

            public Bar(UrlPart parent)
            {
              _parent = parent;
            }

          }

        }

      }

    }


    public class Yadda_id_blah : UrlPart
    {
      private UrlPart _parent;
      object _id;

      public Yadda_id_blah(UrlPart parent, object id)
      {
        _parent = parent;
        _id = id;
      }

    }

  }
}
*/