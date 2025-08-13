//JS is a Client side scripting language used for creating dynamic content in HTML. Js is the default scripting language for all browsers. MS based browsers support additional Scripting language called VBScript. 
//JS is maintained by ECMA(European Computers Manufacturers Association) and it releases newer stds every year. 
//There are 3 UI based functions in JS that can be used for UI interactions. 
//alert, prompt and confirm. 
//alert is like message boxes that draws the attention of the User and waits till the user closes the dialog. 
//prompt is more like a Question and answer where the input is the return value of the function. 
//confirm is more like confirmation window where an user can accept or reject the informtion in the form of Ok and Cancel. 
alert("Test 123");
let result = prompt("Enter UR name")
let answer = confirm(`Is The Name entered ${result} correct?`)
if(answer){
    alert("Correct")
}else{
    alert("Incorrect")
}

