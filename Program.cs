using System.Reflection.Metadata;
using System.Security;

namespace cnp_;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine( verificareCNP("1") );
    }
    private static readonly string[] m = {"1", "3", "5", "7"};
    private static readonly string[] f = ["2", "4", "6", "8"];
    public static string verificareCNP(string mCnp){
        string mesajValidare = "";
         //sex valid
        if (mCnp.Length > 0)
        {
            if (int.TryParse( mCnp, out _ ))
            {
                if(
                int.Parse( mCnp.Substring(0,1) ) > 0 
                && 
                int.Parse( mCnp.Substring(0,1) ) < 9
                ) {
                    if (m.Contains(mCnp))
                    {
                        mesajValidare = "M";
                    }
                    else if ( f.Contains(mCnp) )
                    {
                        mesajValidare = "F";
                    }else{
                        mesajValidare = "{sex?}";
                    }
                }else
                {
                     mesajValidare = "{sex?}";
                }
            }else
            {
                mesajValidare ="{sex?}";
            }
            mesajValidare += ' ';
            // anul nașterii
            
        }
         
        
        

        return mesajValidare;
    }
}

