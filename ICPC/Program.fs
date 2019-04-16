(*
Sprinkler ToDo:

find words that are preceded by a comma (List.find)
go through the list and add all the commas unless its the first word

do the same thing as above but for words with commas after them unless its the last word in the sentance

apply the rules over and over untill there are no more possible commas to add.
*)

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

(*
let rec checkStopPrefix input = 
  match List.rev input with
  |[] -> true
  |head::tail -> match head with
                 |'.' -> match tail.Head with 
                               |' ' -> false
                               |_ -> (checkStopPrefix tail)
                 |_-> checkStopPrefix tail
*)

let listOfChars (input: string) = 
  let wordList = Seq.toList input
  wordList
//                                   e.g. input = "One, two, three."
let listOfStrings (input : string) =  //wordList = ["One,"; "two,"; "three."]
  let wordList = Seq.toList (input.Split [|' '|])
  wordList

let isUpper (input : char) = input = System.Char.ToUpper input

//shaker: Deals with input cases
// input = "test." |> Some "test." 
let shaker input = 
  let words = listOfStrings input

  let rec shakeLeft (afterWord : String list) = 
    match afterWord with
    |[] -> []
    |head::tail -> match head.[head.Length-1] with
                   |',' -> [head] @ shakeLeft tail 
                   |_ -> shakeLeft tail

  let rec shakeRight (beforeWord : String list) = 
    match beforeWord with
    |[] -> []
    |head::tail -> match head.[head.Length-1] with
                   |',' -> [tail.Head] @ shakeRight tail 
                   |_ -> shakeRight tail

  //Comma was before the word so add comma to before other occurances
  let leftWords = shakeRight words
  let cleanLeft = leftWords |> List.map (fun c -> c.[0..c.Length-2]) 

  //Comma was after the word so add comma to after other occurances
  let rightWords = shakeLeft words
  let cleanRight = rightWords |> List.map (fun c -> c.[0..c.Length-2]) 

  let cleanWords = words |> List.filter (fun c -> c <> ".") 

  let rec funct cleanLeft cleanRight words = 
    match cleanLeft with 
    | words -> 
    |
    match cleanRight with 
    |//base case
    |


(*
each time a word from cleanLeft||cleanRight, matches words(input): check rules, give comma.
check left & right
repeat. untill no new occurances in cleanLeft||cleanRight - no new clean words, when list stops updating, must be no more?
*)

//let commaWords = rightWords @ leftWords
//let cleanWords = commaWords |> List.map (fun c -> c.[0..c.Length-2]) 
//print out------------------------------------------------------------
  Console.WriteLine(sprintf "words: \n%A" words)
  //Console.WriteLine(sprintf "foundWords: \n%A" commaWords)
  Console.WriteLine(sprintf "cleanLeft: \n%A" cleanLeft)
  Console.WriteLine(sprintf "cleanRight: \n%A" cleanRight)
  //Console.WriteLine(sprintf "shakeWords: \n%A" shakeWords)
//print out------------------------------------------------------------
 

  
  
  (*
  match isInList elemToFindWords with
  |false -> Some input
  |true -> 
          let rec sprinkle input =
            match input with *)

    
    

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
    
    //Console.WriteLine(sprintf "charList: \n%A" charList)
    match ( cleanList |> List.exists (fun c -> c = System.Char.ToUpper c)) with //cant be any upper case letters
    |false ->    
      match firstElem.Length >= 2 with //must be a word, most words are more than 2 chars right?
      |true -> 
        match lastChar with
        |'.' -> Some (shaker input) //sentence must end with a fullstop
        |_ -> None
      |_ -> None
    |true -> None
    |false ->
      match (checkCommaSuffix charList && checkSpaceSuffix charList && checkStopSuffix charList) with
      |false -> None
      |true ->
        Console.WriteLine(sprintf "%A" stringList)
        match ( cleanList |> List.exists (fun c -> c = System.Char.ToUpper c)) with //cant be any upper case letters
        |false ->    
          match firstElem.Length >= 2 with //must be a word, most words are more than 2 chars right?
          |true -> 
            match lastChar with
            |'.' -> Some ("Hello") //sentence must end with a fullstop
            |_ -> None
          |_ -> None
        |true -> None
  


  

//let checkInbetweenWords input = 
//  match input with
//  | [_;'.';letters;_]| [_;',';letters;_] -> Some ()
//  | [_;' ';' ';_] -> None

let commaSprinkler input =
  rules input
  //let x = 15
  //x

let rivers input =
    failwith "Not implemented"

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
   
    commaSprinkler "please sit spot. sit spot, sit. spot here now here." |> printfn "%A"
    //        Some("please, sit spot. sit spot, sit. spot, here now, here.")

    0 // return an integer exit code 
