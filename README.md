# Civic.cs
Web-API for [civicapi.org](https://civicapi.org/) which is a free politicial API, offering up-to-the-minute election results, data, race calls, etc for all elections

## Example
```cs
using CivicApi;

namespace Application
{
    internal class Program
    {
        static async Task Main()
        {
            var api = new Civic();
            string electionDates = await api.GetElectionDates();
            Console.WriteLine(electionDates);
        }
    }
}
```
