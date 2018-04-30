using System.Threading.Tasks;

namespace SR.Xam.Sample.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "");
    }
}