module EcoSystem.Scripts

open System.IO
open System

type ProcessResult = { 
    ExitCode : int; 
    StdOut : string; 
    StdErr : string 
}

let executeProcess (processName: string) (processArgs: string) =
    let psi = new Diagnostics.ProcessStartInfo(processName, processArgs) 
    psi.UseShellExecute <- false
    psi.RedirectStandardOutput <- true
    psi.RedirectStandardError <- true
    psi.CreateNoWindow <- true        
    let proc = Diagnostics.Process.Start(psi) 
    let output = new Text.StringBuilder()
    let error = new Text.StringBuilder()
    proc.OutputDataReceived.Add(fun args -> output.Append(args.Data) |> ignore)
    proc.ErrorDataReceived.Add(fun args -> error.Append(args.Data) |> ignore)
    proc.BeginErrorReadLine()
    proc.BeginOutputReadLine()
    proc.WaitForExit()
    { ExitCode = proc.ExitCode; StdOut = output.ToString(); StdErr = error.ToString() }


let outcomeDirectory = Directory.CreateDirectory("outcome")
let fendDirectory = Directory.CreateDirectory("outcome/fend")
let bendDirectory = Directory.CreateDirectory("outcome/bend")
let callsDirectory = Directory.CreateDirectory("outcome/calls")

printfn "directories created, copy the content of outcome ..."


let result = executeProcess "explorer" "C:\\feature namings\\toli\\cuda\\material selection\\fend"
let result = executeProcess "explorer" "C:\\feature namings\\toli\\cuda\\material selection\\bend"
let result = executeProcess "explorer" "C:\\feature namings\\toli\\cuda\\material selection\\calls"