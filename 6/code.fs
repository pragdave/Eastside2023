type Dictionary = Map<string, list<string>>

let signatureOf (word : string) : string  =
    word |> Seq.sort |> System.String.Concat

let readLines filePath = System.IO.File.ReadLines(filePath)

let addToOrCreateList maybeList word =
     match maybeList with
     | Some s -> Some (s |> List.append [word])
     | None -> Some [ word ]
    
let addToDictionary signature word map =
    Map.change signature (fun entry -> addToOrCreateList entry word) map

let dictionary wordlist =
  wordlist
  |> readLines 
  |> Seq.fold (fun acc word -> addToDictionary (signatureOf word) word acc) Map.empty

let findAnagrams (dict: Dictionary) (word: string) : list<string> = 
    match signatureOf word |> dict.TryFind  with
    | Some anagrams -> anagrams
    | None -> []

let rec repl (dictionary : Dictionary) : int = 
    printf "Enter word: "
    let word = System.Console.ReadLine()
    if word = "" then
        printfn "Bye!"
        0
    else
        printfn "%A" (findAnagrams dictionary word)
        repl dictionary

[<EntryPoint>]
let main(args) =    
    let dict = dictionary args[0]
    repl dict