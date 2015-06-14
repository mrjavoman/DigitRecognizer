// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

//#load "Library1.fs"
//open FSharpProj

open System.IO

type Observation = {Label:string; Pixels:int[]}

let toObservation(csvData:string) = 
    let columns = csvData.Split(',')
    let label = columns.[0]
    let pixels = columns.[1..] |> Array.map int
    {Label = label; Pixels= pixels}

let reader path = 
    let data = File.ReadAllLines path
    data.[1..]
    |> Array.map toObservation

let manhattanDistance (pixels1, pixels2) =
    Array.zip pixels1 pixels2
    |> Array.map (fun(x,y) -> abs(x-y))
    |> Array.sum

let train (trainingset:Observation[])=
    let classify (pixels:int[]) =
        trainingset
        |> Array.minBy(fun x -> manhattanDistance (x.Pixels, pixels))
        |> fun x -> x.Label
    classify



let trainingPath = @"C:\Users\xavi\Dropbox\Dev work\Machine Learning for .NET Developers\trainingsample.csv"
let trainingData = reader trainingPath;;

let classifier = train trainingData;;

let validationPath = @"C:\Users\xavi\Dropbox\Dev work\Machine Learning for .NET Developers\validationsample.csv"
let validationData = reader validationPath;;

validationData
|> Array.averageBy (fun x -> if classifier x.Pixels = x.Label then 1. else 0.)
|> printfn "Correct: %.3f"
