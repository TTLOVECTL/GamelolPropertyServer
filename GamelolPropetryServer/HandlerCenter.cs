using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
using GamelolPropetryServer.HandlerTool;
using SerializableDataMessage;
namespace GamelolPropetryServer
{
    public class HandlerCenter : AbsHandleCenter
    {
        private HanderInterface marketMessageHandler;

        public HandlerCenter() {
            marketMessageHandler = new MarketMessageHandler();
        }
        public override void ClientClose(UserToken token, string error)
        {
            //throw new NotImplementedException();
        }

        public override void MessageRecive(UserToken token, object message)
        {
            SocketModel model=message as SocketModel;
            switch ((PropetryArea)model.area) {
                case PropetryArea.MARKET_AREA:
                    marketMessageHandler.MessageRecevie(token,model);
                    break;
            }

        }
    }
}
