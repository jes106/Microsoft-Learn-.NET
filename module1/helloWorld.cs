
//EJERCICIO: ESCRIBIR EL PRIMER CÓDIGO

Console.WriteLine("Hello world!");

// Ahora, vamos a experimentar unos errores

try{
    console.WriteLine("Hello world!");
}
catch (Exception e){
    Console.WriteLine(e.StackTrace);
    Console.WriteLine("^ Aquí se indica el número de línea y columna donde se produjo el error");
}

try{
    Console.WriteLine('Hello World!');
}
catch(Exception e){
    Console.WriteLine(e.StackTrace);
}

//Ahora vamos a escribirlo todo en una línea

Console.Write("Congratulations!");
Console.Write(" ");
Console.Write("You wrote your first lines of code.");