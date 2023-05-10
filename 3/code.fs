module Dave

let rec length list = 
  match list with
  | []     -> 0
  | h :: t -> 1 + length t

let rec sum list = 
  match list with
  | []     -> 0
  | h :: t -> h + sum t

let rec product list = 
  match list with
  | [h]    -> h
  | h :: t -> h * product t

  
let rec fold f initialValue li =
     match li with
         | [] -> initialValue
         | h::t -> fold f (f initialValue h) t

// let add a b = a + b
// fold add 0 [3;4;5]