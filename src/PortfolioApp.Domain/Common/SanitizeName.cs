using System.Text.RegularExpressions;
namespace PortfolioApp.Domain.Common;


public  static class SanitizeName
{
    public interface ISanitizeName
    {
        bool SanitizeName(string name);
    }
    public class SanitizeNameImpl : ISanitizeName
    {
        public bool SanitizeName(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) return false;

            foreach (char  c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

