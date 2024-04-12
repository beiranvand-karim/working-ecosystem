namespace WorkingEcosystem
open System.IO

module main =
    let outcomeDirectory = Directory.CreateDirectory("outcome")
    let fendDirectory = Directory.CreateDirectory("outcome/fend")
    let bendDirectory = Directory.CreateDirectory("outcome/bend")
    let callsDirectory = Directory.CreateDirectory("outcome/calls")
    printfn "directories created, copy the content of outcome ..."
    open Utils
    let openFend = executeProcess "explorer" "C:\\feature namings\\toli\\cuda\\material selection\\fend"
    let openBend = executeProcess "explorer" "C:\\feature namings\\toli\\cuda\\material selection\\bend"
    let openCalls = executeProcess "explorer" "C:\\feature namings\\toli\\cuda\\material selection\\calls"