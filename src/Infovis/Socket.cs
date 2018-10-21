using Infovis.Protobuf;
using System;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace Infovis {

  public class GeometrySocket : WebSocketBehavior {

    protected override void OnOpen() {
    }

    protected override void OnMessage(MessageEventArgs evt) {
      byte[] bytes = evt.IsText ? Convert.FromBase64String(evt.Data) : evt.RawData;
      Request request = Request.Parser.ParseFrom(bytes);
      Console.WriteLine(request);
      lock (cache) {
        cache.Update(request);
        cache.Dump("  ");
      }
    }

    protected override void OnError(ErrorEventArgs evt) {
      Console.WriteLine(evt);
    }

    protected override void OnClose(CloseEventArgs evt) {
      Console.WriteLine(evt);
    }

    private Cache cache = new Cache();

  }

}