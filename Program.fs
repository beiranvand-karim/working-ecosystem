open System.IO
open System.IO.Compression

let outcomeDirectory = Directory.CreateDirectory("outcome")
let fendDirectory = Directory.CreateDirectory("outcome/fend")
let bendDirectory = Directory.CreateDirectory("outcome/bend")
let callsDirectory = Directory.CreateDirectory("outcome/calls")

printfn "directories created, copy the content of outcome ..."