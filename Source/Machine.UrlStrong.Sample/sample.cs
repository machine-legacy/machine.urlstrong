using Machine.UrlStrong;

namespace Machine.UrlStrong.Sample
{
  public static class Url
  {
    public static Root root { get { return new Root(null); } }
    
        
    public class Root : UrlPart, ISupportGet
    {
      
      public Root(UrlPart parent)
        : base(parent)
      {
      }
      
      public override string ToString()
      {
        return "/";
      }
      
      public override string ToParameterizedUrl()
      {
        return "/";
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
    
        
      public class Home : UrlPart, ISupportGet
      {
        
        public Home(UrlPart parent)
          : base(parent)
        {
        }
        
        public override string ToString()
        {
          return Join(_parent.ToString(), "home");
        }
        
        public override string ToParameterizedUrl()
        {
          return Join(_parent.ToParameterizedUrl(), "home");
        }
      
      }
    
        
      public class User : UrlPart
      {
        
        public User(UrlPart parent)
          : base(parent)
        {
        }
        
        public override string ToString()
        {
          return Join(_parent.ToString(), "user");
        }
        
        public override string ToParameterizedUrl()
        {
          return Join(_parent.ToParameterizedUrl(), "user");
        }
      
          
        public _id_ this[object id]
        {
          get { return new _id_(this, id); }
        }
      
          
        public class _id_ : UrlPart, ISupportGet
        {
          readonly object _id;
          
          public _id_(UrlPart parent, object id)
            : base(parent)
          {
            _id = id;
            AddParameter("id", id);
          }
          
          public override string ToString()
          {
            return Join(_parent.ToString(), _id.ToString());
          }
          
          public override string ToParameterizedUrl()
          {
            return Join(_parent.ToParameterizedUrl(), "{id}");
          }
        
            
          public Friend friend
          {
            get { return new Friend(this); }
          }
        
            
          public class Friend : UrlPart
          {
            
            public Friend(UrlPart parent)
              : base(parent)
            {
            }
            
            public override string ToString()
            {
              return Join(_parent.ToString(), "friend");
            }
            
            public override string ToParameterizedUrl()
            {
              return Join(_parent.ToParameterizedUrl(), "friend");
            }
          
              
            public List list
            {
              get { return new List(this); }
            }
          
              
            public _friendId_ this[object friendId]
            {
              get { return new _friendId_(this, friendId); }
            }
          
              
            public class List : UrlPart, ISupportGet
            {
              
              public List(UrlPart parent)
                : base(parent)
              {
              }
              
              public override string ToString()
              {
                return Join(_parent.ToString(), "list");
              }
              
              public override string ToParameterizedUrl()
              {
                return Join(_parent.ToParameterizedUrl(), "list");
              }
            
            }
          
              
            public class _friendId_ : UrlPart, ISupportGet, ISupportPost
            {
              readonly object _friendId;
              
              public _friendId_(UrlPart parent, object friendId)
                : base(parent)
              {
                _friendId = friendId;
                AddParameter("friendId", friendId);
              }
              
              public override string ToString()
              {
                return Join(_parent.ToString(), _friendId.ToString());
              }
              
              public override string ToParameterizedUrl()
              {
                return Join(_parent.ToParameterizedUrl(), "{friendId}");
              }
            
            }
          
          }
        
        }
      
      }
    
        
      public class Foo : UrlPart
      {
        
        public Foo(UrlPart parent)
          : base(parent)
        {
        }
        
        public override string ToString()
        {
          return Join(_parent.ToString(), "foo");
        }
        
        public override string ToParameterizedUrl()
        {
          return Join(_parent.ToParameterizedUrl(), "foo");
        }
      
          
        public _id_ this[object id]
        {
          get { return new _id_(this, id); }
        }
      
          
        public class _id_ : UrlPart, ISupportGet
        {
          readonly object _id;
          
          public _id_(UrlPart parent, object id)
            : base(parent)
          {
            _id = id;
            AddParameter("id", id);
          }
          
          public override string ToString()
          {
            return Join(_parent.ToString(), _id.ToString());
          }
          
          public override string ToParameterizedUrl()
          {
            return Join(_parent.ToParameterizedUrl(), "{id}");
          }
        
            
          public _id2_ this[object id2]
          {
            get { return new _id2_(this, id2); }
          }
        
            
          public class _id2_ : UrlPart, ISupportGet
          {
            readonly object _id2;
            
            public _id2_(UrlPart parent, object id2)
              : base(parent)
            {
              _id2 = id2;
              AddParameter("id2", id2);
            }
            
            public override string ToString()
            {
              return Join(_parent.ToString(), _id2.ToString());
            }
            
            public override string ToParameterizedUrl()
            {
              return Join(_parent.ToParameterizedUrl(), "{id2}");
            }
          
              
            public Bar bar
            {
              get { return new Bar(this); }
            }
          
              
            public class Bar : UrlPart, ISupportGet
            {
              
              public Bar(UrlPart parent)
                : base(parent)
              {
              }
              
              public override string ToString()
              {
                return Join(_parent.ToString(), "bar");
              }
              
              public override string ToParameterizedUrl()
              {
                return Join(_parent.ToParameterizedUrl(), "bar");
              }
            
            }
          
          }
        
        }
      
      }
    
        
      public class Yadda_id_blah : UrlPart, ISupportGet
      {
        readonly object _id;
        
        public Yadda_id_blah(UrlPart parent, object id)
          : base(parent)
        {
          _id = id;
          AddParameter("id", id);
        }
        
        public override string ToString()
        {
          return Join(_parent.ToString(), string.Format("yadda{0}blah", _id));
        }
        
        public override string ToParameterizedUrl()
        {
          return Join(_parent.ToParameterizedUrl(), "yadda{id}blah");
        }
      
      }
    
    }
  }
}