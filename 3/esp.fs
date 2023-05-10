module Dave

let rec sum list =
  match list with
  | h :: t -> h + sum t
  | []     -> 0

let rec times list =
  match list with
  | h :: t -> h * times t
  | []     -> 1

let rec fold func initial list =
  match list with
  | h::t -> fold func (func initial h)   t
  | []   -> initial

let add a b = a+b
fold add 0 [1;2;3;4;5]