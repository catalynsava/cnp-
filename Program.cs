using System.Reflection.Metadata;
using System.Security;

namespace cnp_;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine( verificareCNP("1761103") );
    }
    
    public static string verificareCNP(string mCnp){
        string[] m = {"1", "3", "5", "7"};
        string[] f = ["2", "4", "6", "8"];
        string mesajValidare = "";
        //sex valid
        if (mCnp.Length > 0)
        {
            if (int.TryParse( mCnp.Substring(0,1), out _ ))
            {
                if(
                int.Parse( mCnp.Substring(0,1) ) > 0 
                && 
                int.Parse( mCnp.Substring(0,1) ) < 9
                ) {
                    if (m.Contains(mCnp.Substring(0,1)))
                    {
                        mesajValidare = "M";
                    }
                    else if ( f.Contains(mCnp.Substring(0,1)) )
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
        }
        //--
        mesajValidare += " ";
        // extrage anul nașterii
        if (mCnp.Length > 2)
        {
            if ( mCnp.All(Char.IsNumber) )
            {
                if(mCnp[0] == '1' || mCnp[0] == '2'){
                    mesajValidare += "19" + mCnp.Substring(1,2);
                }else if (mCnp[0] == '3' || mCnp[0] == '4')
                {
                    mesajValidare += "18" + mCnp.Substring(1,2);
                }else if (mCnp[0] == '5' || mCnp[0] == '6' || mCnp[0] == '7' || mCnp[0] == '8')
                {
                    if ( int.Parse("20" + mCnp.Substring(1,2)) <= DateTime.Now.Year )
                    {
                        mesajValidare += "20" + mCnp.Substring(1,2);
                    }else{
                        mesajValidare += "{?an}";
                    }
                }else{
                    mesajValidare += "{?an}";
                }
            }else{
                mesajValidare += "{?an}";
            }
        }else{
                mesajValidare += "{?an}";
        }
        //--
        mesajValidare += " ";  
        //extrage luna nașterii
        string[] lunileAnului = ["ianuarie", "februarie", "martie", "aprilie", "mai", "iunie", "iulie", "august", "septembrie", "octombrie", "noiembrie", "decembrie"];
        if ( mCnp.Length > 4 )
        {
            if ( mCnp.Substring(3,2).All(Char.IsNumber) ){
                 if( int.Parse(mCnp.Substring(3,2)) > 0 && int.Parse(mCnp.Substring(3,2)) < 13 ){
                    mesajValidare += lunileAnului[int.Parse(mCnp.Substring(3,2))-1];
                 }else{
                    mesajValidare += "{?luna}";
                 }
            }else{
                mesajValidare += "{?luna}";
            }
        } else {
            mesajValidare += "{?luna}";
        }
        //--
        mesajValidare += " ";
        // extrage ziua nașterii
        if (mCnp.Length > 6)
        {
            if ( mCnp.Substring(5,2).All(Char.IsNumber) )
            {
                mesajValidare += mCnp.Substring(5,2);
            }else{
                mesajValidare += "{?zi}";
            }
        }else{
            mesajValidare += "{?zi}";
        }
        //--
        mesajValidare += " ";
        // data nasterii validă
        string tmpAn;
        string tmpLuna;
        string tmpZi;
        if (mCnp.Length > 6)
        {
            if (mCnp.All(Char.IsNumber))
            {
                if( mCnp.Substring(0,1) == "1" || mCnp.Substring(0,1) == "2" ){
                    tmpAn = "19" + mCnp.Substring(1,2);
                }else if( mCnp.Substring(0,1) == "3" || mCnp.Substring(0,1) == "4" ){
                    tmpAn = "18" + mCnp.Substring(1,2);
                }else if( mCnp.Substring(0,1) == "5" || mCnp.Substring(0,1) == "6" || mCnp.Substring(0,1) == "7" || mCnp.Substring(0,1) == "8" ){
                    tmpAn = "20" + mCnp.Substring(1,2);
                }else{
                    tmpAn = "0000";
                }
                tmpLuna = mCnp.Substring(3,2);
                tmpZi = mCnp.Substring(5,2);
                if( DateTime.TryParse(tmpAn + "-" + tmpLuna + "-" + tmpZi, out _) ){
                    mesajValidare += "";
                }else{
                    mesajValidare += "{?data}";
                }
            }else{
                mesajValidare += "{?data}";
            }
        }else{
            mesajValidare += "{?data}";
        }
        return mesajValidare;
    }
}

