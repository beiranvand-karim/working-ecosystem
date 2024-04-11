open System.IO
open System.IO.Compression


let fendDirectory = Directory.CreateDirectory("fend")
let bendDirectory = Directory.CreateDirectory("bend")
let callsDirectory = Directory.CreateDirectory("calls")

printfn "directories created ..."