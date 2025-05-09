using System.Reflection.Metadata;
using System.Security;

namespace cnp_;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine( verificareCNP(args[0]) );
    }
    
    public static string verificareCNP(string pCnp){
        string[] m = {"1", "3", "5", "7"};
        string[] f = ["2", "4", "6", "8"];
        string mesajValidare = "";
        //sex valid
        if (pCnp.Length > 0)
        {
            if (int.TryParse( pCnp.Substring(0,1), out _ ))
            {
                if(
                int.Parse( pCnp.Substring(0,1) ) > 0 
                && 
                int.Parse( pCnp.Substring(0,1) ) < 9
                ) {
                    if (m.Contains(pCnp.Substring(0,1)))
                    {
                        mesajValidare = "M";
                    }
                    else if ( f.Contains(pCnp.Substring(0,1)) )
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
        if (pCnp.Length > 2)
        {
            if ( pCnp.All(Char.IsNumber) )
            {
                if(pCnp[0] == '1' || pCnp[0] == '2'){
                    mesajValidare += "19" + pCnp.Substring(1,2);
                }else if (pCnp[0] == '3' || pCnp[0] == '4')
                {
                    mesajValidare += "18" + pCnp.Substring(1,2);
                }else if (pCnp[0] == '5' || pCnp[0] == '6' || pCnp[0] == '7' || pCnp[0] == '8')
                {
                    if ( int.Parse("20" + pCnp.Substring(1,2)) <= DateTime.Now.Year )
                    {
                        mesajValidare += "20" + pCnp.Substring(1,2);
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
        if ( pCnp.Length > 4 )
        {
            if ( pCnp.Substring(3,2).All(Char.IsNumber) ){
                 if( int.Parse(pCnp.Substring(3,2)) > 0 && int.Parse(pCnp.Substring(3,2)) < 13 ){
                    mesajValidare += lunileAnului[int.Parse(pCnp.Substring(3,2))-1];
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
        if (pCnp.Length > 6)
        {
            if ( pCnp.Substring(5,2).All(Char.IsNumber) )
            {
                mesajValidare += pCnp.Substring(5,2);
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
        if (pCnp.Length > 6)
        {
            if (pCnp.All(Char.IsNumber))
            {
                if( pCnp.Substring(0,1) == "1" || pCnp.Substring(0,1) == "2" ){
                    tmpAn = "19" + pCnp.Substring(1,2);
                }else if( pCnp.Substring(0,1) == "3" || pCnp.Substring(0,1) == "4" ){
                    tmpAn = "18" + pCnp.Substring(1,2);
                }else if( pCnp.Substring(0,1) == "5" || pCnp.Substring(0,1) == "6" || pCnp.Substring(0,1) == "7" || pCnp.Substring(0,1) == "8" ){
                    tmpAn = "20" + pCnp.Substring(1,2);
                }else{
                    tmpAn = "";
                }
                tmpLuna = pCnp.Substring(3,2);
                tmpZi = pCnp.Substring(5,2);
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
        //--
        //mesajValidare += " ";
        // judet
        string[] judete = ["Alba", "Arad", "Argeș", "Bacău", "Bihor", "Bistrița-Năsăud", "Botoșani", "Brașov", "Brăila", "Buzău", "Caraș-Severin", "Cluj", "Constanța", "Covasna", "Dâmbovița", "Dolj", "Galați", "Gorj", "Harghita", "Hunedoara", "Ialomița", "Iași", "Ilfov", "Maramureș", "Mehedinți", "Mureș", "Neamț", "Olt", "Prahova", "Satu Mare", "Sălaj", "Sibiu", "Suceava", "Teleorman", "Timiș", "Tulcea", "Vaslui", "Vâlcea", "Vrancea", "București", "București - Sector 1", "București - Sector 2", "București - Sector 3", "București - Sector 4", "București - Sector 5", "București - Sector 6", "Călărași", "Giurgiu", "Bucuresti - Sector 7 (desființat)", "Bucuresti - Sector 8 (desființat)"];
        if (pCnp.Length > 8)
        {
            if ( pCnp.Substring(7,2).All(Char.IsNumber) )
            {
                if ( int.Parse(pCnp.Substring(7,2)) <= 50 )
                {
                    mesajValidare += judete[int.Parse(pCnp.Substring(7,2))-1];
                }else
                {
                    mesajValidare += "{?județ}";
                }
            }else{
                mesajValidare += "{?județ}";
            }
        }else
        {
            mesajValidare += "{?județ}";
        }
        //--
        mesajValidare += " ";
        //cifra control
        int[] control = { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9 };
        int suma = 0;

        if (pCnp.Length > 11)
        {
            for (int i = 0; i < 12; i++)
            {
                suma += (pCnp[i] - '0') * control[i];
            }
            int rest = suma % 11;
            int cifraControl = rest == 10 ? 1 : rest;
            if ( pCnp.Length > 12 )
            {
                if (int.Parse(pCnp.Substring(12,1)) != cifraControl)
                {
                    mesajValidare += pCnp.Substring(12,1) + "->" + cifraControl;
                }else{
                    mesajValidare += "{valid}";
                }
            }else{
                mesajValidare += pCnp + "?" + "->" + cifraControl;
            }
            
        }else{
            mesajValidare += "{?cifra.control}";
        }
        return mesajValidare;
    }
}

