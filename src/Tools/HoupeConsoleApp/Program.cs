// ***********************************************************************
// Solution         : HoupeSolution
// Project          : HoupeConsoleApp
// File             : Program.cs
// CreatedAt        : 2020-05-10
// LastModifiedAt   : 2022-08-15
// LastModifiedBy   : Siqi Lu
// ***********************************************************************

using System;
using System.Linq;
using Houpe.Foundation;
using Houpe.Infrastructure;

namespace HoupeConsoleApp
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            args.Select((s, i) => (index: i, arg: s)).ToList()
                .ForEach(e => Console.WriteLine($@"args[{e.index}]: {e.arg}."));

            IDateTimeService service = new DateTimeService();

            Console.WriteLine("Load Houpe package with version {version} at {time}.".FormatWithValues(Houpe.Houpe.Version, service.UtcNow.ToReadableString()));

            _ = Console.ReadKey();
        }
    }
}
