using System.Threading.Tasks;

namespace SR.Xam.Sample.Services
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string message, string title, string buttonLabel);
    }
}
