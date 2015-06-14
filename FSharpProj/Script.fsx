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

let trainingPath = @"C:\Users\xavi\Dropbox\Dev work\Machine Learning for .NET Developers\trainingsample.csv";
let trainingData = reader trainingPath