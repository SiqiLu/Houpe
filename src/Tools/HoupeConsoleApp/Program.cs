// ***********************************************************************
// Solution         : HoupeSolution
// Project          : HoupeConsoleApp
// File             : Program.cs
// CreatedAt        : 2023-01-10
// LastModifiedAt   : 2023-01-14
// LastModifiedBy   : lu.siqi(lu.siqi@outlook.com)
// ***********************************************************************

using Houpe.Foundation;
using Houpe.Infrastructure;

namespace HoupeConsoleApp;

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
