using PrimeNumbersGenerator;
using System.Linq;
using System.Threading.Tasks;

namespace DemoBlazorApp.Data
{
    public class PrimesDataService
    {
        public Task<ulong[,]> GetPrimesAsync(int count)
        {
            return Task.FromResult(MultiplicationTable.GetGrid(PrimeService.Instance.FindPrimes(count).ToList()));
        }
    }
}
