const ValidareCnp = function(cnp){
  let mesajValidare = '';
  //sex valid
    const m = ['1', '3', '5', '7']
    const f = ['2', '4', '6', '8']
    if (cnp.length > 0) {
      if(!isNaN(parseInt(cnp.substring(0,1)))){
        if (cnp.substring(0,1) < 9 && cnp.substring(0,1)>0) {
            if(m.includes(cnp.substring(0,1))){ 
              mesajValidare = 'M';
            }else if(f.includes(cnp.substring(0,1))){ 
              mesajValidare = 'F';
            }else{ 
              mesajValidare = '{?sex}'; 
            }
      }else{ 
        mesajValidare = '{?sex}';
      }
    }else{ 
      mesajValidare = '{?sex}';
    }
  }
//--
mesajValidare += ' ';
// anul nașterii
  if (cnp.length > 2) {
    if(cnp.substring(0,3).split('').some(
          function(val){ if(isNaN(val)){ return true; }else{ return false;} }
        ))
    {
      mesajValidare += '{?an}';
    }else{
      if(cnp[0] === '1' || cnp[0] === '2'){ 
        mesajValidare += '19' + cnp.substring(1,3);
      }else if(cnp[0] === '3' || cnp[0] === '4'){ 
        mesajValidare += '18' + cnp.substring(1,3);
      } else if(cnp[0] === '5' || cnp[0] === '6' || cnp[0] === '7' || cnp[0] === '8' ){
        mesajValidare+= '20' + cnp.substring(1,3);
      } else {
        mesajValidare += '{?an}';
      }
    } 
  }else{ 
    mesajValidare += '{?an}';
  }
//--
mesajValidare += ' ';  
//luna nașterii
  lunileAnului = ['ianuarie', 'februarie', 'martie', 'aprilie', 'mai', 'iunie', 'iulie', 'august', 'septembrie', 'octombrie', 'noiembrie', 'decembrie'];
  if (cnp.length > 4) {
    if(cnp.substring(3,5).split('').every((val) => !isNaN(parseInt(val)))){
      if( parseInt(cnp.substring(3,5)) > 0 && parseInt(cnp.substring(3,5)) < 13){
        mesajValidare += lunileAnului[parseInt(cnp.substring(3,5))-1];
      }else{ 
        mesajValidare += '{?luna}';
      }
    }else{ 
      mesajValidare += '{?luna}';
    }
  }else{ 
    mesajValidare += '{?luna}';
  }
//--
mesajValidare += ' ';
// ziua nașterii
  if (cnp.length > 6) {
    if(cnp.substring(5,7).split('').every((val) => !isNaN(parseInt(val)))){
      if( parseInt(cnp.substring(5,7)) > 0 && parseInt(cnp.substring(5,7)) < 32){
        mesajValidare += cnp.substring(5,7);
      }else{ 
        mesajValidare += '{?zi}';
      }
    }else{ 
      mesajValidare += '{?zi}';
    }
  }else{ 
    mesajValidare += '{?zi}';
  }
//--
mesajValidare += ' ';
// data nasterii valida
  var tmpAn='';
  var tmpLuna='';
  var tmpZi='';
  if (cnp.length > 6){
    if(cnp.substring(0,5).split('val').every((val) => !isNaN(val))){
      if(cnp.substring(0,1) === '1' || cnp.substring(0,1) === '2'){
        tmpAn = '19' + cnp.substring(1,3);
      }else if(cnp.substring(0,1) === '3' || cnp.substring(0,1) === '4'){
        tmpAn = '18' + cnp.substring(1,3);
      }else if(cnp.substring(0,1) === '5' || cnp.substring(0,1) === '6' || cnp.substring(0,1) === '7' || cnp.substring(0,1)==='8'){
        tmpAn = '20' + cnp.substring(1,3);
      }
      tmpLuna = cnp.substring(3,5);
      tmpZi = cnp.substring(5,7);
      const tmpDate =new Date(parseInt(tmpAn), parseInt(tmpLuna)-1, parseInt(tmpZi));
      if(
        tmpDate.getDate() == parseInt( tmpZi )
        && tmpDate.getMonth()+1 == parseInt( tmpLuna )
        && tmpDate.getFullYear() == parseInt( tmpAn )
      ){
        mesajValidare += '';
      }else{
        mesajValidare += '{?data}';
      }
    }else{
      mesajValidare += '{?data}';
    }
  }else{
    mesajValidare += '{?data}';
  }
//--
// judet
  const  arrJudete = ["Alba", "Arad", "Argeș", "Bacău", "Bihor", "Bistrița-Năsăud", "Botoșani", "Brașov", "Brăila", "Buzău", "Caraș-Severin", "Cluj", "Constanța", "Covasna", "Dâmbovița", "Dolj", "Galați", "Gorj", "Harghita", "Hunedoara", "Ialomița", "Iași", "Ilfov", "Maramureș", "Mehedinți", "Mureș", "Neamț", "Olt", "Prahova", "Satu Mare", "Sălaj", "Sibiu", "Suceava", "Teleorman", "Timiș", "Tulcea", "Vaslui", "Vâlcea", "Vrancea", "București", "București - Sector 1", "București - Sector 2", "București - Sector 3", "București - Sector 4", "București - Sector 5", "București - Sector 6", "Călărași", "Giurgiu", "Bucuresti - Sector 7 (desființat)", "Bucuresti - Sector 8 (desființat)"];
  if (cnp.length > 8) {
    if(cnp.substring(7,9).split('').every((val) => !isNaN(parseInt(val)))){
      if (arrJudete[parseInt(cnp.substring(7,9))-1] !== undefined){
        mesajValidare += arrJudete[
            parseInt(cnp.substring(7,9))-1
          ];
      }else{
        mesajValidare += '{?județ}';
      }
    }else{ 
      mesajValidare += '{?județ}';
    }
  }else{ 
    mesajValidare += '{?județ}';
  }
//--
//cifra control
  const contrlArr=[2,7,9,1,4,6,3,5,8,2,7,9];
  var contrResult=0;
      for( i=0 ; i<13 ; i++ ) {
          cnp[i] = parseInt( cnp.charAt(i) , 10 );
          if( isNaN( cnp[i] ) ) { 
            mesajValidare += '';
          }
          if( i < 12 ) { 
            contrResult = contrResult + ( cnp[i] * contrlArr[i] ); 
          }
      }
      contrResult = contrResult % 11;
      if( contrResult === 10 ) { contrResult = 1; }
      if( parseInt(cnp[12]) !== contrResult ){
          if(cnp.length == 13){
            mesajValidare += '{' + contrResult  + "->" + cnp[12] + '}';
          }else if(cnp.length == 12){
            mesajValidare += '{' + contrResult  + "->" + '}';
          }else{
            mesajValidare +='';
          }
      }else{
        mesajValidare += '';
      }
  return mesajValidare;
}

//let param = '176050627';
//console.log(ValidareCnp(param));