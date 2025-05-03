using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;

namespace toyproject
{
    internal class RedisConn
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var options = new ConfigurationOptions
            {
                EndPoints = { "127.0.0.1:6379" },
                Password = "admin1234",
                AllowAdmin = true,
                AbortOnConnectFail = false,
                ConnectTimeout = 5000,
                SyncTimeout = 5000
            };

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(options);

            return redis;
        });

        public static ConnectionMultiplexer Connection => lazyConnection.Value;

        public static IDatabase RedisDB => Connection.GetDatabase();

        public static void TestConnection()
        {
            //try
            //{
            //    var db = RedisConn.RedisDB;
            //    db.Multiplexer.GetSubscriber().Subscribe("BingoCh:1", (channel, message) =>
            //    {
                    
            //    });
            //    db.Publish("BingoCh:1", "Hi");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Redis Connection test failed: {ex.Message}");
            //}
        }
    }
}
