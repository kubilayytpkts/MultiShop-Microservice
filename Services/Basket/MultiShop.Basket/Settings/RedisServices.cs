using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisServices
    {
        public string _Host { get; set; }
        public int _Port { get; set; }
        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisServices(string Host, int Port)
        {
            _Host = Host;
            _Port = Port;
        }
        public void Connect()=>_connectionMultiplexer = ConnectionMultiplexer.Connect($"{_Host}:{_Port}");
        public IDatabase GetDb(int db=1)=>_connectionMultiplexer.GetDatabase(0);
    }
}
