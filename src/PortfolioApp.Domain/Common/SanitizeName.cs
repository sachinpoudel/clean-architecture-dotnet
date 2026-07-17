using System.Text.RegularExpressions;
namespace PortfolioApp.Domain.Common;



    public interface ISanitizeName
    {
        bool Execute(string name);
    }
    public  class SanitizeName : ISanitizeName
    {
        public   bool Execute(string name)
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


