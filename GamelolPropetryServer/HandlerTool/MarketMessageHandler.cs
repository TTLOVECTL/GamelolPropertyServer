using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceNetFrame.ace;
using AceNetFrame.ace.auto;
using SerializableDataMessage;
using GamelolPropetryServer.Database;
using LitJson;
namespace GamelolPropetryServer.HandlerTool
{
    public class MarketMessageHandler : HanderInterface
    {
        public void ClientClose(UserToken token)
        {
            throw new NotImplementedException();
        }

        public void MessageRecevie(UserToken token, SocketModel message)
        {
            switch ((MarketCommand)message.command) {
                case MarketCommand.BUY_COMMAND:
                    BuyGoodFromMarket(token, message);
                    break;
                case MarketCommand.SELL_COMMAND:
                    SellGoodToMarket(token, message);
                    break;

            }
        }

        /// <summary>
        /// 处理从商城里购买物品
        /// </summary>
        /// <param name="token"></param>
        /// <param name="message"></param>
        public void BuyGoodFromMarket(UserToken token,SocketModel message) {
            Console.WriteLine(message.getMessage<string>());
            MarketMessage marketMessage =JsonMapper.ToObject<MarketMessage>(message.getMessage<string>());
            switch ((GoodType)marketMessage.goodType) {
                case GoodType.INSCRIPTION:
                    new BaseMessageDatabase().UpdatePlayerReduceInscriptionnumber(message.type, marketMessage.goodPrice);
                    new InscriptionMessageDatabase().UpdatePlayerInscription(message.type,marketMessage.goodId,marketMessage.goodNumber);
                    message.message = true;
                    SendtoClient.write(token,message);
                    break;
                case GoodType.HERO:

                    break;
            }
        }

        /// <summary>
        /// 处理卖出物品给商店
        /// </summary>
        /// <param name="token"></param>
        /// <param name="message"></param>
        public void SellGoodToMarket(UserToken token, SocketModel message) {
            MarketMessage marketMessage = JsonMapper.ToObject<MarketMessage>(message.getMessage<string>());
            switch (marketMessage.goodType)
            {
                case GoodType.INSCRIPTION:
                    new BaseMessageDatabase().UpdatePlayerAddInscriptionnumber(message.type, marketMessage.goodPrice);
                    new InscriptionMessageDatabase().UpdatePlayerInscriptionNumber(message.type, marketMessage.goodId, -marketMessage.goodNumber);
                    message.message = true;
                    SendtoClient.write(token, message);
                    break;
                case GoodType.HERO:
                    break;
            }
        }
    }
}
