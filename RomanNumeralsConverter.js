/*
  written by: Dawit Hailu
  objective:
    given given an Integer, return coresponding Roman Numeral representation
    simple eg: 10 >> "X"
    
    check it out in action! simply go to the link and click run.
    repl link: https://repl.it/OEFE/3

  contact: davucan@gmail.com
*/

numeralConverter(10);

function numeralConverter(numString, str) {
  str = str ? str:"";
  var number = Math.floor(numString);
  var rom_sym = [["I","V"],["X","L"],["C","D"],["M",""]]
  var indx = String(number).length - 1;
  var denum = number / Math.pow(10, indx);
  denum = Math.floor(denum);
  var array = [];

  array.push(Math.floor(denum/5), denum %5);

  str += (array[1] == 4) ? (rom_sym[indx][0] + rom_sym[array[0] + indx][1 - array[0]]) :
  (rom_sym[indx][1].repeat(array[0])  + rom_sym[indx][0].repeat(array[1]));
  number -= denum * Math.pow(10, indx);
  numString = String(number);
  return (indx === 0) ? str : numeralConverter(number, str);
}
