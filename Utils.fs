namespace WorkingEcosystem

module Utils =
    type ProcessResult = { 
        ExitCode : int; 
        StdOut : string; 
        StdErr : string 
    }
    open System
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
