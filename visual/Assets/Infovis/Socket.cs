using Infovis.Protobuf;
using WebSocketSharp;
using WebSocketSharp.Server;

using Convert = System.Convert;
using Debug   = UnityEngine.Debug;


namespace Infovis {

  public class GeometrySocket : WebSocketBehavior {

    protected override void OnOpen() {
      Debug.Log("GeometrySocket: opened.");
    }

    protected override void OnMessage(MessageEventArgs evt) {
      byte[] bytes = evt.IsText ? Convert.FromBase64String(evt.Data) : evt.RawData;
      Request request = Request.Parser.ParseFrom(bytes);
      Infovis.State.Process(request);
    }

    protected override void OnError(ErrorEventArgs evt) {
      Debug.Log("GeometrySocket: " + evt);
    }

    protected override void OnClose(CloseEventArgs evt) {
      Debug.Log("GeometrySocket: " + evt);
    }

  }

}
