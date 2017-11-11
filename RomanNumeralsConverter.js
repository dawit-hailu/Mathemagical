/*
  Author: Dawit Hailu
  objective:
    given given an Integer, return coresponding Roman Numeral representation where 0 < n < 100,000.
    simple eg: 10 >> "X"
    
    check it out in action! simply go to the link and click run.
    repl link: https://repl.it/OEFE/5

  contact: davucan@gmail.com
*/
//used 10 for the sake of simplicity
numeralConverter(10);
//=> "X"

function numeralConverter(input_number, result) {
  //check if this is the first run(recursion), if so assign empty string to result
  result = result ? result : "";

  //roud down the number to the nearest integer
  var number = Math.floor(input_number);

  //roman symbol reference dictionary
  var roman_symbol_reference = [["I","V"],["X","L"],["C","D"],["M","(V)"],["(X)","(L)"]]

  //get exponent magnitued
  //=> 1 for our example
  var exponent_factor = String(number).length - 1;

  //calculate first digit
  // 10/10^1 => 1
  var left_most_digit = number / Math.pow(10, exponent_factor);
  left_most_digit = Math.floor(left_most_digit);
  var temp_array = [];

  //calculate symbol indeces
  temp_array.push(Math.floor(left_most_digit/5), left_most_digit %5);

  result += (temp_array[1] == 4) ?
        (
          roman_symbol_reference[exponent_factor][0] +
          roman_symbol_reference[temp_array[0] + 
          exponent_factor][1 - temp_array[0]]
        ) 
        :
        (
          roman_symbol_reference[exponent_factor][1].repeat(temp_array[0]) +
          roman_symbol_reference[exponent_factor][0].repeat(temp_array[1])
        );
        
  number -= left_most_digit * Math.pow(10, exponent_factor);
  return (exponent_factor === 0) ? result : numeralConverter(number, result);
}
