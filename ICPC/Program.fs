(*
Sprinkler ToDo:

find words that are preceded by a comma (List.find)
go through the list and add all the commas unless its the first word

do the same thing as above but for words with commas after them unless its the last word in the sentance

apply the rules over and over untill there are no more possible commas to add.
*)

module ICPC
open System


(*let checkLetter input = //takes in a char and checks if it is a valid char
  //let listOfAccepted = ['A'..'Z']::['a'..'z']::[','::' '::['.']]
  //printfn "%A" input
  match input with 
  //|'a' |'b' |'c' |'d' |'e' |'f' |'g' |'h' |'i' |'j' |'k' |'l' |'m' |'n' |'o' |'p' |'q' |'r' |'s' |'t' |'u' |'v' |'w' |'x' |'y' |'z'|','|' '|'.' -> true
  |listOfAccepted -> true
  |_ -> false)
  *)
let listOfCharLists (input: string) = 
  let wordList = input.Split [|' '|]
  let words = Seq.toList wordList
  words

let listOfChars (input: string) = 
  let wordList = Seq.toList input
  wordList

let getListLastChars input = 
   match input with 
   |[] -> None 
   |_::t -> Some t

let rules input =   //Deals with error cases
  match input with
  |"" -> None //cant be empty
  |_ ->
    let words = listOfCharLists input
    let firstElem = words.Head
    let wordsList = listOfChars input
    let lastChar = wordsList.Tail
    match input with 
    |"" -> None 
    |_ -> match firstElem.Length > 2 with //must be a word, most words are more than 2 chars right?
                |true -> match lastChar with
                          |['.'] -> Some () //sentence must end with a fullstop
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
