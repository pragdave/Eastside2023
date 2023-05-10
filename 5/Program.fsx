type Anagrams = list<string>
type Dictionary = Map<string, Anagrams>

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

let findAnagrams (dict: Dictionary) (word: string) : Anagrams =
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



let mostAnagramsIn (dict: Dictionary) =
  dict 
  |> Map.toList
  |> List.sortBy (fun (signature, anagrams) -> anagrams.Length)
  |> List.last

let most (dict: Dictionary) =
  let chooseLongest (len, longest) _signature (anagrams: Anagrams) =
    match anagrams.Length with
    | newLen when (newLen > len) -> (newLen, anagrams)
    | _otherwise                 -> (len, longest)
  in
    Map.fold chooseLongest (0, []) dict

let pythag max =
  [ for a in 3..max do
      for b in a..max do
        for c in b..max do
          if a*a + b*b = c*c then yield (a, b, c)
  ]