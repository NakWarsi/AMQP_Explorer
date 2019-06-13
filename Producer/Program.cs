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
            try
            {
                Address address = new Address("amqp://admin:admin@localhost:5672");
                while (true)
                {
                    Connection connection = new Connection(new Address("amqp://admin:admin@localhost:5672"));

                    Session session = new Session(connection);

                    Console.WriteLine("write something to send");
                    string msgstr = Console.ReadLine();
                    Message message = new Message(msgstr);
                    SenderLink sender = new SenderLink(session, "sender-link", "q1");
                    sender.SendAsync(message);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.ReadLine();
        }
    }
}
