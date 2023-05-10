/ Each of these questions asks you to write an F# function
// by filling in the code on a `let...` line. 
//
// You can test your implementation by first putting your cursor on
// the `let...` line and hitting Alt-Enter. This defines
// your function in the terminal window. Then put your cursor
// on each of the following lines in turn and hit Alt-Enter
// on each to see what your function returns.

// Please feel free to contact me if you want to ask any questions.
// Drop me an email at dave@pragdave.me with some suggested times
// and I'll set up a call.


// -----------------------------------------------------

// 1. Write a function `average` that finds the average of two 
//    numbers

let average a b = «your code goes here»

average 1.0 2.0
average 1 2
average 100 0.0

// 2. Write a function `isPythag` that takes three integers and
//    returns `true` if they form a Pythagorean triple
//    (a² + b² = c²). The operator `=` tests for equality
//

let isPythag a b c = «your code goes here»

isPythag 3 4 5
isPythag 4 5 6
isPythag 5 12 13

// 3. Write a function  `apply` that takes a value and another
//    function as parameters. It should return the result 
//.   of running that passed-in function with the given value
//.   as an argument
//  
//.   let square x = x*x
//.   let add2 n = n + 2
//.   apply 5 square      -> 25
//.   apply 5 add2        -> 7
//.
//.   apply (apply 5 add2) square -> 47 

let apply v f = «your code goes here»

let square x = x*x
let add2 n = n + 2
apply 5 square      
apply 5 add2        
apply (apply 5 add2) square 

// 4. Symbols such as + and - are called operators. In F# most
//    operators are functions. The name of these functions
//.   is just the operator written inside parentheses, so
//.   (+) is the function that implements addition and (-)
//.   if the function for subtraction. Operators can contain
//.   multiple nonalphanumeric characters.
//.   
//.   Create a new operator (|->) that is the same as the
//    apply function in (3) above. Then try the examples.

let (|->) = «your code goes here»

5 |-> square
5 |-> add2
5 |-> add2 |-> square
5 |-> add2 |-> square |-> add2

// What you've just created is the "pipeline" operator.
// It lets you chain functions together, so you can feed
// a value in one end, then pass it through a function. The
// result of that function is then passed to the next, 
// and its result passed to the one after, and so on.
//
// This operator is so useful that it is predefined by F#,
// which calls it (|>). 

5 |> square
5 |> add2
5 |> add2 |> square
5 |> add2 |> square |> add2


