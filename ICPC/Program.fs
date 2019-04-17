module ICPC
open System

//                                      e.g. input = "One, two, three."
let listOfCharLists (input: string) = //words = [ ['O';'n';'e';','];  ['t';'w';'o';','];  ['t';'h';'r';'e';'e';'.'] ]
  let wordList = Seq.toList(input.Split [|' '|])
  let words = List.map (fun c -> Seq.toList c) wordList//Seq.toList wordList
  words

let rec checkCommaSuffix input = 
  match input with
  |[] -> true
  |head::tail -> match head with
                 |',' -> match tail.Head with 
                               |' ' -> (checkCommaSuffix tail)
                               |_ -> false
                 |_-> checkCommaSuffix tail

let rec checkSpaceSuffix input = 
  match input with
  |[] -> true
  |head::tail -> match head with
                 |' ' -> match System.Char.IsLetter(tail.Head) with 
                               |true -> (checkCommaSuffix tail)
                               |_ -> false
                 |_-> checkCommaSuffix tail

let rec checkStopSuffix input = 
  match input with
  |[] -> true
  |head::tail -> match tail with 
                 |[] -> true
                 |_ ->
                     match head with
                     |'.' -> match tail.Head with 
                                   |' ' -> (checkStopSuffix tail)
                                   |_ -> false
                     |_-> checkStopSuffix tail



let listOfChars (input: string) = 
  let wordList = Seq.toList input
  wordList
//                                   e.g. input = "One, two, three."

let isUpper (input : char) = input = System.Char.ToUpper input

let putCommas xs (wordIn : string) = 
  let word = wordIn.[0..wordIn.Length-2]
  xs |> List.choose (fun elem ->
          match elem = (word + ",") with
          |true -> Some (word + ", ")
          |_->   
           match elem = word with
           |true -> Some (word + ", ")
           |false -> Some word)

let listOfStrings (input : string) =  //wordList = ["One,"; "two,"; "three."]
  let wordList = Seq.toList (input.Split [|' '|])
  wordList

let functR listyBoy (accyBoy) =
  let rec loop (xs : string list) (acc : string list) =
    match acc with
    |[] -> xs
    |_ ->
        let x = acc.Head
        match  x |> Seq.last  = ',' with
        |true -> loop (putCommas xs acc.Head) acc.Tail
        |false -> loop xs acc.Tail
  loop listyBoy accyBoy

   

//rules: Deals with error cases
let rules input = 
  match input with
  |"" -> None //cant be empty
  |_ ->
    let words = listOfCharLists input
    let stringList = listOfStrings input
    let firstElem = words.Head
    let charList = listOfChars input
    let cleanList = (List.filter (fun c -> c <> ' ' && c <> '.' && c <> ',') charList)
    let lastChar = charList.[charList.Length-1]
    match input.Contains("  ") || input.Contains(" .") with
    |true -> None
    |false ->
      match (checkCommaSuffix charList && checkSpaceSuffix charList && checkStopSuffix charList) with
      |false -> None
      |true ->
        //Console.WriteLine(sprintf "%A" stringList)
        match ( cleanList |> List.exists (fun c -> c = System.Char.ToUpper c)) with //cant be any upper case letters
        |false ->    
          match firstElem.Length >= 2 with //must be a word, most words are more than 2 chars right?
          |true -> 
            match lastChar with
            |'.' -> Some (System.String.Concat(functR (listOfStrings input) (listOfStrings input))) //sentence must end with a fullstop
            |_ -> None
          |_ -> None
        |true -> None
  

let commaSprinkler input =
  rules input


let rivers input = failwith "asd"
(*
    //convert to string[] and split by whitespace
    let inputtmp = input.ToString().Split(' ')
    let listWds= input |> List.ofArray
    let getEnd = input.Length // -1?


    //check length of words conforms to requirements
    let rec checkLength lstwds =
        match lstwds with
        | [] -> None
        | head :: tail ->
        

    listWds |> List.iter (fun x -> 
    match x.length with
    | x when x > 80  -> None
    | _ -> Some

    )

    match listWds.length >= 2 with
    |false, _ -> None
    |true ->
            let index = input.ToString().indexOf(" ")
            match input.ToString().Contains(" ") with
            | true
            | false
*)
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    
    commaSprinkler "please sit spot. sit spot, sit. spot here now here." //|> printfn "%A"
    0 // return an integer exit code 
