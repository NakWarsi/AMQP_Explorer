using Amqp;
using System;
using System.Threading.Tasks;

namespace Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Producer Started");
            CommunicateToBrokerAsync();
            Console.ReadLine();
        }

        private static async void CommunicateToBrokerAsync()
        {
            try
            {
                var address = new Address("localhost", 5672, "admin", "admin");
                //Connection connection = await Connection.Factory.CreateAsync(address);
                Connection connection = new Connection(new Address("amqp://admin:admin@localhost:5672"));
                Session session = new Session(connection);
                Message message = new Message("Hello AMQP");
                SenderLink sender = new SenderLink(session, "sender-link", "q1");
                await sender.SendAsync(message);
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
    }
}
