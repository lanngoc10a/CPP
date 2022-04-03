namespace LibFSH
//Simple Example of F#
module Currency =
    let hello name =
        printfn "Hello %s" name

    let currency = ["EUR"; "Y"; "$"; "£"; "SEK"]
    let rate = [9.0; 1.0; 8.0; 12.0; 1.1]
 
    let GetCurrencyIndex c = 
            currency |> List.findIndex(fun x -> x = c) 

    let GetCurrencyRate c = rate.Item(GetCurrencyIndex(c))

    let GetCurrencyFromCar c =
          let car = c
          match car with
          | "Tesla" -> GetCurrencyRate("$")
          | "Jaguar" -> GetCurrencyRate("£")
          | "Volvo" -> GetCurrencyRate("SEK")
          | "Toyota" -> GetCurrencyRate("Y")
          | _ -> GetCurrencyRate("EUR")


