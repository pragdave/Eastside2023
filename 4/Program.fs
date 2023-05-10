let signatureOf (word : string) : string  =
    word |> Seq.sort |> System.String.Concat


type Dictionary = Map<string, list<string>>


let readLines = System.IO.File.ReadLines("words.txt")

let addToOrCreateList maybeList word =
  match maybeList with
  | Some existing -> Some ( existing |> List.append [word])
  | None          -> Some [ word ]

let addToDictionary signature word dictionary =
  Map.change signature (fun entry -> addToOrCreateList entry word) dictionary

let dictionary () =
  readLines 
  |> Seq.fold (fun result word -> addToDictionary (signatureOf word) word result) Map.empty 






[<EntryPoint>]
let main(args) =    
    0