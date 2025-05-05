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

        public static long Sub_Count(string Ch_name)
        {
            try
            {
                var db = RedisConn.RedisDB;

                RedisResult result = db.Execute("PUBSUB", "NUMSUB", Ch_name);

                var arr = (RedisResult[])result;
                var subcnt = (long)arr[1];

                return subcnt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Redis pubsub err : {ex}");
            }
            return 0;
        }
    }
}
