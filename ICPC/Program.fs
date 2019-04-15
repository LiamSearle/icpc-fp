module ICPC
open System


let checkLetter input = //takes in a char and checks if it is a valid char
  let listOfAccepted = ['A'..'Z']::['a'..'z']::[','::' '::['.']]
  //printfn "%A" input
  match input with 
  //|'a' |'b' |'c' |'d' |'e' |'f' |'g' |'h' |'i' |'j' |'k' |'l' |'m' |'n' |'o' |'p' |'q' |'r' |'s' |'t' |'u' |'v' |'w' |'x' |'y' |'z'|','|' '|'.' -> true
  |listOfAccepted -> true
  |_ -> false

//                                      e.g. input = "One, two, three."
let listOfCharLists (input: string) = //words = [ ['O';'n';'e';','];  ['t';'w';'o';','];  ['t';'h';'r';'e';'e';'.'] ]
  let wordList = input.Split [|' '|]
  let words = Seq.toList wordList
  words

//                                   e.g. input = "One, two, three."
let listOfStrings (input: string) =  //wordList = ["One,"; "two,"; "three."]
  let wordList = Seq.toList input
  wordList


let getListLastChars input = //I don't think this is used
   match input with [] -> None | _::t -> Some t

//shaker: Deals with input cases
// input = "test." |> Some "test." 
let shaker input = 
  let words = listOfCharLists input
  //let noComma = Char. (fun c -> Char.is
  //match noComma with
  match List.tryFind [','] words with
  |None -> Some (input)
  |_ -> Some (input)

//rules: Deals with error cases
let rules input =   
  match input with
  |"" -> None //cant be empty
  |_ ->
    let words = listOfCharLists input
    let firstElem = words.Head
    let wordsList = listOfStrings input
    let lastChar = wordsList.Tail
    match input with 
    |"" -> None 
    |_ -> match firstElem.Length > 2 with //must be a word, most words are more than 2 chars right?
                |true -> match lastChar with
                          |['.'] -> Some (shaker input) //sentence must end with a fullstop
                          |_ -> None
                |_ -> None


  

//let checkInbetweenWords input = 
//  match input with
//  | [_;'.';letters;_]| [_;',';letters;_] -> Some ()
//  | [_;' ';' ';_] -> None

let commaSprinkler input =
  rules input

let rivers input =
    failwith "Not implemented"

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
