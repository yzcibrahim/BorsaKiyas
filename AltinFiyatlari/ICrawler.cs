using System.Threading.Tasks;

namespace AltinFiyatlari
{
    public interface ICrawler
    {
        Task<bool> Crawle();
    }
}