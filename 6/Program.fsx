type Dictionary = Map<string, list<string>>

let generateSignature (word : string) : string  =
    word |> Seq.sort |> System.String.Concat

let readLines = System.IO.File.ReadLines("words.txt")

let addToOrCreateList maybeList word =
  match maybeList with
  | Some existing -> Some ( existing |> List.append [word])
  | None          -> Some [ word ]

let addToDictionary signature word dictionary =
  Map.change signature (fun entry -> addToOrCreateList entry word) dictionary

let mergeInWord result word = 
  addToDictionary (generateSignature word) word result

let dictionary () =
  readLines 
  |> Seq.fold mergeInWord Map.empty 

let findAnagrams (dict: Dictionary) (word: string) : list<string> =
  match word |> generateSignature |> dict.TryFind with
  | None -> []
  | Some anagrams -> anagrams


let rec inputLoop (dict: Dictionary) : int =
  printf "Enter word: "
  let word = System.Console.ReadLine()
  if word = "" then
    0
  else
    findAnagrams dict word |> printfn "%A"
    inputLoop dict


let mostAnagramsIn (dict: Dictionary)  =
  dict
  |> Map.toList
  |> List.sortBy (fun (signture, anagrams) -> anagrams.Length)
  |> List.last

let chooseLongest (len, longestList) signature (wordList: list<string>) =
  match wordList.Length with
    | newLen when newLen > len -> ( newLen, wordList)
    | _ -> ( len, longestList)

let most (dict: Dictionary) =
  Map.fold chooseLongest (0, []) dict
