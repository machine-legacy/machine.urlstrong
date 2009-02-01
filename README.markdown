## Make your routes first class, type-safe, explicit citizens.

Just getting started here, not much written yet. Plan to be framework agnostic.

### Turn this:

    GET /home
    GET /user/[id]
    GET /user/[id]/friend/list
    GET|POST /user/[id]/friend/[friendId]
    GET /foo/[id]
    GET /foo/[id]/[id2]
    GET /foo/[id]/[id2]/bar


### Into this:

    RedirectTo(root.user[id].friend.list);
    RedirectTo(root.foo[id][id2]);
    UrlOf(root.user[id].friend[friendId]);

