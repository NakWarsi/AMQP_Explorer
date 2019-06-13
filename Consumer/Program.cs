using Amqp;
using System;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Producer Started");
            Sender();
            Console.ReadLine();
        }
        private static async void Sender()
        {
            try
            {
                //while (true)
                //{
                    var address = new Address("localhost", 5672, "admin", "admin");
                    //Connection connection = await Connection.Factory.CreateAsync(address);
                    Connection connection = new Connection(new Address("amqp://admin:admin@localhost:5672"));
                    Session session = new Session(connection);
                    string msgstr = Console.ReadLine();
                    Message message = new Message(msgstr);
                    SenderLink sender = new SenderLink(session, "sender-link", "q1");
                    await sender.SendAsync(message);

              //  }
          


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
