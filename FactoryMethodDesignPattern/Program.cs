using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();
            CustomerManager customerManager2 = new CustomerManager(new LoggerFactory2());
            customerManager2.Save();
            Console.ReadLine(); 
        }

    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new ByLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }
    public interface ILogger
    {
        void Log();
    }
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }
    public class ByLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with ByLogger!");
        }
    }
    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger!");
        }
    }
    public class CustomerManager //iş yapılan bu nesnenin hiçbir bağımlılığı yok.
    {
        private ILoggerFactory _loggerFactory;
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
