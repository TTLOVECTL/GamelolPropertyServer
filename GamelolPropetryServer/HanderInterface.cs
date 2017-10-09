using AceNetFrame.ace;
using AceNetFrame.ace.auto;

namespace GamelolPropetryServer
{
    public interface HanderInterface
    {
        void MessageRecevie(UserToken token, SocketModel message);
        void ClientClose(UserToken token);
    }
}
