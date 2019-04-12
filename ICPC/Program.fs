module ICPC
open System

type letters = {//this is totally wrong
  |'a'
  |'b'
  |'c'
  |'d'
  |'e'
  |'f'
  |'g'
  |'h'
  |'i'
  |'j'
  |'k'
  |'l'
  |'m'
  |'n'
  |'o'
  |'p'
  |'q'
  |'r'
  |'s'
  |'t'
  |'u'
  |'v'
  |'w'
  |'x'
  |'y'
  |'z'
}

let checkLetter input = //takes in a char and checks if it is a valid char

  match input with
  |'a' |'b' |'c' |'d' |'e' |'f' |'g' |'h' |'i' |'j' |'k' |'l' |'m' |'n' |'o' |'p' |'q' |'r' |'s' |'t' |'u' |'v' |'w' |'x' |'y' |'z'|','|' '|'.' -> true
  |_ -> false

  let checkInbetweenWords input = 
    match input with
    | [_;'.';letters;_]| [_;',';letters;_] -> Some ()
    | [_;' ';' ';_] -> None

let commaSprinkler input =
  let inputList = Seq.toList input //convert the input string to a list
  //---------------Checks to make sure the input string is valid-----------------
  let checkLength input = //kick out the function if the length is wrong
    match inputList.Length>1 with
    | false -> None
    | _-> Some ()

  let isLegalInput input = 
    match (List.exists checkLetter inputList) with
    |false -> None
    |_ -> Some ()
  ()//delete this unit
  

  
  //---------------End Checks to make sure the input string is valid-------------
    //failwith "Not implemented"

let rivers input =
    failwith "Not implemented"

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    0 // return an integer exit code
