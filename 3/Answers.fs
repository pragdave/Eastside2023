// You'll find 5 ewxercises below (although the first one is just
// to make sure you can run the code). You can run the code by
// pressing Ctrl+Enter in the editor. You can also run the code
// from the command line by running `dotnet fsi Program.fsx`

// If you run into any problems, or want to chat about any of this, 
// drop me an  email at dave@pragdave.me, giving me some times when 
// you're available to chat.

// Here's the fold function we wrote:

let rec fold func initial list =
  match list with
  | h::t -> fold func (func initial h)   t
  | []   -> initial

// Example: add the numbers from 1 to 10 and
// print the result:
fold (+) 0 [1..10] |> printfn "%A"

// (remember that |> pipes the result of the expression on the left
// to the function on the right). The %A format specifier prints the
// result in a human-readable format.

// -----------
// EXERCISE 1:
// Make sure you can run this example, and the result is "55"


// -----------
// EXERCISE 2:
// The operator + also works with strings, so 
// "cat" + "dog" = "catdog"
// Write a function that takes two astrings and concatenates
// them with a comma in between. Then use fold to concatenate
// a list of strings into a comma-separated single string.
let concat a b = a + "," + b
fold concat "" ["cat"; "dog"; "mouse"] |> printfn "%A"

// -----------
// EXERCISE 3:
// You'll see that the result of the previous exercise has
// a leading comma.
//
// a. Where does this come from?
// b. Fix it by writing a variant of the concat function
//    that doesn't add a comma if the first string is empty.

let concat1 a b = 
  match a with
  | "" -> b
  | _  -> a + "," + b

fold concat1 "" ["cat"; "dog"; "mouse"] |> printfn "%A"

// -----------
// EXERCISE 4:
// The `map` function is a common operation on lists. It takes
// a function and a list, and applies the function to each
// element of the list, building the result into a new
// list. For example:
//
//     map (fun x -> x + 1) [1;2;3] = [2;3;4]
//
// Use the fold function to write a map function. You might need two 
// hints to get this to work:
// 1. You'll need to use the `::` operator to build the list.
// 2. Your result might be in the wrong order.
//    a. Can you see why?
//    b. How can you fix it? (Hint: use the List.rev function)

// -----------
let map func list =
  fold (fun acc x -> (func x) :: acc) [] list
  |> List.rev

map (fun x -> x + 1) [1;2;3] |> printfn "%A"

// EXERCISE 5:
// Use the map and fold functions to find the sum of the sum or the 
// squares of the numbers from 1 to 10.

map (fun x -> x * x) [1..10]
|> fold (+) 0
|> printfn "%A"