using System;
using System.Linq;
using System.Reflection;
using Employee.Client.Contracts;

namespace Employee.Client.Core
{
    public class CommandParser
    {
        public static ICommand Parse(IServiceProvider serviceProvider, string commandName)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(ICommand)));

            var commandType = commandTypes.SingleOrDefault(x=>x.Name.StartsWith(commandName,StringComparison.InvariantCulture));

            var constructor = commandType.GetConstructors().FirstOrDefault();

            var constructorParams = constructor
                .GetParameters()
                .Select(pi=>pi.ParameterType).ToArray();

            var constructorArgs = constructorParams
                .Select(serviceProvider.GetService)
                .ToArray();


            ICommand command = (ICommand)constructor.Invoke(constructorArgs);

            return command;
        }
    }
}
