using System;

namespace SingletonPatternExample
{
    // Step 2 & 3: Define and Implement the Singleton Class
    public class Logger
    {
        // Private static field to hold the single instance
        private static Logger _instance;

        // Object for thread safety (optional for multithreading)
        private static readonly object _lock = new object();

        // Private constructor to prevent external instantiation
        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        // Public static method to provide access to the single instance
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) // Ensures thread safety
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        // A method to simulate logging
        public void Log(string message)
        {
            Console.WriteLine("[LOG] " + message);
        }
    }

    // Step 4: Test the Singleton
    class Program
    {
        static void Main(string[] args)
        {
            // First usage of Logger
            Logger logger1 = Logger.GetInstance();
            logger1.Log("System startup in progress...");

            // Second usage of Logger
            Logger logger2 = Logger.GetInstance();
            logger2.Log("System running normally.");

            // Confirm both instances are the same
            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("Singleton works: Both logger instances are identical.");
            }
            else
            {
                Console.WriteLine("Singleton failed: Logger instances are different.");
            }

            Console.ReadLine(); // Keeps the console window open
        }
    }
}
