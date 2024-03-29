﻿using Amqp;
using System;

namespace Consumer
{
  
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Consumer Started");
            Consumer();
            Console.ReadLine();
        }

        private static async void Consumer()
        {
            try
            {
                Connection connection = new Connection(new Address("amqp://admin:admin@localhost:5672"));
                Session session = new Session(connection);

                //ReceiverLink receiver = new ReceiverLink(session, "receiver-link2", "q1");
                ReceiverLink receiver = new ReceiverLink(session, "receiver-link2", "topic://q1");
                while (true)
                {
                Message message = await receiver.ReceiveAsync();
                Console.WriteLine(message.Body.ToString());
                receiver.Accept(message);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
